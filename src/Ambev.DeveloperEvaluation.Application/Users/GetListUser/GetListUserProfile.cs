using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.GetListUser;

/// <summary>
/// Profile for mapping between User entity and GetListUserResult
/// </summary>
public class GetListUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetListUser operation
    /// </summary>
    public GetListUserProfile()
    {
        CreateMap<List<User>?, GetListUserResult>()
            .ConstructUsing(listUser => new GetListUserResult(listUser));
    }
}
