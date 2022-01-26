using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Database.Context;
using Models.Request.Product;
using Models.Response.CoreResponse;
using Models.Response.Product;
using Models.Utils;

namespace Core.Services
{
    public class CategoryService : ICategoryService
    {
        private ICoreResponseModel _response;
        private IConfiguration _config;
        private DatabaseContext _context;
        private ICommonService _common;
        private IEmailService _emailService;
        private IProcedures _sps;


        public CategoryService(ICoreResponseModel _response, IConfiguration _config, DatabaseContext _context, ICommonService _common, IProcedures _sps, IEmailService _emailService)
        {
            this._response = _response;
            this._config = _config;
            this._context = _context;
            this._common = _common;
            this._emailService = _emailService;
            this._sps = _sps;
        }

        public async Task<CoreResponseModel> InsertCategory(InsertCategory request)
        {
            try
            {
                await _context.categories.AddAsync(new Models.Database.Entity.Category()
                {
                    name = request.name
                }).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return _response.getSuccessResponse(_MESSAGES.success, null);
            }
            catch(Exception ex)
            {
                return _response.getFailResponse(ex.Message, null);
            }
        }
        public async Task<CoreResponseModel> GetCategories()
        {
            try
            {
                var cats = await _context.categories.ToListAsync().ConfigureAwait(false);
                return _response.getSuccessResponse(_MESSAGES.success, cats);
            }
            catch (Exception ex)
            {
                return _response.getFailResponse(ex.Message, null);
            }
        }

        public async Task<CoreResponseModel> DeleteCategory(long id)
        {
            try
            {
                var cat = await _context.categories.FirstOrDefaultAsync(x=>x.id == id).ConfigureAwait(false);
                _context.categories.Remove(cat);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return _response.getSuccessResponse(_MESSAGES.success, null);
            }
            catch (Exception ex)
            {
                return _response.getFailResponse(ex.Message, null);
            }
        }


    }
}
