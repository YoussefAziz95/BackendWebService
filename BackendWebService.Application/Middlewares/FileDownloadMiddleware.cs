using Microsoft.AspNetCore.Http;

public class FileDownloadMiddleware
{
    private readonly RequestDelegate _next;

    public FileDownloadMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Check if the request path matches your file download route pattern
        if (context.Request.Path.StartsWithSegments("/download", out var remainingPath))
        {
            var fileName = remainingPath.ToString().TrimStart('/');

            // Build the full file path
            var filePath = Path.Combine("YourFilesDirectory", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("File not found.");
                return;
            }

            var fileStream = System.IO.File.OpenRead(filePath);
            context.Response.ContentType = "application/octet-stream";
            context.Response.Headers.ContentDisposition = $"attachment; filename=\"{fileName}\"";

            await fileStream.CopyToAsync(context.Response.Body);
            return;
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}
