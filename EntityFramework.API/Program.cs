using EntityFramework.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Register.RegisterServices(builder.Services, builder.Configuration);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


//this is to resolve the cycle reference of database models at controller level
//builder.Services.AddControllers().AddNewtonsoftJson(x =>
// x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


//builder.Services.AddAuthentication()
//       .AddGoogle(options =>
//       {
//           options.ClientId = "821333001423-poemjan0bgfso7iffvldoeapajcgagm2.apps.googleusercontent.com";
//           options.ClientSecret = "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";
//       });

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(option =>
{
    option.RoutePrefix = "";
    option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
