
namespace Ambev.DeveloperEvaluation.WebApi.Features.Branch.CreateBranchRequest;

/// <summary>
/// Represents a request to create a new products in the system.
/// </summary>
public class CreateBranchRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the description from branch.
    /// </summary>
    public string Descripption { get; set; }

    /// <summary>
    /// Gets the date and time when the branch was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the branch information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

}
