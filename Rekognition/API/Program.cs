using Amazon;
using Amazon.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register the Amazon class libary we created.
builder.Services.AddAmazon();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/face-detection", async (string bucket, string key, [FromServices]IFaceDetectionService faceDetection) =>
{
    var result = await faceDetection.DetectFace(bucket, key);
    return Results.Ok(result);
});

// face comparison endpoint
app.MapGet("/face-comparison", async (string bucket, string sourcePhoto, string targetPhoto, [FromServices] IFaceComparisonService faceComparison) => 
{
    var result = await faceComparison.CompareFaces(bucket, sourcePhoto, targetPhoto);
    return Results.Ok(result);
});

// label detection endpoint
app.MapGet("/label-detection", async (string bucket, string key, int maximumLabels, [FromServices] ILabelDetectionService labelDetection) => 
{
    var result = await labelDetection.DetectLabels(bucket, key, maximumLabels);
    return Results.Ok(result);
});

// text detection endpoint
app.MapGet("/text-detection", async (string bucket, string key, [FromServices] ITextImageReadService textService) => 
{
    var result = await textService.ReadTextFromImage(bucket, key);
    return Results.Ok(result);
});

// ppe detection endpoint
app.MapGet("/ppe-detection", async (string bucket, string key, [FromServices] IPpeDetectionService ppeDetectionService) =>
{
    var result = await ppeDetectionService.DetectPpe(bucket, key);
    return Results.Ok(result);
});

app.Run();
