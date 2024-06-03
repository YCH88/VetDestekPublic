using ENtityFrameWork_Test.Entities;
using ENtityFrameWork_Test.Extensions;
using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddIdentityAndEFStore(builder.Configuration);

builder.Services.AddScoped<ITestServices,TestServices>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IDiseaseService,DiseaseService>();
builder.Services.AddScoped<ISymptomService,SymptomService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

using var scope = app.Services.CreateScope();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");


await using var dbContext = scope.ServiceProvider.GetRequiredService<TestContext>();

await dbContext.Database.MigrateAsync();

await builder.Services.Seed(builder.Configuration,dbContext, scope.ServiceProvider.GetRequiredService<UserManager<User>>(), scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>());

app.Run();
