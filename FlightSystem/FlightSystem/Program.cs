using Microsoft.EntityFrameworkCore;
using ApiWithSQLite.Data;
using UserApiWithSQLite.Services;
using FlightSystem.Services;
using FlighSystemLib.Service;

var builder = WebApplication.CreateBuilder(args);

// ✅ SQLite холболт
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=FlightSystemDB.db"));

// ✅ Бүх сервисүүдээ энд бүртгэнэ
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IFlightInfoService, FlightInfoService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Та цаашдаа IFlightService, IBookingService гэх мэтүүдийг нэмнэ

// ✅ MVC controller бүртгэх
builder.Services.AddControllers();

// ✅ Swagger тохиргоо
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();


// ✅ Порт тохиргоо
builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

// ✅ Swagger UI ашиглах
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Authentication & Authorization (одоогоор зөвхөн Authorization)
app.UseAuthorization();

// ✅ Контроллерууд автоматаар маршрутаар холбогдоно
app.MapControllers();

// ✅ DB автоматаар үүсгэх
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
