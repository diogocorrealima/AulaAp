using AulaAP.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Events
{
    public class RegisteredOrderEvent : Event
    {
        public RegisteredOrderEvent(string orderCode)
        {
            OrderCode = orderCode;
        }

        public string OrderCode { get; set; }
    }
}
