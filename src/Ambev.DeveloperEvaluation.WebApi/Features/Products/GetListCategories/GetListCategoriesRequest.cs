using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;

/// <summary>
/// Request model for getting a products by Page, size, Order, Direction
/// </summary>
public class GetListCategoriesRequest
{
    [JsonIgnore]
    /// <summary>
    /// The page Products list to retrieve
    /// </summary>
    public int Page { get; set; }

    [JsonIgnore]
    /// <summary>
    /// The size Products list to retrieve
    /// </summary>
    public int Size { get; set; }

    [JsonIgnore]
    /// <summary>
    /// The order Products list to retrieve
    /// </summary>
    public string? Order { get; set; } = "ASC";

    [JsonIgnore]
    /// <summary>
    /// The direction Products list to retrieve
    /// </summary>
    public string? Direction { get; set; } = default;
}
