using GlobalBlue.VAT.Presentation.REST;
using GlobalBlue.VAT.Service;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IVatCalculationService, VatCalculationService>();

builder.Services.Configure<ApplicationSettings>(
    builder.Configuration.GetSection(nameof(ApplicationSettings)));

builder.Services.AddCors(x => x.AddDefaultPolicy(
    policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// todo:
//app.UseExceptionHandler(a => a.Run(async context =>
//{
//    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

//    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//    ProblemDetails
//    if (contextFeature != null)
//    {
//        await context.Response.WriteAsync()
//    }
//}))

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
