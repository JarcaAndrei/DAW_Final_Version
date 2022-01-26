using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Controllers.APi;
using Microsoft.AspNetCore.Mvc;
using Models.Request.Product;

namespace Ecom.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoryController : BaseController
    {
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _ProductService.getCategories());
        }

        [HttpPost("InsertCategory")]
        public async Task<IActionResult> InsertCategory([FromBody]InsertCategory request)
        {
            return Ok(await _ProductService.insertCategory(request));
        }

        [HttpGet("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            return Ok(await _ProductService.deleteCategory(id));
        }
    }
}
