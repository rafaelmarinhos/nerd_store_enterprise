using NSE.Customers.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddApiConfiguration(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.RegisterServices();

var app = builder.Build();

#endregion

#region Configure Pipeline

app.UseApiConfiguration(app.Environment);

app.UseSwaggerConfiguration();

app.Run();

#endregion