using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PoliceRecruitmentAPI.Core.Repository;
using PoliceRecruitmentAPI.DataAccess.Context;
using PoliceRecruitmentAPI.DataAccess.Repository;
using PoliceRecruitmentAPI.Services.ApiServices;
using PoliceRecruitmentAPI.Services.Interfaces;
using System.Text;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add session state service
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(1);
    // options.Cookie.HttpOnly = true;
    options.Cookie.Name = "ephr";
    options.Cookie.IsEssential = true;
});

builder.Services.AddCors(o => o.AddPolicy("default", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:44351", "http://localhost:3000", "https://eohc.in")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:dev"]));
}
builder.Services.AddDbContext<DatabaseContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionStrings:prod"]));

builder.Services.AddScoped<IAuthService, AuthService>().AddScoped<AuthRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>().AddScoped<CandidateRepository>();

builder.Services.AddScoped<IDocumentService, DocumentService>().AddScoped<DocumentRepository>();
builder.Services.AddScoped<IAdmissionCardService, AdmissionCardService>().AddScoped<AdmissionCardRepository>();
builder.Services.AddScoped<IheiCheMeasurement, heiCheMeasurementService>().AddScoped<heiCheMeasurementRepositry>();
builder.Services.AddScoped<IAppealService, AppealService>().AddScoped<AppealRepository>();
builder.Services.AddScoped<IRunningService, RunningService>().AddScoped<RunningRepository>();
builder.Services.AddScoped<IShotPutService, ShotPutService>().AddScoped<ShotPutRepository>();
builder.Services.AddScoped<IScanningdocService, ScanningdocService>().AddScoped<ScanningdocRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>().AddScoped<DashboardRepository>();

builder.Services.AddHttpClient();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseCors("AllowOrigin");


app.Run();
