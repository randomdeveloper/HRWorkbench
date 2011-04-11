using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using HRWorkbench.Candidates;

namespace HRWorkbench
{
    public class HRDataContext: DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
    }
}
