using UdemyNewMicroservice.Catalog.API;
using UdemyNewMicroservice.Catalog.API.Feautures.Categories;
using UdemyNewMicroservice.Catalog.API.Options;
using UdemyNewMicroservice.Catalog.API.Repositories;
using UdemyNewMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();

builder.Services.AddCommonServices(typeof(CatalogAssembly));


var app = builder.Build();
app.AddCategoryGroupEndpoitExt();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

