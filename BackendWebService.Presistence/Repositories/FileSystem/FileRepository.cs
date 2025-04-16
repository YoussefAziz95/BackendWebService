using Application.Contracts.Persistences;
using AutoMapper;
using Application.Profiles;
using Domain;
using Persistence.Data;
using Persistence.Repositories.Common;
using Application.DTOs;
namespace Persistence.Repositories.FileSystem
{
    public class FileRepository : GenericRepository<FileLog>, IFileRepository
    {
        public FileRepository(ApplicationDbContext context) : base(context)
        {

        }
        public FileLog Upload(UploadRequest request, string fullPath)
        {

            var file = FileMapper.FileMap(request, fullPath);
            file.FileTypeId = _context.FileTypes.FirstOrDefault(f => f.Extentions.Contains(file.Extention)).Id;

            _dbSet.Add(file);

            var result = _context.SaveChanges();
            if (result < 1)
                throw new ArgumentNullException("Cannot Add FileLog ");


            return file;

        }

        public FileResponse GetFile(int id)
        {
            var file = _dbSet.FirstOrDefault(x => x.Id == id);
            var fileresponse = new FileResponse(file.FullName, file.FullPath, file.Name, file.Extention);
            return fileresponse;

        }



    }
}
