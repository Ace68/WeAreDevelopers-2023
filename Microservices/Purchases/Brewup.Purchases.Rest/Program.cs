using Brewup.Purchases.Rest.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterModules();

var app = builder.Build();
app.UseCors("CorsPolicy");
app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();