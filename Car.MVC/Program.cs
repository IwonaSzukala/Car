using Car.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Car.Infrastructure.Extensions;
using Car.Application.Extensions;
using Car.Application.Car;
using FluentValidation;
using Car.Application.Car.Commands.CreateUser;
using Car.Application.Car.Commands.EditUser;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddRazorRuntimeCompilation();

builder.Services.AddValidatorsFromAssemblyContaining<EditUserCommandValidator>();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();



var app = builder.Build();





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
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
