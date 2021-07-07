using System;
using System.Collections.Generic;
using System.Text;

namespace AulaAP.Domain.Shared
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }

        public Guid DomainNotificationId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        
    }
}
