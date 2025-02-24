using Ambev.DeveloperEvaluation.Application.Users.GetListUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.LisUsers;

/// <summary>
/// Profile for mapping GetListUser feature requests to commands
/// </summary>
public class GetListUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListUser feature
    /// </summary>
    public GetListUserProfile()
    {
        CreateMap<GetListUserRequest, GetListUserCommand>()
            .ConstructUsing(request => new GetListUserCommand(request.Page, request.Size, request.Order, request.Direction,
              request.ColumnFilters, request.SearchTerm));

        CreateMap<GetListUserResult, GetListUserResponse>();
    }
}
