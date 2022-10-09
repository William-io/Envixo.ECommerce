var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServer<DataContext>(builder.Configuration["ConnectionStrings:Connection"]);

builder.Services.AddSwaggerSetup();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Envixo.ECommerce.App",
        Description = "App, CRUD de produtos. by William G.Silva",
        Contact = new OpenApiContact
        {
            Name = "Linkedin",
            Email = "williamgsilva@live.com",
            Url = new Uri("https://www.linkedin.com/in/william-io/")
        },
        License = new OpenApiLicense
        {
            Name = "License-Github",
            Url = new Uri("https://github.com/William-io"),
        },
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region 
app.MapMethods(CategoryPost.Template, CategoryPost.Methods, CategoryPost.Handle);
app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
app.MapMethods(CategoryDelete.Template, CategoryDelete.Methods, CategoryDelete.Handle);
app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
#endregion

#region 
app.MapMethods(ProductPost.Template, ProductPost.Methods, ProductPost.Handle);
app.MapMethods(ProductGetAll.Template, ProductGetAll.Methods, ProductGetAll.Handle);
app.MapMethods(ProductShowCase.Template, ProductShowCase.Methods, ProductShowCase.Handle);
app.MapMethods(ProductGetTitle.Template, ProductGetTitle.Methods, ProductGetTitle.Handle);
app.MapMethods(ProductDelete.Template, ProductDelete.Methods, ProductDelete.Handle);
app.MapMethods(ProductPut.Template, ProductPut.Methods, ProductPut.Handle);
#endregion


app.Run();
