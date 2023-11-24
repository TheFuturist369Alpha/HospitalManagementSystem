using HospitalRepos;
using HospitalRepos.Implementation;
using HospitalRepos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Utilities;
using HospitalServices.Implementations;
using HospitalServices.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IHospitalProp, HospitalService>();
builder.Services.AddTransient<IRoomProp, RoomService>();
builder.Services.AddTransient<IContacts, ContactService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
DataSeeding();
app.UseRouting();
app.UseAuthentication();;
app.MapRazorPages();
app.UseAuthorization();


app.MapControllers();


app.Run();

void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbinit = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbinit.Initialize();
    }
}
