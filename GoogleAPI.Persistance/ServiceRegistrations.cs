
using GoogleAPI.Persistance;
using GoogleAPI.Persistance.Concreates.Services.Authentication;
using GoogleAPI.Persistance.Concreates.Services.Authorization;
using GoogleAPI.Persistance.Concreates.Services.CargoService;
using GoogleAPI.Persistance.Concreates.Services.CargoService.Aras;
using GoogleAPI.Persistance.Concreates.Services.CargoService.Mng;
using GoogleAPI.Persistance.Concreates.Services.CargoService.Yurtiçi;
using GoogleAPI.Persistance.Concreates.Services.CategoriesService;
using GoogleAPI.Persistance.Concreates.Services.ColorsService;
using GoogleAPI.Persistance.Concreates.Services.Configuration;
using GoogleAPI.Persistance.Concreates.Services.DimensionsService;
using GoogleAPI.Persistance.Concreates.Services.FileUploadService;
using GoogleAPI.Persistance.Concreates.Services.Helper;
using GoogleAPI.Persistance.Concreates.Services.IyzcoPayment;
using GoogleAPI.Persistance.Concreates.Services.Mail;
using GoogleAPI.Persistance.Concreates.Services.MarketPlace;
using GoogleAPI.Persistance.Concreates.Services.Order;
using GoogleAPI.Persistance.Concreates.Services.PersonalsService;
using GoogleAPI.Persistance.Concreates.Services.Raport;
using GoogleAPI.Persistance.Concreates.Services.Role;
using GoogleAPI.Persistance.Concreates.Services.Supplier;
using GoogleAPI.Persistance.Concreates.Services.UserAndAuthentication;
using GoogleAPI.Persistance.Contexts;
using GoogleAPI.Persistance.Repositories;
using GoogleAPI.Persistance.Repositories.UserAndCommunication;
using GoogleAPI.Persistance.Services.BrandsService;
using GooleAPI.Application.Abstractions.IServices.Authorization;
using GooleAPI.Application.Abstractions.IServices.Common;
using GooleAPI.Application.Abstractions.IServices.Configuration;
using GooleAPI.Application.Abstractions.IServices.FileUploadService;
using GooleAPI.Application.Abstractions.IServices.IAuthentication;
using GooleAPI.Application.Abstractions.IServices.IBrand;
using GooleAPI.Application.Abstractions.IServices.ICargo;
using GooleAPI.Application.Abstractions.IServices.ICargo.IAras;
using GooleAPI.Application.Abstractions.IServices.ICargo.IMng;
using GooleAPI.Application.Abstractions.IServices.ICargo.IYurtiçi;
using GooleAPI.Application.Abstractions.IServices.ICategory;
using GooleAPI.Application.Abstractions.IServices.IColor;
using GooleAPI.Application.Abstractions.IServices.IDimention;
using GooleAPI.Application.Abstractions.IServices.IHelper;
using GooleAPI.Application.Abstractions.IServices.IMail;
using GooleAPI.Application.Abstractions.IServices.IMarketPlace;
using GooleAPI.Application.Abstractions.IServices.IOrder;
using GooleAPI.Application.Abstractions.IServices.IPersonal;
using GooleAPI.Application.Abstractions.IServices.IProduct;
using GooleAPI.Application.Abstractions.IServices.ISupplier;
using GooleAPI.Application.Abstractions.IServices.IUser;
using GooleAPI.Application.Abstractions.IServices.IyzcoPayment;
using GooleAPI.Application.Abstractions.IServices.Role;
using GooleAPI.Application.IRepositories;
using GooleAPI.Application.IRepositories.Raport;
using GooleAPI.Application.IRepositories.UserAndCommunication;
using GooleAPI.Persistance.Services.ProductsService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TranslateService = GoogleAPI.Persistance.Concreates.Services.Common.TranslateService;

namespace GooleAPI.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {

            services.AddDbContext<GooleAPIDbContext>(
                options => options.UseSqlServer(Configuration.ConnectionString)
            );

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IColorReadRepository, ColorReadRepository>();
            services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

            services.AddScoped<IDimensionReadRepository, DimensionReadRepository>();
            services.AddScoped<IDimensionWriteRepository, DimensionWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<IPersonalReadRepository, PersonalReadRepository>();
            services.AddScoped<IPersonalWriteRepository, PersonalWriteRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();


            services.AddScoped<IPhotoReadRepository, PhotoReadRepository>();
            services.AddScoped<IPhotoWriteRepository, PhotoWriteRepository>();


            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();


            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<ISupplierReadRepository, SupplierReadRepository>();
            services.AddScoped<ISupplierWriteRepository, SupplierWriteRepository>();

            services.AddScoped<IMarketPlaceReadRepository, MarketPlaceReadRepository>();
            services.AddScoped<IMarketPlaceWriteRepository, MarketPlaceWriteRepository>();

            services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
            services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();

            services.AddScoped<IPaymentMethodReadRepository, PaymentMethodReadRepository>();
            services.AddScoped<IPaymentMethodWriteRepository, PaymentMethodWriteRepository>();

            services.AddScoped<ICargoReadRepository, CargoReadRepository>();
            services.AddScoped<ICargoWriteRepository, CargoWriteRepository>();

            services.AddScoped<IMarketPlaceReadRepository, MarketPlaceReadRepository>();
            services.AddScoped<IMarketPlaceWriteRepository, MarketPlaceWriteRepository>();

            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            services.AddScoped<IFileUploadService, FileUploadService>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IDimensionService, DimensionService>();
            services.AddScoped<IPersonalService, PersonalService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITranslateService, TranslateService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IMarketPlaceService, MarketPlaceService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IRaportService, RaportService>();
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IIyzcoPayment, IyzcoPaymentService>();

            services.AddScoped<IArasCargoService, ArasCargoService>();
            services.AddScoped<IMNGCargoService, MngCargoService>();
            services.AddScoped<IYurtiçiCargoService,YurtiçiCargoService>();
            services.AddScoped<ICargoService, CargoService>();


        }
        //extention fonksiyonları
    }
}
