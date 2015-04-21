using umbraco.interfaces;

namespace DocumentTypeMover.IActions
{
    public class ActionMoveDocumentType : IAction
    {
        private static readonly ActionMoveDocumentType InnerInstance = new ActionMoveDocumentType();

        public static ActionMoveDocumentType Instance
        {
            get { return InnerInstance; }
        }

        public string Alias
        {
            get { return "move"; }
        }

        public bool CanBePermissionAssigned
        {
            get { return false; }
        }

        public string Icon
        {
            get { return "enter"; }
        }

        public string JsFunctionName
        {
            get { return ""; }
        }

        public string JsSource
        {
            get { return ""; }
        }

        public char Letter
        {
            get { return '¨'; }
        }

        public bool ShowInNotifier
        {
            get { return false; }
        }
    }
}