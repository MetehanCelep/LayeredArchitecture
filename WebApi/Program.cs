using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IProductService, ProductManager>();//.net 6.0da gelen güncelleme ile startup.cs kaldırıldı. Bu yüzden bunlar burada yazılır.
//builder.Services.AddSingleton<IProductDal, EfProductDal>();//Bu fonksiyon IProductDal gördüğün yerde arka planda EfProductDal üret demek. 

//Burada yazılan kod .net'in kendi IoC Containerı yerine Autofac gibi başka IoC'ler kullanmamızı sağlar.
builder.Host.UseServiceProviderFactory(services =>
    new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    }
    );

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
