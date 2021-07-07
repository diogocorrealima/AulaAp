using AulaAP.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AulaAP.Services.Api.Controllers
{
    [Produces("application/json")]
    public abstract class MainController : ControllerBase
    {
        public List<string> Errors { get; set; } = new List<string>();

        private readonly DomainNotificationHandler domainNotifications;
        private readonly IMediator mediator;

        public MainController(INotificationHandler<DomainNotification> notificationHandler, IMediator mediator)
        {
            this.domainNotifications = (DomainNotificationHandler)notificationHandler;
            this.mediator = mediator;
        }
        protected new IActionResult Response(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else
            {
                AddErrors();
                return BadRequest(new
                {
                    success = false,
                    errors = Errors
                });
            }

        }
        protected bool ValidOperation()
        {
            return (ModelState.IsValid && !domainNotifications.HasNotifications());
        }
        private void AddErrors()
        {
            if (!ModelState.IsValid)
            {

                ModelState.Values.SelectMany(v => v.Errors).ToList()
                    .ForEach(error =>
                    {
                        if (error.Exception == null)
                        {
                            Errors.Add(error.ErrorMessage);
                        }
                        else
                        {
                            Errors.Add(error.Exception.Message);
                        }
                    });
            }

            if (domainNotifications.HasNotifications())
            {
                domainNotifications.GetNotifications().ForEach(notification =>
                {
                    Errors.Add($"{notification.Key} - {notification.Value}");
                });
            }
        }
    }
}
