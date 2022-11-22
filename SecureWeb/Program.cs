using Auth0.AspNetCore.Authentication;
using SecureWeb.Services.Values;

var builder = WebApplication.CreateBuilder(args);

if (builder.Configuration.GetValue<bool>("Services:Values:UseFake", false))
{
    builder.Services.AddTransient<IValuesService, FakeValuesService>();
}
else
{
    builder.Services.AddHttpClient<ValuesService>();
    builder.Services.AddTransient<IValuesService, ValuesService>();
}

builder.Services.AddAuth0WebAppAuthentication(options => {
    options.Domain = builder.Configuration["Auth:Domain"];
    options.ClientId = builder.Configuration["Auth:ClientId"];
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
