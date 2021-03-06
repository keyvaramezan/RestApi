using RestApi.Application.ServiceExtension;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddTransient<IService, Service>();
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddApiVersioning(option =>
//{
//    option.DefaultApiVersion = new ApiVersion(1, 0);
//    option.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
//});
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
