using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using REST_MySql.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;

});

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>();


builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new UrlParameterTransformer()));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();


var myscope = app.Services.CreateScope();
using (myscope)
{
    var db = myscope.ServiceProvider.GetService<MyDbContext>();
    db?.Database.MigrateAsync();
}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "REST_MySql");
    }
    );
    app.UseHsts();


}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();


