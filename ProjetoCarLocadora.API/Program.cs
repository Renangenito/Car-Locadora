using ProjetoCarLocadora.API.Extensoes;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigurarJWT();
builder.Services.ConfigurarSwagger();


builder.Services.ConfigurarServicos();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
