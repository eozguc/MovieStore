using System.Linq;
using AutoMapper;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;
using MovieStoreWebApi.DTo.Actor.ActorViews;
using MovieStoreWebApi.DTo.Customer.CustomerCrudModels;
using MovieStoreWebApi.DTo.Customer.CustomerViews;
using MovieStoreWebApi.DTo.Director.DirectorCrudModels;
using MovieStoreWebApi.DTo.Director.DirectorViews;
using MovieStoreWebApi.DTo.Genre.GenreCrudModels;
using MovieStoreWebApi.DTo.Genre.GenreViews;
using MovieStoreWebApi.DTo.Movie.MovieCrudModels;
using MovieStoreWebApi.DTo.Movie.MovieViews;
using MovieStoreWebApi.DTo.MovieAndActor.MoviesActorCrudModels;
using MovieStoreWebApi.DTo.Order.OrderCrudModels;
using MovieStoreWebApi.DTo.Order.OrderViews;
using MovieStoreWebApi.Entities;
using MovieStoreWebApi.Application.UserOperations.Command.CreateUser;

namespace MovieStoreWebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Movie,MovieDetailViewModel>()
            .ForMember(x=>x.Director, opt => opt.MapFrom(d=>d.Director.Name +" "+d.Director.SurName))
            .ForMember(x=>x.ActorViewModels, opt=>opt.
                MapFrom(a=>a.Actors.Select(a=>a.Actor).ToList()))
            .ForMember(m=>m.Genre, opt => opt.MapFrom(g=>g.Genre.Name));

            CreateMap<Movie,MovieViewModel>()
            .ForMember(x=>x.Director, opt => opt.MapFrom(src=>src.Director.Name +" "+src.Director.SurName))
            .ForMember(x=>x.ActorViewModels, opt=>opt.
                MapFrom(a=>a.Actors.Select(a=>a.Actor).ToList()))
            .ForMember(x=>x.Genre, opt => opt.MapFrom(g=>g.Genre.Name));

            CreateMap<Movie,MovieTemplateViewModel>();
            
            CreateMap<Actor,ActorViewModel>()
            .ForMember(x=>x.Name, opt=>opt.MapFrom(src=>src.Name))
            .ForMember(x=>x.SurName, opt=>opt.MapFrom(src=>src.SurName));

            CreateMap<CreateMovieModel,Movie>();
            
            CreateMap<CreateUserModel,User>();
            CreateMap<CreateActorModel,Actor>();
            CreateMap<Actor,ActorViewModel>();
            CreateMap<Actor,ActorDetailViewModel>();
            CreateMap<CreateNewMoviesActor,MoviesActor>();

            
            CreateMap<CreateGenreModel,Genre>();
            CreateMap<Genre,GenreViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<CreateDirectorModel,Director>();
            CreateMap<Director,DirectorViewModel>();
            CreateMap<Director,DirectorDetailViewModel>()
            .ForMember(x=>x.MovieTemplateViewModels,opt=>opt.MapFrom(src=>src.DiretoredMovies.Select(m=>m.Movie).ToList()));

            CreateMap<CreateCustomerModel,Customer>();

            CreateMap<Customer,CustomerDetailViewModel>()
            .ForMember(x=>x.CustomerMovies,
            opt=>opt.MapFrom(cm=>cm.CustomerMovies.Select(m=>m.Movie).ToList()))
            .ForMember(x=>x.CustomerGenres,
            opt=>opt.MapFrom(c=>c.CustomerGenres.Select(g=>g.Genre).ToList()));

            CreateMap<Customer,CustomerViewModel>();
            
            CreateMap<Order,OrderViewModel>()
            .ForMember(x=>x.Movie,opt=>opt.MapFrom(m=>m.Movie))
            .ForMember(x=>x.Customer,opt=>opt.MapFrom(c=>c.Customer));
            CreateMap<Order,OrderDetailViewModel>()
            .ForMember(x=>x.Movie,opt=>opt.MapFrom(m=>m.Movie))
            .ForMember(x=>x.Customer,opt=>opt.MapFrom(c=>c.Customer));;
            CreateMap<UpdateOrderModel,Order>();
            CreateMap<CreateOrderModel,Order>();
        }
        
    }
}