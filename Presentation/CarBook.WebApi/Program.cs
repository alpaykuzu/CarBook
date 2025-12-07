using CarBook.Application.Features.Abouts.Commands.CreateAbout;
using CarBook.Application.Features.Abouts.Commands.RemoveAbout;
using CarBook.Application.Features.Abouts.Commands.UpdateAbout;
using CarBook.Application.Features.Abouts.Queries.GetAllAbout;
using CarBook.Application.Features.Abouts.Queries.GetByIdAbout;
using CarBook.Application.Features.Banners.Commands.CreateBanner;
using CarBook.Application.Features.Banners.Commands.RemoveBanner;
using CarBook.Application.Features.Banners.Commands.UpdateBanner;
using CarBook.Application.Features.Banners.Queries.GetAllBanner;
using CarBook.Application.Features.Banners.Queries.GetByIdBanner;
using CarBook.Application.Features.Brands.Commands.CreateBrand;
using CarBook.Application.Features.Brands.Commands.RemoveBrand;
using CarBook.Application.Features.Brands.Commands.UpdateBrand;
using CarBook.Application.Features.Brands.Queries.GetAllBrand;
using CarBook.Application.Features.Brands.Queries.GetByIdBrand;
using CarBook.Application.Features.Cars.Commands.CreateCar;
using CarBook.Application.Features.Cars.Commands.RemoveCar;
using CarBook.Application.Features.Cars.Commands.UpdateCar;
using CarBook.Application.Features.Cars.Queries.GetAllCar;
using CarBook.Application.Features.Cars.Queries.GetByIdCar;
using CarBook.Application.Features.Cars.Queries.GetCarWithBrand;
using CarBook.Application.Features.Cars.Queries.GetCarWithPricing;
using CarBook.Application.Features.Cars.Queries.GetLastCarWithBrand;
using CarBook.Application.Features.Categories.Commands.CreateCategory;
using CarBook.Application.Features.Categories.Commands.RemoveCategory;
using CarBook.Application.Features.Categories.Commands.UpdateCategory;
using CarBook.Application.Features.Categories.Queries.GetAllCategory;
using CarBook.Application.Features.Categories.Queries.GetByIdCategory;
using CarBook.Application.Features.Contacts.Commands.CreateContact;
using CarBook.Application.Features.Contacts.Commands.RemoveContact;
using CarBook.Application.Features.Contacts.Commands.UpdateContact;
using CarBook.Application.Features.Contacts.Queries.GetAllContact;
using CarBook.Application.Features.Contacts.Queries.GetByIdContact;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Services;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));

builder.Services.AddScoped<GetAllAboutQueryHandler>();
builder.Services.AddScoped<GetByIdAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetAllBannerQueryHandler>();
builder.Services.AddScoped<GetByIdBannerQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetAllBrandQueryHandler>();
builder.Services.AddScoped<GetByIdBrandQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetAllCarQueryHandler>();
builder.Services.AddScoped<GetByIdCarQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetAllCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetAllCarWithPricingQueryHandler>();
builder.Services.AddScoped<GetLastCarWithBrandQueryHandler>();

builder.Services.AddScoped<GetAllCategoryQueryHandler>();
builder.Services.AddScoped<GetByIdCategoryQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetAllContactQueryHandler>();
builder.Services.AddScoped<GetByIdContactQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
