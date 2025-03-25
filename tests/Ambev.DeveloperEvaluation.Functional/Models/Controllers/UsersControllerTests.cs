using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Functional.Controllers;
using Ambev.DeveloperEvaluation.Functional.Models.Controllers.Models;
using Ambev.DeveloperEvaluation.WebApi;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Bogus;
using Newtonsoft.Json;
using Store.SharedDatabaseSetup;
using System.Text;
using Xunit;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Store.FunctionalTests.Controllers
{
    public class UsersControllerTests : BaseControllerTests
    {
        public UsersControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetUsers_ReturnsAllRecords()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync("/api/Users/1,7,UserName,asc");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic> (stringResponse).data;
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.True(result.totalCount == 7);
        }

        [Fact]
        public async Task GetUserById_UserExists_ReturnsCorrectUser()
        {
            var client = this.GetNewClient();

            var UserId = DatabaseSetup.UsersFaker.FirstOrDefault().Id;

            var response = await client.GetAsync($"/api/Users/{UserId}");
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponseWithData<User>>(stringResponse).Data;

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("OK", statusCode);
            Assert.Equal(UserId, result.Id);
            Assert.NotNull(result.UserName);
            Assert.NotNull(result.Email);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Phone);
        }

        [Fact]
        public async Task GetUserById_UserDoesntExist_ReturnsNotFound()
        {
            var client = this.GetNewClient();
            var response = await client.GetAsync($"/api/Users/{Guid.NewGuid()}");

            var stringResponse = await response.Content.ReadAsStringAsync();

            var apiResposne = JsonConvert.DeserializeObject<ApiResponse>(stringResponse);            

            var statusCode = response.StatusCode.ToString();

            Assert.Equal("KeyNotFoundException", apiResposne.ErrorType);
        }

        [Fact]
        public async Task PostUser_ReturnsCreatedUser()
        {
            var client = this.GetNewClient();

            // Create User

            var faker = new Faker();
            var request = new CreateUserRequest
            {
                Username = faker.Internet.UserName(),
                Name = new Name { FirstName = faker.Name.FirstName(), LastName = faker.Name.LastName() },
                Password = $"Test@{ faker.Random.Number(100, 999) }",
                Email = faker.Internet.Email(),
                Phone = $"+55{ faker.Random.Number(11, 99)}{faker.Random.Number(100000000, 999999999)}",
                Status = faker.PickRandom(UserStatus.Active, UserStatus.Suspended),
                Role = faker.PickRandom(UserRole.Customer, UserRole.Admin),
                Address = new Address()
                {
                    City = faker.Address.City(),
                    Number = faker.Random.Number(100000000, 999999999).ToString(),
                    Geolocation = new Geolocation()
                    {
                        Lat = faker.Address.Latitude().ToString(),
                        Long = faker.Address.Longitude().ToString()
                    },
                    Street = faker.Address.StreetName(),
                    ZipCode = faker.Address.ZipCode()
                }
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response1 = await client.PostAsync("/api/Users", stringContent);

            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<ApiResponseWithData<User>>(stringResponse1).Data;
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("Created", statusCode1);

            var response2 = await client.GetAsync($"/api/Users/{createdUser.Id}");
            response2.EnsureSuccessStatusCode();

            var stringResponse2 = await response2.Content.ReadAsStringAsync();
            var result2 = JsonConvert.DeserializeObject<ApiResponseWithData<User>>(stringResponse2).Data;
            var statusCode2 = response2.StatusCode.ToString();

            Assert.Equal("OK", statusCode2);
            Assert.Equal(createdUser.Id, result2.Id);
            Assert.Equal(createdUser.UserName, result2.UserName);
            Assert.Equal(createdUser.Phone, result2.Phone);
            Assert.Equal(createdUser.Password, result2.Password);
            Assert.Equal(createdUser.Name.FirstName, result2.Name.FirstName);
            Assert.Equal(createdUser.Address.Number, result2.Address.Number);
            Assert.Equal(createdUser.Address.City, result2.Address.City);
            Assert.Equal(createdUser.Status, result2.Status);
        }

        [Fact]
        public async Task PostUser_InvalidData_ReturnsErrors()
        {
            var client = this.GetNewClient();

            // Create User

            var faker = new Faker();
            var request = new CreateUserRequest
            {
                Username = string.Empty,
                Name = new Name { FirstName = faker.Name.FirstName(), LastName = faker.Name.LastName() },
                Password = string.Empty,
                Email = faker.Internet.Email(),
                Phone = $"+55{faker.Random.Number(11, 99)}{faker.Random.Number(100000000, 999999999)}",
                Status = faker.PickRandom(UserStatus.Active, UserStatus.Suspended),
                Role = faker.PickRandom(UserRole.Customer, UserRole.Admin),
                Address = new Address()
                {
                    City = faker.Address.City(),
                    Number = faker.Random.Number(100000000, 999999999).ToString(),
                    Geolocation = new Geolocation()
                    {
                        Lat = faker.Address.Latitude().ToString(),
                        Long = faker.Address.Longitude().ToString()
                    },
                    Street = faker.Address.StreetName(),
                    ZipCode = faker.Address.ZipCode()
                }
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/Users", stringContent);

            var stringResponse = await response.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);
            var statusCode = response.StatusCode.ToString();

            Assert.Equal("BadRequest", statusCode);
            Assert.NotNull(badRequest.Errors);
            Assert.Equal(8, badRequest.Errors.Count());
            Assert.Contains(badRequest.Errors, e => e.Detail.Contains("Username"));
            Assert.Contains(badRequest.Errors, e => e.Detail.Contains("Password"));
        }

        [Fact]
        public async Task PutUser_ReturnsUpdatedUser()
        {
            var client = this.GetNewClient();

            var UpdateUserRequest = DatabaseSetup.UsersFaker.FirstOrDefault();

            UpdateUserRequest.UserName = "Updated UserName";

            var stringContent = new StringContent(JsonConvert.SerializeObject(UpdateUserRequest), Encoding.UTF8, "application/json");

            var response1 = await client.PutAsync($"/api/Users", stringContent);
            
            response1.EnsureSuccessStatusCode();

            var stringResponse1 = await response1.Content.ReadAsStringAsync();
            
            var updatedUser = JsonConvert.DeserializeObject<ApiResponseWithData<User>>(stringResponse1).Data;
            
            var statusCode1 = response1.StatusCode.ToString();

            Assert.Equal("OK", statusCode1);

            Assert.Equal(UpdateUserRequest.Id, updatedUser.Id);

            Assert.Equal(UpdateUserRequest.UserName, updatedUser.UserName);
        }

        [Fact]
        public async Task DeleteUserById_ReturnsNotFound()
        {
            var client = this.GetNewClient();

            var UserId = Guid.NewGuid();

            // Delete User

            var response = await client.DeleteAsync($"/api/Users/{UserId}");

            var stringResponse = await response.Content.ReadAsStringAsync();

            var badRequest = JsonConvert.DeserializeObject<BadRequestModel>(stringResponse);

            Assert.Equal("KeyNotFoundException", badRequest.ErrorType);
         }
    }
}