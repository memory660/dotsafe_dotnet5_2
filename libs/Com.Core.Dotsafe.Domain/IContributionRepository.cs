using Com.Core.Dotsafe.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Core.Dotsafe.Domain
{
    public  interface IContributionRepository : IRepository
    {
        ICollection GetAll(int userId);

        Contribution AddOne(Contribution contribution);
    }
}
