using ProvaCodeblox.Servicos.DTOS.Mapping;
using ProvaCodeblox.UI.InjecaoDeDependencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutomapperConfig));
builder.Services.RegistrarRepositorios(builder.Configuration);
builder.Services.RegistrarServicos();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.CriarBancoDeDados();
app.Run();