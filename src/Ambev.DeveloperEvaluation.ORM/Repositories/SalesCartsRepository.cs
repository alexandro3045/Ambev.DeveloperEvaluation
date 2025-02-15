using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SalesCartsRepository : Repository<Carts>, ISalesCartsRepository
    {
        public SalesCartsRepository(DefaultContext context) : base(context) { }
    }
}
