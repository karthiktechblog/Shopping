using AutoMapper;
using KarthikTechBlog.Shopping.API.ViewModel;
using KarthikTechBlog.Shopping.Core;

namespace KarthikTechBlog.Shopping.API
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductViewModel>(); //source, destination
        }
    }
}
