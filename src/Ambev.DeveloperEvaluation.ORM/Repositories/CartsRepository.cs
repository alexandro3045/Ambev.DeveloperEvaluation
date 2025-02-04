using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class CartsRepository : Repository<Carts>, ICartsRepository
    {
        public CartsRepository(DefaultContext context) : base(context) { }
    }
}
