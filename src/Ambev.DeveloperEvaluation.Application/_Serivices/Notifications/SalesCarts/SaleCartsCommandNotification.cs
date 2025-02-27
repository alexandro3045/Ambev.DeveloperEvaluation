using Ambev.DeveloperEvaluation.Application.SalesCarts.CreateSalesCarts;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Carts
{
    public class SaleCartsCommandNotification : CreateSalesCartsCommand, INotification { }
}
