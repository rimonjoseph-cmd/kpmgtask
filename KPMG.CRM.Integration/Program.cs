using KPMG.CRM.Business.Building;
using Microsoft.Xrm.Sdk;
using Microsoft.PowerPlatform.Dataverse.Client;
using KPMG.CRM.Business.Room.BLL;
using KPMG.CRM.Business.TimeSlot.BLL;
using KPMG.CRM.Business.Contact;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var MyAllowSpecificOrigins = "AllowAll";
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});
#region jwt
//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("admin"));
    options.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("employee"));
    options.AddPolicy("RequireCleanStuffRole", policy => policy.RequireRole("cleanstuff"));
});
#endregion jwt
#region dependency injection
builder.Services.AddSingleton<IOrganizationServiceAsync>(serviceProvider =>
{
    return CreateOrganizationService();
});
builder.Services.AddScoped<IBuildingBLL,BuildingBLL>();
builder.Services.AddScoped<IRoomBLL,RoomBLL>();
builder.Services.AddScoped<ITimeSlotBLL, TimeSlotBLL>();
builder.Services.AddScoped<IContactBLL, ContactBLL>();

#endregion 


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
app.UseCors(MyAllowSpecificOrigins);
app.Run();
IOrganizationServiceAsync CreateOrganizationService()
{
    try
    {
        string clientid = "a82375ed-07ae-49f3-899f-bfc99e94ac49";
        string appsecret = "VZ98Q~ZrBgneQqZpw8Ku4sg-hfWeCriUhK7F5bVA";
        string authoirty = "https://login.microsoftonline.com/94957a1d-682e-469c-9db8-5ab6cb6adad3";
        string crmurl = "https://org0365d327.crm15.dynamics.com/";

        string connectstring = $"AuthType=ClientSecret;Url={crmurl};Clientid={clientid};ClientSecret={appsecret};Authority={authoirty}:RequireNewInstance=True";
        IOrganizationServiceAsync service = new ServiceClient(connectstring);

        return service;
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw ex;
    }
   
}