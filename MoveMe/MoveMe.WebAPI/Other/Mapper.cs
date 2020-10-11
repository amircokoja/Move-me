using AutoMapper;
using MoveMe.Model;
using MoveMe.Model.Requests;

namespace MoveMe.WebAPI.Other
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Country, Country>();
            CreateMap<CountryUpsertRequest, Database.Country>();

            CreateMap<Database.Address, Address>();
            CreateMap<AddressUpsertRequest, Database.Address>();

            CreateMap<Database.Request, Request>();
            CreateMap<RequestInsertRequest, Database.Request>();
            CreateMap<RequestUpdateRequest, Database.Request>();

            CreateMap<Database.User, User>();
            CreateMap<UserUpdateRequest, Database.User>();

            CreateMap<Database.Status, Status>();
        }
    }

}
