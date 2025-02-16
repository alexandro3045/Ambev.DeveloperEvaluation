using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartsProductsItemsRepository : Repository<CartsProductsItems>, ICartsProductsItemsRepository
    {
        public CartsProductsItemsRepository(DefaultContext context) : base(context) { }
    }
}
