using Application.DTOs;
using Domain;

namespace Application.Profiles
{
    public class FileMapper
    {

        public static FileLog FileMap(UploadRequest request, string fullPath)
        {
            var file = new FileLog();
            file.Name = Path.GetFileNameWithoutExtension(request.File.FileName);
            file.FullPath = fullPath;
            file.Extention = Path.GetExtension(request.File.FileName);
            file.FullName = request.File.FileName;


            return file;
        }
    }
}
