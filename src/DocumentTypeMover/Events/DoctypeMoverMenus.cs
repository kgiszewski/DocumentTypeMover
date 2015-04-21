using System;
using DocumentTypeMover.IActions;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;
using Umbraco.Core;

namespace DocumentTypeMover.Events
{
    public class DoctypeMoverMenus : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarted(umbracoApplication, applicationContext);

            BaseTree.BeforeNodeRender += BaseTreeOnBeforeNodeRender;
        }

        private void BaseTreeOnBeforeNodeRender(ref XmlTree sender, ref XmlTreeNode node, EventArgs eventArgs)
        {
            if (node.NodeType.ToLower() == "nodetypes")
            {
                node.Menu.Insert(1, ActionMoveDocumentType.Instance);
                node.Menu.Insert(2, ActionRefresh.Instance);
            }
        }
    }
}