using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdrorirBoard.Helpers;

namespace OdrorirBoard.Areas.BackEnd.Controllers
{
    public class NotificationController : Controller
    {
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(NotificationAlert.AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(NotificationAlert.AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(NotificationAlert.AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(NotificationAlert.AlertStyles.Danger, message, dismissable);
        }

        public void Error(string message, bool dismissable = false)
        {
            AddAlert(NotificationAlert.AlertStyles.Error, message, dismissable);
        }

        public void Required(string message, bool dismissable = false)
        {
            AddAlert(NotificationAlert.AlertStyles.Required, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(NotificationAlert.TempDataKey)
                ? (List<NotificationAlert>)TempData[NotificationAlert.TempDataKey]
                : new List<NotificationAlert>();

            alerts.Add(new NotificationAlert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[NotificationAlert.TempDataKey] = alerts;
        }

    }
}