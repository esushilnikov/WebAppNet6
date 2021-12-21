using Application.Features.User.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAccount, UserDetailsVm>();
        }
    }
}
