using Ambev.DeveloperEvaluation.Functional.Controllers;
using Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models;
using Ambev.DeveloperEvaluation.WebApi;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Bogus;
using Newtonsoft.Json;
using Store.SharedDatabaseSetup;
using System.Text;
using Xunit;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CartsRequests;

namespace Store.FunctionalTests.Controllers
{
    public class CartsControllerTests : BaseControllerTests
    {
        public CartsControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetCarts_ReturnsAllRecords()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync("/api/Carts/1,10,UserId,asc");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<dynamic>(stringResponse).data;

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.totalCount == 10);
        }

        /*
        [Fact]
        public async Task GetProductById_ProductExists_ReturnsCorrectProduct()
        {
            var client = this.GetNewClient();

            var productId = DatabaseSetup.CartsFaker.FirstOrDefault().Id;

            var response = await client.GetAsync($"/api/Carts/{productId}");
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
        */

        [Fact]
        public async Task GetById_DoesntExist_ReturnsNotFound()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync($"/api/Carts/{Guid.NewGuid()}");

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("NotFound", statusCode);
        }

        [Fact]
        public async Task Post_ReturnsCreatedCarts()
        {
            var client = this.GetNewClient();

            // Create carts
            var Carts = new CartsRequest
            {
                Date = DateTime.Now,
                UserId = Guid.NewGuid().ToString(),
                Products = DatabaseSetup.ProductsFaker.ToList().Select(p => new ItemProduct(p.Id, new Faker().Random.Int(10))).ToList()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(Carts), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/Carts", stringContent);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var createdCarts= JsonConvert.DeserializeObject<ApiResponseWithData<CartsResponse>>(stringResponse).Data;
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("Created", statusCode);

            var response2 = await client.GetAsync($"/api/Carts/{createdCarts.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<ApiResponseWithData<CartsResponse>>(stringResponse2).Data;
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdCarts.Id, result2.Id);
            Assert.Equal(createdCarts.UserId, result2.UserId);
            Assert.Equal(createdCarts.Products, result2.Products);
        }

        [Fact]
        public async Task Post_InvalidData_ReturnsErrors()
        {
            var client = this.GetNewClient();

            // Create Carts

            var Carts = new CartsRequest
            {
                Date = DateTime.Now,
                UserId = string.Empty,
                Products = DatabaseSetup.ProductsFaker.ToList().Select(p => new ItemProduct(p.Id, new Faker().Random.Int(10))).ToList()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(Carts), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Carts", stringContent);

            var stringResponse = await response1.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);
            var statusCode = response1.StatusCode.ToString();

            Assert.Equal("BadRequest", statusCode);
            Assert.NotNull(badRequest.Errors);
            Assert.Equal(1, badRequest.Errors.Count());
            Assert.Contains(badRequest.Errors, e => e.Detail.Contains("User Id"));
        }
        
        [Fact]
        public async Task Put_ReturnsUpdated()
        {
            var client = GetNewClient();

            var UpdateRequest = DatabaseSetup.CartsFaker.FirstOrDefault();

            var cartsRequest = new CartsRequest
            {
                Id = UpdateRequest.Id,
                Date = DateTime.Now,
                UserId = UpdateRequest.UserId ,
                Products = UpdateRequest.CartsProductsItems.Select(p => new ItemProduct(p.ProductId, p.Quantity)).ToList()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(cartsRequest), Encoding.UTF8, "application/json");

            var responseUpdate = await client.PutAsync($"/api/Carts", stringContent);

            responseUpdate.EnsureSuccessStatusCode();

            var stringContentUpdate = await responseUpdate.Content.ReadAsStringAsync();

            var updated = JsonConvert.DeserializeObject<ApiResponseWithData<CartsResponse>>(stringContentUpdate)?.Data;

            var statusCode1 = responseUpdate.StatusCode.ToString();

            Assert.Equal("OK", statusCode1);

            Assert.Equal(UpdateRequest.Id, updated.Id);

            Assert.Equal(cartsRequest.Date, updated.Date);
        }
       
        [Fact]
        public async Task DeleteById_ReturnsNotFound()
        {
            var client = this.GetNewClient();

            var id = Guid.NewGuid();

            // Delete by Id

            var response = await client.DeleteAsync($"/api/Carts/{id}");

            var stringResponse = await response.Content.ReadAsStringAsync();

            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);

            Assert.Equal("KeyNotFoundException", badRequest.ErrorType);
         }

        
    }
}