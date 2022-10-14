
using ETicaretAPI.Application;
using ETicaretAPI.Application.ValidatonRules;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Persistance;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceService();
builder.Services.AddApplicationServices();
builder.Services.AddCors(opitons => opitons.AddDefaultPolicy( policy =>
{
    policy.WithOrigins("https://localhost:7270/swagger", "http://localhost:7270/swagger")
        .AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();