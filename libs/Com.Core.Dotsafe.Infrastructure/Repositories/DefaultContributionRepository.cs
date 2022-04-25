using Com.Core.Dotsafe.Domain;
using Com.Core.Dotsafe.Framework;
using Com.Core.Dotsafe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Infrastructure.Repositories
{
    public class DefaultContributionRepository : IContributionRepository
    {
        private readonly DotsafesContext _context = null;
        public DefaultContributionRepository(DotsafesContext context)
        {
            this._context = context;
        }

        public IUnitOfWork UnitOfWork => this._context;

        public Contribution AddOne(Contribution contribution)
        {
            return this._context.Contributions.Add(contribution).Entity;
        }

        public ICollection GetAll(int userId)
        {
            var query = from c in this._context.Contributions join u in this._context.Users on c.User.Id equals u.Id where u.Id == userId 
                        select new
                        {
                            contribution = c,
                            user = u
                        };

            return query.ToList();
        }


    }
}
