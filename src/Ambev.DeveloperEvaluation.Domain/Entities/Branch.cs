using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Branch : BaseEntity
{
    public Branch()
    {
        CreatedAt = DateTime.UtcNow;
    }

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

    /// <summary>
    /// Gets list to the SalesCarts
    /// </summary>
    public List<SalesCarts> SalesCarts { get; set; }

}