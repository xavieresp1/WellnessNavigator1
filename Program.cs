using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WellnessNavigator.Data;
using WellnessNavigator1.Data;
using Syncfusion.Blazor;
using WellnessNavigator1.Data.Repositories;
using WellnessNavigator1.Data.Services;
using OpenAI.Net;
using WellnessNavigator1.Data.Services;
using WellnessNavigator1.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("No connection string found in config");

builder.Services.AddDbContextFactory<WellnessNavigatorDbContext>((DbContextOptionsBuilder options)
    => options.UseSqlServer(connectionString));
builder.Services.AddSingleton<IJournalService, JournalService>();
builder.Services.AddSingleton<IFeedbackService, FeedbackService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddOpenAIServices(o =>
{
    o.ApiKey = builder.Configuration["OpenAISettings:ApiKey"];
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
