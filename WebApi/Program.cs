using Domain.Repository;
using Domain.Services;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IRepositoryBase, RepositoryBase>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepoistory>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<ICountryRepository, CompanyRepoistory>();
builder.Services.AddTransient<IRepositoryWrapper, RepoistoryWrapper>();
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
