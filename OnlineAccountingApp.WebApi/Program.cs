
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineAccountingApp.Application.Services.AppServices;
using OnlineAccountingApp.Domain.AppEntities.Identity;
using OnlineAccountingApp.Persistance.Context;
using OnlineAccountingApp.Persistance.Services.AppServices;
using OnlineAccountingApp.Presentation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddMediatR(typeof(OnlineAccountingApp.Application.AssemblyReference).Assembly);

builder.Services.AddAutoMapper(typeof(OnlineAccountingApp.Persistance.AssemblyReference).Assembly);


builder.Services.AddIdentity<AppUser,AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
