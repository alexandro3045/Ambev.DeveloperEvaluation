using Ambev.DeveloperEvaluation.Application.Carts.CreateCarts;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications.Base;
using Ambev.DeveloperEvaluation.Application.Serivices.Notifications;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCarts;

/// <summary>
/// Profile for mapping between Carts entity and DeleteCartsResponse
/// </summary>
public class DeleteCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteCarts operation
    /// </summary>
    public DeleteCartsProfile()
    {
        CreateMap<Domain.Entities.Carts, BaseNotification>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().Name))
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.Action, opt => opt.MapFrom(src => ActionNotification.Deleted));

    }
}
