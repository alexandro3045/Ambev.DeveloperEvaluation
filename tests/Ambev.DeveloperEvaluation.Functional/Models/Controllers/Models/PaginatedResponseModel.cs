
namespace Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models
{
    public class PaginatedResponseModel<T>
    {
        public ResponseModel<T> Data { get; set; }
    }

    public class ResponseModel<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public T Data { get; set; }
    }
}
