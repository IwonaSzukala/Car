using Car.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Car.Infrastructure.Extensions;
using Car.Application.Extensions;
using Car.Application.Car;
using FluentValidation;
using Car.Application.Car.Commands.CreateUser;
using Car.Application.Car.Commands.EditUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddRazorRuntimeCompilation();
//builder.Services.AddTransient<IValidator<UserDto>, CreateUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EditUserCommandValidator>();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();



var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
