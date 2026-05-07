using BlazorApp.Components;
using BlazorApp.Configuration;
using BlazorApp.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7018")
});
builder.Services.AddMudServices();

builder.Services.AddControllers();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDb"));

builder.Services.AddScoped<CustomerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.MapControllers();

app.Run();