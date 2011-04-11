using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRWorkbench.Candidates;
using NUnit.Framework;

namespace HRWorkbench.Tests.Candidates
{
    [TestFixture]
    public class AddCandidateTest
    {
        [Test]
        public void AddCandidateExecutesWithNoFail()
        {
            var addCommand = Container.Resolve<AddCandidate>();

            addCommand.FirstName = "John";
            addCommand.LastName = "Jameson";
            addCommand.Email = "john@jameson.com";

            addCommand.Execute();
        }
    }
}
