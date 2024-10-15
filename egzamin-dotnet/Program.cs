var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();



app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();

//app.MapGet("/", () => "Hello World!");

app.Run();
