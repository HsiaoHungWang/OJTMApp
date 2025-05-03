using Microsoft.EntityFrameworkCore;
using OJTMApp.Models;
using OJTMApp.Models.ClassDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection 容器
//NorthwindConnection 是 appsettings.json 連線串的名稱
string? connectionString = builder.Configuration.GetConnectionString("NorthwindConnection");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));

string? connectionString1 = builder.Configuration.GetConnectionString("ClassDBConnection");
builder.Services.AddDbContext<ClassDbContext>(options => options.UseSqlServer(connectionString1));


//把類別變成物件 => 管理物件的生命週期
builder.Services.AddScoped<INotificationService, EmailNotificationService>(); //每一個Requesst會產生一個物件
//builder.Services.AddTransient<INotificationService, SMSNotificationService>();//每一次執行都會產生一個物件
//builder.Services.AddSingleton<INotificationService, EmailNotificationService>(); //整個應用程式只會產生一個物件


//Session相關設定
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "OJTM.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(5); //Session的有效時間
    options.Cookie.HttpOnly = true; //無法用JavaScript讀取
    options.Cookie.IsEssential = true; //必要的Cookie
});

var app = builder.Build();



//Middlewares 中間層(件)
//會根據下面的順序執行

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  //http to https

app.UseRouting();  //啟用路由
app.UseSession();   //啟用Session

app.UseAuthorization();

app.MapStaticAssets();

//https://localhost:5000/product/list/12
//路由的對應表
//product/list => ProductController/list action/12
//member/login => MemberController/login action/a123


    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
