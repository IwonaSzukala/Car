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


// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddRazorRuntimeCompilation();
//builder.Services.AddTransient<IValidator<UserDto>, CreateUserCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EditUserCommandValidator>();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();



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

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});*/

app.MapRazorPages();
app.Run();
