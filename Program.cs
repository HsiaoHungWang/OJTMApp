using Microsoft.EntityFrameworkCore;
using OJTMApp.Models;
using OJTMApp.Models.ClassDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection �e��
//NorthwindConnection �O appsettings.json �s�u�ꪺ�W��
string? connectionString = builder.Configuration.GetConnectionString("NorthwindConnection");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));

string? connectionString1 = builder.Configuration.GetConnectionString("ClassDBConnection");
builder.Services.AddDbContext<ClassDbContext>(options => options.UseSqlServer(connectionString1));


//�����O�ܦ����� => �޲z���󪺥ͩR�g��
builder.Services.AddScoped<INotificationService, EmailNotificationService>(); //�C�@��Requesst�|���ͤ@�Ӫ���
//builder.Services.AddTransient<INotificationService, SMSNotificationService>();//�C�@�����泣�|���ͤ@�Ӫ���
//builder.Services.AddSingleton<INotificationService, EmailNotificationService>(); //������ε{���u�|���ͤ@�Ӫ���


//Session�����]�w
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "OJTM.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(5); //Session�����Įɶ�
    options.Cookie.HttpOnly = true; //�L�k��JavaScriptŪ��
    options.Cookie.IsEssential = true; //���n��Cookie
});

var app = builder.Build();



//Middlewares �����h(��)
//�|�ھڤU�������ǰ���

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  //http to https

app.UseRouting();  //�ҥθ���
app.UseSession();   //�ҥ�Session

app.UseAuthorization();

app.MapStaticAssets();

//https://localhost:5000/product/list/12
//���Ѫ�������
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
