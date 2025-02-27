
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base
{
    public class BaseNotification : Domain.Common.BaseEntity, INotification
    {
        public string Name { get; set; }

        public new Guid Id { get; set; }

        public ActionNotification Action { get; set; }
    }
}
