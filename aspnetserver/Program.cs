using aspnetserver.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:5173", "https://appname.azurestaticapps.net");
        });
});



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( SwaggerGenOptions =>
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP NET With Next JS", Version = "V1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//we always want Swagger in this project so delete if

app.UseSwagger();
app.UseSwaggerUI(swaggerUiOptions =>
{
    swaggerUiOptions.DocumentTitle = "ASP NET With Next JS";
    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API Serving a very simple post model");
    swaggerUiOptions.RoutePrefix = string.Empty;

});

app.UseHttpsRedirection();


app.UseCors("CORSPolicy");

//Read all
app.MapGet("/get-all-posts", async () => await PostsRepository.GetPostsAsync())
    .WithTags("Posts Endpoints");


//Read one
app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
{
    Post postToReturn = await PostsRepository.GetPostByIdAsync(postId);

    if (postToReturn != null)
    {
        // Result.Ok is type included in ASP.NET
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");




//Create
app.MapPost("/create-post", async (Post postToCreate) => { 
    bool createdSuccessfull = await PostsRepository.CreatePostAsync(postToCreate);
    if (createdSuccessfull)
    {
        return Results.Ok("Post Created Successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");



//Update

app.MapPut("/update-post", async (Post postToUpdate) => {
    bool updateSuccessfull = await PostsRepository.UpdatePostAsync(postToUpdate);
    if (updateSuccessfull)
    {
        return Results.Ok("Post updated Successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");


//Delete
app.MapDelete("/delete-post-by-id/{postId}", async (int postId) => {
    bool deleteSuccessfull = await PostsRepository.DeletePostAsync(postId);
    if (deleteSuccessfull)
    {
        return Results.Ok("Post deleted Successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.Run();

