using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace DocumentTypeMover.PetaPocoModels
{
    [TableName("cmsContentType2ContentType")]
    [ExplicitColumns]
    internal class ContentType2ContentTypeDto
    {
        [Column("parentContentTypeId")]
        [PrimaryKeyColumn(AutoIncrement = false, Clustered = true, Name = "PK_cmsContentType2ContentType", OnColumns = "parentContentTypeId, childContentTypeId")]
        public int ParentId { get; set; }

        [Column("childContentTypeId")]
        public int ChildId { get; set; }
    }
}