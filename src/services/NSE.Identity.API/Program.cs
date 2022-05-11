using NSE.Identity.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddApiConfiguration();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

#endregion

#region Configure Pipeline

app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

app.MapControllers();

app.Run();

#endregion