namespace Application.Features;
public class FileResponse
{
    public string FileName { get; set; }
    public string FullPath { get; set; }
    public string Extention { get; set; }
    public string? FileLink { get; set; }

    public FileResponse(string fileName, string fullPath, string extention)
    {
        FileName = fileName;
        FullPath = fullPath;
        Extention = extention;
    }
    public FileResponse()
    {
    }

}

