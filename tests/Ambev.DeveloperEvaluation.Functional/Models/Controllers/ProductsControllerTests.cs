using Ambev.DeveloperEvaluation.Application.Products.GetListProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Functional.Controllers;
using Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models;
using Ambev.DeveloperEvaluation.WebApi;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetListProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Bogus;
using Newtonsoft.Json;
using System.Text;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

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
            var response = await client.GetAsync("/api/Products");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<GetListProductResponse>>(stringResponse).ToList();
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.Count == 10);
        }

        [Fact]
        public async Task GetProductById_ProductExists_ReturnsCorrectProduct()
        {
            var productId = Guid.NewGuid();
            var client = this.GetNewClient();
            var response = await client.GetAsync($"/api/Products/{productId}");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetProductsResponse>(stringResponse);
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.Equal(productId, result.Id);
            Assert.NotNull(result.Description);
            Assert.True(result.Price > 0);
            Assert.NotNull(result.Category);
            Assert.NotNull(result.Rating);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(20)]
        public async Task GetProductById_ProductDoesntExist_ReturnsNotFound(int productId)
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync($"/api/Products/{productId}");

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
                Price = new Faker().Random.Decimal(0.00m, 99.00m),
                Category = $"Category {new Faker().Internet.DomainName()}",
                Description = $"Description {new Faker().Finance.AccountName()}",
                Image = new Faker().Image.ToString(),
                Title = $"Title {new Faker().Commerce.ProductName()}",
                Rating = new Rating { Count = new Faker().Random.Int(10), Rate = new Faker().Random.Decimal(0.00m, 99.00m) }
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Products", stringContent);

            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<CreateProductsResponse>(stringResponse1);
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);


            var response2 = await client.GetAsync($"/api/Products/{createdProduct.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<CreateProductsResponse>(stringResponse2);
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdProduct.Id, result2.Id);
            Assert.Equal(createdProduct.Title, result2.Title);
            Assert.Equal(createdProduct.Description, result2.Description);
            Assert.Equal(createdProduct.Price, result2.Price);
            Assert.Equal(createdProduct.Category, result2.Category);
            Assert.Equal(createdProduct.Rating, result2.Rating);
            Assert.Equal(createdProduct.Image, result2.Image);
        }

        [Fact]
        public async Task PostProduct_InvalidData_ReturnsErrors()
        {
            var client = this.GetNewClient();

            // Create product

            var request = new CreateProductRequest
            {
                Price = new Faker().Random.Decimal(0.00m, 99.00m),
                Category = string.Empty,
                Description = string.Empty,
                Image = new Faker().Image.ToString(),
                Title = $"Title {new Faker().Commerce.ProductName()}",
                Rating = new Rating { Count = new Faker().Random.Int(10), Rate = new Faker().Random.Decimal(0.00m, 99.00m) }
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Products", stringContent);

            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdProduct = JsonConvert.DeserializeObject<CreateProductsResponse>(stringResponse1);
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);

            // Get created product

            var response2 = await client.GetAsync($"/api/Products/{createdProduct.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse = await response2.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);
            var statusCode = response2.StatusCode.ToString();

            Assert.Equal("BadRequest", statusCode);
            Assert.NotNull(badRequest.Title);
            Assert.NotNull(badRequest.Errors);
            Assert.Equal(2, badRequest.Errors.Count);
            Assert.Contains(badRequest.Errors.Keys, k => k == "Category");
            Assert.Contains(badRequest.Errors.Keys, k => k == "Description");
        }


        [Fact]
        public async Task PutProduct_ReturnsUpdatedProduct()
        {
            var client = this.GetNewClient();

            var response = await client.GetAsync("/api/Products");

            var stringResponse = await response.Content.ReadAsStringAsync();
            
            var UpdateProductRequest = JsonConvert.DeserializeObject<IEnumerable<GetListProductResponse>>(stringResponse).Single().ListProduct.First();

            var stringContent = new StringContent(JsonConvert.SerializeObject(UpdateProductRequest), Encoding.UTF8, "application/json");

            var response1 = await client.PutAsync($"/api/Products", stringContent);
            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var updatedProduct = JsonConvert.DeserializeObject<UpdateProductResponse>(stringResponse1);
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("OK", statusCode1);
        }

        [Fact]
        public async Task DeleteProductById_ReturnsNoContent()
        {
            var client = this.GetNewClient();
            var productId = 5;

            // Delete product

            var response1 = await client.DeleteAsync($"/api/Products/{productId}");

            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("NoContent", statusCode1);

            // Get deleted product

            var response2 = await client.GetAsync($"/api/Products/{productId}");

            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("NotFound", statusCode2);
        }
    }
}