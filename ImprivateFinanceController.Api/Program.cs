using ImprivateFinanceController.Api;
using ImprivateFinanceController.Api.Mappings;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("AllowAll",policy => 
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });
    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpClient();
    builder.Services.AddPresentation()
    .AddMappings();
    
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


