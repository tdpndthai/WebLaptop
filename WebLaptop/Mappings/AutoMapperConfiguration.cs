using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLaptop.Models;
using WebLaptop_Model.Models;

namespace WebLaptop.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //var config = new MapperConfiguration(cfg =>
            //  {
            //      cfg.CreateMap<Post, PostViewModel>();
            //  });
            //IMapper mapper = config.CreateMapper();
            //var source = new Post();
            //var dest = mapper.Map<Post, PostViewModel>(source);
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<PostTag, PostTagViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            Mapper.CreateMap<Footer, FooterViewModel>();
            Mapper.CreateMap<Slide, SlideViewModel>();
            Mapper.CreateMap<Page, PageViewModel>();
            Mapper.CreateMap<ContactDetail, ContactDetailViewModel>();
        }
    }
}