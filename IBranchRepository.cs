using BranchApp.Domain;
using BranchApp.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchApp.Application
{
    public interface IBranchRepository : IGenericRepository<BranchAppEntity>
    {
    }
}
