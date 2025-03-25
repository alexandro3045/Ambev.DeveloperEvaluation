using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Functional.Controllers;
using Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models;
using Ambev.DeveloperEvaluation.WebApi;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;
using Bogus;
using Store.SharedDatabaseSetup.Extensions;
using Newtonsoft.Json;
using Store.SharedDatabaseSetup;
using System.Text;
using Xunit;

namespace Store.FunctionalTests.Controllers
{
    public class ProductsControllerTests : BaseControllerTests
    {
        public ProductsControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetProducts_ReturnsAllRecords()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync("/api/Products/1,10,Title,asc");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(stringResponse).data;
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.totalCount == 10);
        }

        [Fact]
        public async Task GetProductById_ProductExists_ReturnsCorrectProduct()
        {
            var client = this.GetNewClient();

            var productId = DatabaseSetup.ProductsFaker.FirstOrDefault().Id;

            var response = await client.GetAsync($"/api/Products/{productId}");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponseWithData<Product>>(stringResponse).Data;

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.Equal(productId, result.Id);
            Assert.NotNull(result.Description);
            Assert.True(result.Price > 0);
            Assert.NotNull(result.Category);
            Assert.NotNull(result.Rating);
        }

        [Fact]
        public async Task GetProductById_ProductDoesntExist_ReturnsNotFound()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync($"/api/Products/{Guid.NewGuid()}");

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("NotFound", statusCode);
        }

        [Fact]
        public async Task PostProduct_ReturnsCreatedProduct()
        {
            var client = this.GetNewClient();

            // Create product

            var request = new CreateProductRequest
            {
                Price = new Faker().Random.Decimal(0.00m, 99.00m, 2),
                Category = $"Category {new Faker().Internet.DomainName()}",
                Description = $"Description {new Faker().Finance.AccountName()}",
                Image = new Faker().Image.ToString(),
                Title = $"Title {new Faker().Commerce.ProductName()}",
                Rating = new Rating { Count = new Faker().Random.Int(10), Rate = new Faker().Random.Decimal(0.00m, 99.00m, 2) }
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Products", stringContent);

            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<ApiResponseWithData<Product>>(stringResponse1).Data;
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);

            var response2 = await client.GetAsync($"/api/Products/{createdProduct.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<ApiResponseWithData<Product>>(stringResponse2).Data;
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdProduct.Id, result2.Id);
            Assert.Equal(createdProduct.Title, result2.Title);
            Assert.Equal(createdProduct.Description, result2.Description);
            Assert.Equal(createdProduct.Price, result2.Price);
            Assert.Equal(createdProduct.Category, result2.Category);
            Assert.Equal(createdProduct.Rating.Count, result2.Rating.Count);
            Assert.Equal(createdProduct.Rating.Rate, result2.Rating.Rate);
            Assert.Equal(createdProduct.Image, result2.Image);
        }

        [Fact]
        public async Task PostProduct_InvalidData_ReturnsErrors()
        {
            var client = this.GetNewClient();

            // Create product

            var request = new CreateProductRequest
            {
                Price = new Faker().Random.Decimal(0.00m, 99.00m, 2),
                Category = string.Empty,
                Description = string.Empty,
                Image = new Faker().Image.ToString(),
                Title = $"Title {new Faker().Commerce.ProductName()}",
                Rating = new Rating { Count = new Faker().Random.Int(10), Rate = new Faker().Random.Decimal(0.00m, 99.00m, 2) }
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Products", stringContent);

            var stringResponse = await response1.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);
            var statusCode = response1.StatusCode.ToString();

            Assert.Equal("BadRequest", statusCode);
            Assert.NotNull(badRequest.Errors);
            Assert.Equal(4, badRequest.Errors.Count());
            Assert.Contains(badRequest.Errors, e => e.Detail.Contains("Category"));
            Assert.Contains(badRequest.Errors, e => e.Detail.Contains("Description"));
        }

        [Fact]
        public async Task PutProduct_ReturnsUpdatedProduct()
        {
            var client = this.GetNewClient();

            var UpdateProductRequest = DatabaseSetup.ProductsFaker.FirstOrDefault();

            UpdateProductRequest.Title = "Updated Title";

            var stringContent = new StringContent(JsonConvert.SerializeObject(UpdateProductRequest), Encoding.UTF8, "application/json");

            var response1 = await client.PutAsync($"/api/Products", stringContent);
            
            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            
            var updatedProduct = JsonConvert.DeserializeObject<ApiResponseWithData<Product>>(stringResponse1).Data;
            
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("OK", statusCode1);

            Assert.Equal(UpdateProductRequest.Id, updatedProduct.Id);

            Assert.Equal(UpdateProductRequest.Title, updatedProduct.Title);
        }

        [Fact]
        public async Task DeleteProductById_ReturnsNotFound()
        {
            var client = this.GetNewClient();

            var productId = Guid.NewGuid();

            // Delete product

            var response1 = await client.DeleteAsync($"/api/Products/{productId}");

            var statusCode = response1.StatusCode.ToString();

            Assert.Equal("NotFound", statusCode);
         }
    }
}