using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Com.Core.Dotsafe.Infrastructure.Data;
using Com.Core.Dotsafe.Domain;

namespace Com.Core.Dotsafe.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DotsafesController : ControllerBase
    {
        #region Fields
        private readonly DotsafesContext _context = null;
        #endregion

        #region Constructors
        public DotsafesController(DotsafesContext context)
        {
            this._context = context;
        }
        #endregion

        #region Public methods

        [HttpGet]
        public IActionResult TestAMoi()
        {
            var model = Enumerable.Range(1, 10).Select(item => new User() { Id = item });
            return this.StatusCode(StatusCodes.Status204NoContent);

            //var model = this._context.Users.ToList();
            
            return this.Ok(model);
        }
        #endregion
    }
}
