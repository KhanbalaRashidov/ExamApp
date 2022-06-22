using ExamApp.BAL.Abstract;
using ExamApp.BAL.Concrete;
using ExamApp.DAL.Abstract;
using ExamApp.DAL.Concrete.EntityFramework;
using ExamApp.DAL.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ExamDbContext>(options =>
//              options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILessonService, LessonService>();

builder.Services.AddScoped<IExamDal, EfExamDal>();
builder.Services.AddScoped<IStudentDal, EfStudentDal>();
builder.Services.AddScoped<ILessonDal, EfLessonDal>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
