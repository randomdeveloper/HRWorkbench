using System;

namespace HRWorkbench.Candidates
{
    public class Candidate
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTimeOffset Added { get; set; }
    }
}
