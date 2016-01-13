using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdrorirBoard.Helpers
{
    public class MessagePop
    {

        public const string TempData = "TempDataMessages";

        public string MessageTypes { get; set; }
        public string MessageString { get; set; }
        public bool dismissable { get; set; }

        public class MessageAlerts
        {
            public string NewSuccess = "Created : Successfully !";
            public string NewError = "Error : Couldnt Create!";

            public string ChangeSuccess = "Changes : Successfully Saved!";
            public string ChangeError = "Error : Couldnt Save!";

            public string RemoveSuccess = "Removed : Successfully deleted!";
            public string RemoveError = "Error : Couldnt Remove! ";
        }

        public enum MessageType
        {
            New,
            Change,
            Remove,
        }

        public class MessageAlert
        {
            public long MessageAlertId { get; set; }
            public string MessageTitle { get; set; }
            public MessageType MessageType { get; set; }
            public string UserId { get; set; }
        }
    }
}