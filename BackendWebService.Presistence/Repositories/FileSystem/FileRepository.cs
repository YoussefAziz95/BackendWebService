using Application.Contracts.Presistence;
using Application.DTOs.Utility;
using Application.MappingProfiles;
using AutoMapper;
using Persistence.Data;
using Persistence.Repositories.Common;


namespace Persistence.Repositories.FileSystem
{
    public class FileRepository : GenericRepository<FileLog>, IFileRepository
    {

        private readonly IMapper _mapper;

        public FileRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {

            _mapper = mapper;
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
            var fileresponse = _mapper.Map<FileResponse>(file);
            return fileresponse;

        }



    }
}
