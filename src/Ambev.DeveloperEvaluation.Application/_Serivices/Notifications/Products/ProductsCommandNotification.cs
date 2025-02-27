using Ambev.DeveloperEvaluation.Application.Productss.CreateProducts;
using MediatR;
namespace Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Carts
{
    public class ProductsCommandNotification : CreateProductsCommand, INotification { }
}
