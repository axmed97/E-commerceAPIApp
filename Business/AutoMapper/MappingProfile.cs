using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.OrderDTOs;
using Entities.DTOs.ProductDTOs;
using Entities.DTOs.SpecificationDTOs;
using Entities.DTOs.UserDTOs;
using Entities.DTOs.WishListDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryCreateDTO, Category>().ReverseMap();
            CreateMap<CategoryUpdateDTO, Category>().ReverseMap();
            CreateMap<Category, CategoryHomeNavbarDTO>().ReverseMap();
            CreateMap<Category, CategoryFeaturedDTO>()
                .ForMember(x => x.ProductCount, o => o.MapFrom(s => s.Products.Where(p => p.CategoryId == s.Id).Count()));
            CreateMap<Category, CategoryAdminListDTO>().ReverseMap();

            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<User, UserOrderDTO>()
                .ForMember(x => x.OrderUserDTOs, o => o.MapFrom(s => s.Orders));

            CreateMap<ProductCreateDTO, Product>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>().ReverseMap();
            CreateMap<Product, ProductFeaturedDTO>().ReverseMap();
            CreateMap<Product, ProductRecentDTO>().ReverseMap();
            CreateMap<Product, ProductFilterDTO>().ReverseMap();

            CreateMap<SpecificationAddDTO, Specification>().ReverseMap();
            CreateMap<Specification, SpecificationListDTO>().ReverseMap();

            CreateMap<WishListAddItemDTO, WishList>().ReverseMap();
            CreateMap<WishList, WishListItemDTO>()
                .ForMember(x => x.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(x => x.Price, o => o.MapFrom(s => s.Product.Price));


            

            CreateMap<OrderCreateDTO,  Order>().ReverseMap();
            CreateMap<Order, OrderUserDTO>()
                .ForMember(x => x.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(x => x.Price, o => o.MapFrom(s => s.Product.Price))
                .ForMember(x => x.OrderEnum, o => o.MapFrom(s => Enum.GetName(s.OrderEnum)));


        }
    }
}
