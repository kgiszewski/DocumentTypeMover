using System.Linq;
using System.Web.Http;
using DocumentTypeMover.Models;
using DocumentTypeMover.PetaPocoModels;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace DocumentTypeMover.Controllers
{
    [PluginController("DocumentTypeMoverApi")]
    public class DocumentTypeMoverController : UmbracoAuthorizedJsonController
    {
        public object GetSiblings(int doctypeId)
        {
            var contentTypeService = Services.ContentTypeService;

            var currentDoctype = contentTypeService.GetContentType(doctypeId);

            return contentTypeService.GetContentTypeChildren(currentDoctype.ParentId).Where(x => x.Id != doctypeId);
        }

        [HttpPost]
        public object MoveDoctype(MovePostModel model)
        {
            var contentTypeService = Services.ContentTypeService;

            var currentDoctype = contentTypeService.GetContentType(model.DoctypeId);

            currentDoctype.ParentId = model.TargetDoctypeId;

            contentTypeService.Save(currentDoctype);

            //composite keys don't work right in PetaPoco so doing a delete/insert instead
            var db = ApplicationContext.DatabaseContext.Database;
            
            db.Delete<ContentType2ContentTypeDto>(@"
                WHERE childContentTypeId = @0
            ", model.DoctypeId);

            db.Insert(new ContentType2ContentTypeDto()
            {
                ChildId = model.DoctypeId,
                ParentId = model.TargetDoctypeId
            });

            return "Doctype Moved.";
        }
    }
}