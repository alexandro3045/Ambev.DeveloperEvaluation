using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.Carts
{

    public class CreateCartstHandlerTests
    {
        private readonly ICartsRepository _CartsRepository;
        private readonly IMapper _mapper;
        private readonly CreateCartsHandler _handler;

        public CreateCartstHandlerTests()
        {
            _CartsRepository = Substitute.For<ICartsRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateCartsHandler(_CartsRepository, _mapper);
            Setup();
        }
       
        private void Setup()
        {
            _CartsRepository.ClearReceivedCalls();
            _mapper.ClearReceivedCalls();
        }

        [Fact(DisplayName = "Given valid Carts data When creating Carts Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateCartstHandlerTestData.GenerateValidCommand();

            var Carts = new DeveloperEvaluation.Domain.Entities.Carts
            {
                Id = command.Id,
                CreatedAt = DateTime.Now,
                UserId = command.UserId,
                CartsProductsItems  = command.Products.Select(p=> 
                new CartsProductsItems 
                { CartId = p.CartId, ProductId = p.ProductId, Quantity = p.Quantity }).ToList()
            };

            var result = new CreateCartsResult {
                Id = Carts.Id,
                Date = Carts.CreatedAt,
                UserId = Carts.UserId,
                Products = Carts.CartsProductsItems.Select(p => new CartsProductsItems { CartId = p.CartId, ProductId = p.ProductId, Quantity = p.Quantity }).ToList()
            };

            _mapper.Map<DeveloperEvaluation.Domain.Entities.Carts>(command).Returns(Carts);

            _mapper.Map<CreateCartsResult>(Carts).Returns(result);

            _CartsRepository.CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.Carts>(), Arg.Any<CancellationToken>())
                .Returns(Carts);

            // When
            var response = await _handler.Handle(command, CancellationToken.None);
            
            // Then
            var createCartsResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createCartsResult.Should().NotBeNull();
            createCartsResult.Id.Should().Be(Carts.Id);
            await _CartsRepository.Received(2).CreateAsync(Arg.Any<DeveloperEvaluation.Domain.Entities.Carts>(), Arg.Any<CancellationToken>());
        }
    }
}
