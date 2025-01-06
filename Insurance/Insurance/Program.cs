using Insurance.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<IPolicyService, PolicyService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    builder.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader()
);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
