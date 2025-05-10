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

        public FileResponse GetFileResponse(int id)
        {
            var file = _dbSet.FirstOrDefault(x => x.Id == id);
            var fileresponse = new FileResponse(file.FullName, file.FullPath, file.Name, file.Extention);
            return fileresponse;

        }

        public FileLog GetFile(int id)
        {
            var file = _dbSet.FirstOrDefault(x => x.Id == id);
            return file;

        }
        public void Delete(FileLog file)
        {
            _dbSet.Remove(file);
            _context.SaveChanges();
        }

    }
}
