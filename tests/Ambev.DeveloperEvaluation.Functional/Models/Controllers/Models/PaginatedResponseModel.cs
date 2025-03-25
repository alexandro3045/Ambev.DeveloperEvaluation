
namespace Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models
{
    public class PaginatedResponseModel<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
