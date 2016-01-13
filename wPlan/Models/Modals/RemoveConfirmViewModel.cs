using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OdrorirBoard.Areas.BackEnd.Models;

namespace OdrorirBoard.Models.Modals
{

    public class RemoveConfirmViewModel
    {
        //Händelse som sker efter att användaren har godkänt "Remove"
        public string PostRemoveAction { get; set; }

        //[OPTIONAL] controll, som kollar efter Post Remove Action.
        // Denna controllern används utifrån Post Delete Action.
        public string PostRemoveController { get; set; }

        //Undertiden som Post Delete Action körs, så behövs ID från Entity att ta bort.
        public Guid RemoveEntityId { get; set; }

        //Remove godkännande, dialog header text. Tex. "Delete Estimated Effort", Header texten
        // är "Estimated Effort"
        public string HeaderText { get; set; }

    }
}
