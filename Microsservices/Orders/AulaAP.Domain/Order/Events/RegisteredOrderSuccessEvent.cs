using AulaAP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Events
{
    public class RegisteredOrderSuccessEvent : Event
    {
        public RegisteredOrderSuccessEvent(string orderCode)
        {
            OrderCode = orderCode;
        }

        public string OrderCode { get; set; }
    }
}
