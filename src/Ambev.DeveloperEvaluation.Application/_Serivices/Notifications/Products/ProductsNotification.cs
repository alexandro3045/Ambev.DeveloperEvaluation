
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Carts
{
    public class ProductsNotification : Domain.Entities.Product, INotification
    {
        public ActionNotification Action { get; set; }
    }
}
