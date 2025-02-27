using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Carts
{

    public class SalesCartsNotification : Domain.Entities.SalesCarts, INotification
    {
        public ActionNotification Action { get; set; }
    }
}
