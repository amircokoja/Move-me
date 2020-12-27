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

            CreateMap<Database.Address, Address>();
            CreateMap<AddressUpsertRequest, Database.Address>();

            CreateMap<Database.Rating, Rating>();
            CreateMap<RatingUpsertRequest, Database.Rating>();

            CreateMap<Database.Request, Request>();
            CreateMap<RequestInsertRequest, Database.Request>();
            CreateMap<RequestUpdateRequest, Database.Request>();

            CreateMap<Database.Offer, Offer>();
            CreateMap<OfferInsertRequest, Database.Offer>();
            CreateMap<OfferUpdateRequest, Database.Offer>();

            CreateMap<Database.Notification, Notification>();
            CreateMap<NotificationInsertRequest, Database.Notification>();
            CreateMap<NotificationUpdateRequest, Database.Notification>();

            CreateMap<Database.User, User>();
            CreateMap<UserUpdateRequest, Database.User>();

            CreateMap<Database.OfferStatus, OfferStatus>();

            CreateMap<Database.Status, Status>();
            CreateMap<Database.RatingType, RatingType>();
        }
    }
}
