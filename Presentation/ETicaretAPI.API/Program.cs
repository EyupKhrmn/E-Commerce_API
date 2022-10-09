
using ETicaretAPI.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceService();
builder.Services.AddCors(opitons => opitons.AddDefaultPolicy( policy =>
{
    policy.WithOrigins("https://localhost:7270/swagger", "http://localhost:7270/swagger")
        .AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();