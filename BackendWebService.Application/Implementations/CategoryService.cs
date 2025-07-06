using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Wrappers;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations
{
    /// <summary>
    /// Services implementation for managing categories.
    /// </summary>
    public class CategoryService : ResponseHandler, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> AddAsync(AddCategoryRequest request)
        {
            // Check if the parent ID exists
            if (request.ParentId is not null && request.ParentId != 0)
                if (!CheckIdExists((int)request.ParentId))
                    return NotFound<int>("Invalid ParentCategory Id");


            var category = _mapper.Map<Category>(request);
            await _unitOfWork.GenericRepository<Category>().AddAsync(category);
            var result = await _unitOfWork.SaveAsync();


            return result > 0 ? Success<int>()
                              : BadRequest<int>("Something went wrong");
        }

        /// <inheritdoc/>
        public bool CheckIdExists(int id)
        {
            return _unitOfWork.GenericRepository<Category>().Get(b => b.Id == id) is not null;
        }

        /// <inheritdoc/>
        public async Task<IResponse<string>> DeleteAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<string>();

            var category = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(id);

            // Check if the category is associated with other entities
            if (_unitOfWork.GenericRepository<SupplierCategory>().Exists(vc => vc.CategoryId == id) ||
                _unitOfWork.GenericRepository<Category>().Exists(vc => vc.ParentId == id))
                return CannotDelete<string>();

            // Recursively delete child categories
            if (_unitOfWork.GenericRepository<Category>().Exists(c => c.ParentId == id))
            {
                var categories = _unitOfWork.GenericRepository<Category>().GetAll(c => c.ParentId == id);
                foreach (Category categoryChild in categories)
                {
                    await DeleteAsync(categoryChild.Id);
                }
            }



            var result = await _unitOfWork.SaveAsync();
            return result > 0 ? Deleted<string>()
                              : BadRequest<string>("Something went wrong");
        }

        /// <inheritdoc/>
        public async Task<IResponse<CategoryResponse>> GetAsync(int id)
        {
            if (!CheckIdExists(id))
                return NotFound<CategoryResponse>();

            var response = GetById(id);
            return Success(response);
        }

        /// <inheritdoc/>
        public async Task<IResponse<List<CategoryResponse>>> GetPaginated(int CompanyId)
        {
            var categories = _categoryRepository.GetAll(CompanyId);
            return categories is not null ? Success(categories) : NotFound<List<CategoryResponse>>("No Catgeory to Display");
        }

        /// <inheritdoc/>
        public async Task<IResponse<int>> UpdateAsync(UpdateCategoryRequest request)
        {
            var oldCategory = _mapper.Map<Category>(request);


            var result = await _categoryRepository.UpdateCategory(oldCategory);


            return result > 0 ? Success(result)
                              : BadRequest<int>("Something went wrong");
        }

        private List<Category> getSubCategories(List<Category>? subs)
        {
            for (int i = 0; i < subs.Count; i++)
            {
                subs[i] = _unitOfWork.GenericRepository<Category>()
                            .Get(c => c.Id == subs[i].Id,
                            include: c => c.Include(sub => sub.SubCategories));
                if (!subs[i].SubCategories.Any())
                    subs[i].SubCategories = getSubCategories(subs[i].SubCategories.ToList());
            }
            return subs;
        }
        private CategoryResponse GetById(int id)
        {
            var category = _unitOfWork.GenericRepository<Category>()
                            .Get(c => c.Id == id,
                            include:
                            c => c.Include(sub => sub.SubCategories));
            if (!category.SubCategories.Any())
                category.SubCategories = getSubCategories(category.SubCategories.ToList());
            var response = _mapper.Map<CategoryResponse>(category);
            return response;
        }

    }
}