using Application.DTOs.Utility;

namespace Application.MappingProfiles
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
