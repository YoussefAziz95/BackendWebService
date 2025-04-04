using Application.Contracts.Persistences;
using Application.DTOs.SupplierDocuments;
using Application.Model.EAVEngine;
using Domain;
using Domain.Enums;
using Persistence.Data;
using System.Data;

namespace Persistence.Repositories.Organizations
{
    /// <summary>
    /// Repository for managing <see cref="Deal"/> entities.
    /// </summary>
    public class SupplierDocumentRepository : ISupplierDocumentRepository
    {
        private const string CASE = "WorkflowCase";
        private const string ACTION = "WorkflowAction";
        private const string WORKFLOW = "Workflow";
        private const string VENDOR_DOCUMENT = "SupplierDocuments";
        private const string PREDOCUMENT = "PreDocuments";


        private readonly ApplicationDbContext _context;


        /// <summary>
        /// Constructs a new instance of <see cref="DealRepository"/>.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public SupplierDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddSupplierDocumentAsync(SupplierDocument supplierDocument)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {

                    _context.Add(supplierDocument);
                    _context.SaveChanges();
                    transaction.Commit();
                    return supplierDocument.Id;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public int UpdateSupplierDocument(SupplierDocument updatedEntity)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {

                try
                {
                    _context.Update(updatedEntity);
                    _context.SaveChanges();
                    transaction.Commit();
                    return updatedEntity.Id;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



        public int UpdateObjectModel(TakeActionModel reviewObjectModel, bool finalAction)
        {
            var doc = _context.SupplierDocuments.First(b => b.Id == reviewObjectModel.Id);
            doc.Comment = reviewObjectModel.Comment;
            if ((int)StatusEnum.Accepted == reviewObjectModel.StatusId)
            {
                doc.IsApproved = true;
                doc.ApprovedDate = DateTime.Now;
            }
            _context.SupplierDocuments.Update(doc);
            _context.SaveChanges();
            if (finalAction)
            {
                if (!_context.SupplierDocuments.Any(d => d.SupplierAccountId == doc.SupplierAccountId && !d.IsApproved))
                {
                    var company = _context.SupplierAccounts.First(c => c.Id == doc.SupplierAccountId);
                    company.IsApproved = true;
                    company.ApprovedDate = DateTime.Now;
                }
                if (!_context.SupplierDocuments.Any(d => d.OrganizationId == doc.OrganizationId && !d.IsApproved))
                {
                    var company = _context.SupplierAccounts.First(c => c.Id == doc.OrganizationId);
                    company.IsApproved = true;
                    company.ApprovedDate = DateTime.Now;
                }
                _context.SaveChanges();
            }
            return doc.Id;
        }


        public bool CheckRegistered(int supplierId)
        {
            var query = from cv in _context.SupplierAccounts where cv.SupplierId == supplierId select cv.Id;
            return query.Any();
        }
        public IQueryable<SupplierDocumentsResponse> GetPaginated(int supplierId)
        {
            var query = from v in _context.Suppliers
                        join cv in _context.SupplierAccounts on v.Id equals cv.SupplierId
                        join c in _context.Companies on cv.CompanyId equals c.Id
                        join p in _context.PreDocuments on c.OrganizationId equals p.OrganizationId
                        join vd in _context.SupplierDocuments
                            on new { PreDocumentId = p.Id, SupplierAccountId = cv.Id }
                            equals new { vd.PreDocumentId, vd.SupplierAccountId } into vds
                        from vd in vds.DefaultIfEmpty()
                        where v.Id == supplierId
                        select new SupplierDocumentsResponse
                        {
                            PreDocumentName = p.Name,
                            FileId = vd.FileId,
                            IsApproved = vd.IsApproved,
                            PreDocumentId = p.Id,
                            Id = vd.Id,
                        };

            var s = query.ToList();
            return query;
        }
    }
}
