using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class Product : BaseEntity
{
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }
    /// <summary>
    /// Gets the Title from product
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets the price from product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the description from product.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets the category from product.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets the image from product.
    /// </summary>
    public string Image { get; set; }

    [Column(TypeName = "jsonb")]
    public Rating Rating { get; set; }

    /// <summary>
    /// Gets the date and time when the products was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the produts information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Performs validation of the user entity using the UserValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Title format and length</list>
    /// <list type="bullet">price number format</list>
    /// <list type="bullet">Description </list>
    /// <list type="bullet">Category complexity requirements</list>
    /// <list type="bullet">Image validity</list>
    /// <list type="bullet">Rating validity</list>
    /// <list type="bullet">CareateAt validity</list>
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

}