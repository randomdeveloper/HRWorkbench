
using System;
using Microsoft.Practices.Unity;

namespace HRWorkbench.Candidates
{
    public class AddCandidate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [Dependency]
        public HRDataContext DataContext { get; set; }

        public void Execute()
        {
            var candidate = new Candidate
                                {
                                    FirstName = FirstName,
                                    LastName = LastName,
                                    Email = Email,
                                    Added = DateTimeOffset.Now
                                };
            
            DataContext.Candidates.Add(candidate);
            DataContext.SaveChanges();
        }
    }
}
