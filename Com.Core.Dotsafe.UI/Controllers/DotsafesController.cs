using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Com.Core.Dotsafe.Infrastructure.Data;
using Com.Core.Dotsafe.Domain;
using Com.Core.Dotsafe.UI.Dtos;

namespace Com.Core.Dotsafe.UI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DotsafesController : ControllerBase
    {
        #region Fields
        private readonly IContributionRepository _repository = null;
        #endregion

        #region Constructors
        public DotsafesController(IContributionRepository repository)
        {
            this._repository = repository;
        }
        #endregion

        #region Public methods

        [HttpPost]
        public IActionResult save(ContributionDto contribution)
        {
            Contribution newContribution = this._repository.AddOne(new Contribution() { 
                name = contribution.name
            });

            this._repository.UnitOfWork.SaveChanges();

            if (newContribution != null)
            {
                return Ok(newContribution);
            }

            return Ok(BadRequest());
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int userId = 0)
        {
            var contributions = this._repository.GetAll(userId);
            return Ok(contributions);
        }
        #endregion
    }
}
