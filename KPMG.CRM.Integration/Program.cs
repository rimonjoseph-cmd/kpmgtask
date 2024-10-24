using KPMG.CRM.Business.Building;
using Microsoft.Xrm.Sdk;
using Microsoft.PowerPlatform.Dataverse.Client;
using KPMG.CRM.Business.Room.BLL;
using KPMG.CRM.Business.TimeSlot.BLL;
using KPMG.CRM.Business.Contact;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KPMG.CRM.Business.BookRoom;

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
    options.AddPolicy("RequiretimeslotRole", policy => policy.RequireRole("cleanstuff", "admin", "employee"));
});
#endregion jwt
#region dependency injection
builder.Services.AddSingleton<IOrganizationServiceAsync>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    return CreateOrganizationService(configuration);
});
builder.Services.AddScoped<IBuildingBLL,BuildingBLL>();
builder.Services.AddScoped<IRoomBLL,RoomBLL>();
builder.Services.AddScoped<ITimeSlotBLL, TimeSlotBLL>();
builder.Services.AddScoped<IContactBLL, ContactBLL>();
builder.Services.AddScoped<IBookRoomBLL, BookRoomBLL>();
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
IOrganizationServiceAsync CreateOrganizationService(IConfiguration _configuration)
{
    try
    {
        string clientid = _configuration["AzureAd:ClientId"];
        string appsecret = _configuration["AzureAd:ClientSecret"];
        string authoirty = _configuration["AzureAd:Authority"];
        string crmurl = _configuration["CRM:Url"];

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