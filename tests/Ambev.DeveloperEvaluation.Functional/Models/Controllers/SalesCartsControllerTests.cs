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
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesCarts.SalesCartsRequests;
using Ambev.DeveloperEvaluation.WebApi.SalesCarts.GetSalesCarts;

namespace Store.FunctionalTests.Controllers
{
    public class SalesCartsControllerTests : BaseControllerTests
    {
        public SalesCartsControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
 
        }

        [Fact]
        public async Task Get_ReturnsAllRecords()
        {
            var Client = GetNewClient();

            var response = await Client.GetAsync("/api/SalesCarts/1,10,UserId,asc");

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<dynamic>(stringResponse)?.data;

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);

            Assert.True(result?.totalCount == 10);
        }
        
        [Fact]
        public async Task GetById_Exists_ReturnsCorrect()
        {
            var Client = GetNewClient();

            var salesCart = DatabaseSetup.SalesCartsFaker.FirstOrDefault();

            var response = await Client.GetAsync($"/api/SalesCarts/{salesCart.Id}");

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponseWithData<SalesCarts>>(stringResponse).Data;

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.NotNull(result.SalesNumber);
            Assert.NotNull(result.CreatedAt);
            Assert.NotNull(result.UserId);
            Assert.True(result.TotalSalesAmount > 0);
            Assert.NotNull(result.BranchId);
            Assert.NotNull(result.Carts.CartsProductsItems);
            Assert.True(result.Quantities > 0);
            Assert.NotNull(result.Carts.CartsProductsItems.Select(cp=>cp.UnitPrice));
            Assert.NotNull(result.Carts.CartsProductsItems.Select(cp => cp.Discounts));
            Assert.NotNull(result.Carts.CartsProductsItems.Select(cp => cp.TotalAmountItem));
            Assert.NotNull(result.Carts.CartsProductsItems.Select(cp => cp.Canceled));

        }

        [Fact]
        public async Task GetById_DoesntExist_ReturnsNotFound()
        {
            var Client = GetNewClient();

            var response = await Client.GetAsync($"/api/Carts/{Guid.NewGuid()}");

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("NotFound", statusCode);
        }

        [Fact]
        public async Task Post_ReturnsCreated()
        {
            var Client = GetNewClient();

            // Create SalesCarts
            var salesCarts = new SalesCartsRequest
            {
                Date = DateTime.Now,
                UserId = Guid.NewGuid().ToString(),
                Carts = new CartsRequest
                {
                    Date = DateTime.Now,
                    UserId = User.Id.ToString(),
                    Products = DatabaseSetup.ProductsFaker.ToList().Select(p => new ItemProduct(p.Id, new Faker().Random.Int(10))).ToList()
                },
                BranchId = Branch.Id,
                salesNumber = new Faker().Random.Int(1000),
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(salesCarts), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("/api/SalesCarts", stringContent);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            var data =JsonConvert.DeserializeObject<dynamic>(stringResponse).data;

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("Created", statusCode);

            string uri = $"/api/SalesCarts/SalesNumber={data.salesNumber},null";

            var response2 = await Client.GetAsync(uri);
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<PaginatedResponseModel<GetSalesCartsResponse>>(stringResponse2).Data;
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.NotNull(result2.Data.SalesNumber);
            Assert.NotNull(result2.Data.UserId);
            Assert.True(result2.Data.TotalSalesAmount > 0);
            Assert.NotNull(result2.Data.BranchId);
            Assert.NotNull(result2.Data.Products);
            Assert.True(result2.Data.Quantities > 0);
            Assert.NotNull(result2.Data.Products.Select(cp => cp.UnitPrice));
            Assert.NotNull(result2.Data.Products.Select(cp => cp.Discounts));
            Assert.NotNull(result2.Data.Products.Select(cp => cp.TotalAmountItem));
            Assert.NotNull(result2.Data.Products.Select(cp => cp.Canceled));
            
        }

        [Fact]
        public async Task Post_InvalidData_ReturnsErrors()
        {
            var Client = GetNewClient();

            // Create SalesCarts
            var salesCarts = new SalesCartsRequest
            {
                Date = DateTime.Now,
                UserId = string.Empty,
                Carts = new CartsRequest
                {
                    Date = DateTime.Now,
                    UserId = User.Id.ToString(),
                    Products = DatabaseSetup.ProductsFaker.ToList().Select(p => new ItemProduct(p.Id, new Faker().Random.Int(10))).ToList()
                },
                BranchId = Guid.Empty,
                salesNumber = new Faker().Random.Int(1000),
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(salesCarts), Encoding.UTF8, "application/json");

            var response1 = await Client.PostAsync("/api/SalesCarts", stringContent);

            var stringResponse = await response1.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);
            var statusCode = response1.StatusCode.ToString();

            Assert.Equal("BadRequest", statusCode);
            Assert.NotNull(badRequest.Errors);
            Assert.Equal(1, badRequest.Errors.Count());
            Assert.Contains(badRequest.Errors, e => e.Detail.Contains("User Id") && e.Detail.Contains("Branch Id"));
        }
        
        [Fact]
        public async Task Put_ReturnsUpdated()
        {
            var Client = GetNewClient();

            var UpdateRequest = DatabaseSetup.SalesCartsFaker.FirstOrDefault();

            var salesCarts = new SalesCartsRequest
            {
                Date = DateTime.Now,
                UserId = string.Empty,
                Carts = new CartsRequest
                {
                    Date = DateTime.Now,
                    UserId = User.Id.ToString(),
                    Products = DatabaseSetup.ProductsFaker.ToList().Select(p => new ItemProduct(p.Id, new Faker().Random.Int(10))).ToList()
                },
                BranchId = Guid.Empty,
                salesNumber = new Faker().Random.Int(1000),
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(salesCarts), Encoding.UTF8, "application/json");

            var responseUpdate = await Client.PutAsync($"/api/Carts", stringContent);

            responseUpdate.EnsureSuccessStatusCode();

            var stringContentUpdate = await responseUpdate.Content.ReadAsStringAsync();

            var updated = JsonConvert.DeserializeObject<ApiResponseWithData<CartsResponse>>(stringContentUpdate)?.Data;

            var statusCode1 = responseUpdate.StatusCode.ToString();

            Assert.Equal("OK", statusCode1);

            Assert.Equal(UpdateRequest.Id, updated.Id);

            Assert.Equal(salesCarts.Date, updated.Date);
        }
       
        [Fact]
        public async Task DeleteById_ReturnsNotFound()
        {
            var Client = GetNewClient();

            var id = Guid.NewGuid();

            // Delete by Id

            var response = await Client.DeleteAsync($"/api/SalesCarts/{id}");

            var stringResponse = await response.Content.ReadAsStringAsync();

            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);

            Assert.Equal("KeyNotFoundException", badRequest.ErrorType);
         }
    }
}