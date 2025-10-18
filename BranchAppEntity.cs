using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchApp.Domain
{
    public  class BranchAppEntity
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Location { get; set; }
    }
}
