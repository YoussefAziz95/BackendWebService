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
        public FileLog Upload(FileLog file)
        {
            _dbSet.Add(file);

            var result = _context.SaveChanges();
            if (result < 1)
                throw new ArgumentNullException("Cannot Add FileLog ");
            return file;
        }
        public bool Exists(string fileName)
        {
            return _dbSet.Any(x => x.FileName == fileName);

        }
        public FileResponse GetFileResponse(string fileName)
        {
            var file = _dbSet.First(x => x.FileName == fileName);
            var fileresponse = new FileResponse(file.FileName, file.FullPath, file.Extention);
            return fileresponse;

        }


        public void Delete(string fileName)
        {
            var file = _dbSet.First(x => x.FileName == fileName);
            _dbSet.Remove(file);
            _context.SaveChanges();
        }

        public FileLog? GetFileById(int? id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
        public FileLog? GetFileById(string fileName)
        {
            return _dbSet.FirstOrDefault(x => x.FileName == fileName);
        }
    }
}
