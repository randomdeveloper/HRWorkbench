using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace HRWorkbench.Candidates
{
    public class CandidateQuery
    {
        [Dependency]
        public HRDataContext DataContext { get; set; }

        public IEnumerable<CandidateListItem> GetForList()
        {
            return
                from c in DataContext.Candidates
                orderby c.Added descending
                select new CandidateListItem
                           {
                               FirstName = c.FirstName,
                               LastName = c.LastName
                           };            
        }
    }
}
