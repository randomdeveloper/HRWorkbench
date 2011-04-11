using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRWorkbench.Tests
{
    static class DatabaseCleaner
    {        
        public static void ClearCandidates()
        {
            var dataContext = Container.Resolve<HRDataContext>();

            foreach (var candidate in dataContext.Candidates)
            {
                dataContext.Candidates.Remove(candidate);
            }
            dataContext.SaveChanges();
        }
    }
}
