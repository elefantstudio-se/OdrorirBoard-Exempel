using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdrorirBoard.Helpers
{
    public class NotificationAlert
    {

        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }

        public static class AlertStyles
        {
            public const string Success = "success";
            public const string Error = "error";
            public const string Information = "info";
            public const string Warning = "warning";
            public const string Danger = "danger";
            public const string Required = "required";
        }

        public enum NotificationType
        {
            Registration,
            Email
        }

        public class Notification
        {
            public long NotificationId { get; set; }
            public string Title { get; set; }
            public NotificationType NotificationType { get; set; }
            public string Controller { get; set; }
            public string Action { get; set; }
            public string UserId { get; set; }
            public bool IsDismissed { get; set; }

        }
    }
}