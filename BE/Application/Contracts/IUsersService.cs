
using Application.DTO.User.Request;
using Domain.Entities.User;
using Domain.Results;

namespace Application.Contracts
{
    public interface IUsersService
    {
         Response<string> UpdateContactInfo( UpdateContactInfoRequest request);

       
    }
}
