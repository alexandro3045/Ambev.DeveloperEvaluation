using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using MediatR;
using System.Diagnostics;

namespace Ambev.DeveloperEvaluation.Application.Serivices.Events
{
    public class LogEventHandler : INotificationHandler<BaseNotification>,
                                   INotificationHandler<ErrorNotification>
    {
        public Task Handle(BaseNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine($"Ambev {notification.Name} - Key({notification.Id}) was {notification.Action} successfully");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine($"ERROR : '{notification.Error} \n {notification.Stack}'");
            });
        }

    }
}
