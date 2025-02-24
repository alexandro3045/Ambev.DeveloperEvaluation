using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// Request model for getting a products by Page, size, Order, Direction
/// </summary>
public class GetListCategoriesRequest
{
    [JsonIgnore]
    /// <summary>
    /// The page ProductsItems list to retrieve
    /// </summary>
    public int Page { get; set; }

    [JsonIgnore]
    /// <summary>
    /// The size ProductsItems list to retrieve
    /// </summary>
    public int Size { get; set; }

    [JsonIgnore]
    /// <summary>
    /// The order ProductsItems list to retrieve
    /// </summary>
    public string? Order { get; set; } = "ASC";

    [JsonIgnore]
    /// <summary>
    /// The direction ProductsItems list to retrieve
    /// </summary>
    public string? Direction { get; set; } = default;
}
