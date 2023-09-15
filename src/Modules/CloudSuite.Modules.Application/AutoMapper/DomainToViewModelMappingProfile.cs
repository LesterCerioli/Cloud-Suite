using AutoMapper;
using CloudSuite.Modules.Application.ViewModels.Core;
using CloudSuite.Modules.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Address, AddressViewModel>();
            CreateMap<AppSetting, AppSettingViewModel>();
            CreateMap<City, CityViewModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Country, CountryViewModel>();
            CreateMap<District, DistrictViewModel>();
            CreateMap<Media, MediaViewModel>();
            CreateMap<RoboEmail, RoboEmailViewModel>();
            CreateMap<Role, RoleViewModel>();
            CreateMap<State, StateViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<Vendor, VendorViewModel>();
            CreateMap<Widget, WidgetViewModel>();
            CreateMap<WidgetInstance, WidgetInstanceViewModel>();
            CreateMap<WidgetZone, WidgetZoneViewModel>();


        }
    }
}
