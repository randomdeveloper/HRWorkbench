using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HRWorkbench.Candidates;
using NUnit.Framework;

namespace HRWorkbench.Tests.Candidates
{
    [TestFixture]
    public class CandidateQueryTests
    {
        [Test]
        public void ListDisplaysAddedCandidates()
        {
            // prepare
            DatabaseCleaner.ClearCandidates();

            var addCommand = Container.Resolve<AddCandidate>();
            addCommand.FirstName = "test first";
            addCommand.LastName = "test second";
            addCommand.Email = "test@example.com";

            addCommand.Execute();

            // select
            var query = Container.Resolve<CandidateQuery>();
            var result = query.GetForList();

            Assert.That(result.Count(), Is.EqualTo(1));
            var row = result.First();
            Assert.That(row.FirstName, Is.EqualTo("test first"));
            Assert.That(row.LastName, Is.EqualTo("test second"));
        }

        [Test]
        public void NewlyAddedCandidatesAreDisplayedFirst()
        {
            // prepare
            DatabaseCleaner.ClearCandidates();

            var addCommand = Container.Resolve<AddCandidate>();
            addCommand.FirstName = "fname1";
            addCommand.LastName = "lname1";
            addCommand.Email = "email1@example.com";

            addCommand.Execute();

            // make sure on db you'll have different datetimes
            Thread.Sleep(10);

            addCommand = Container.Resolve<AddCandidate>();
            addCommand.FirstName = "fname2";
            addCommand.LastName = "lname2";
            addCommand.Email = "email2@example.com";

            addCommand.Execute();

            // select
            var query = Container.Resolve<CandidateQuery>();
            var result = query.GetForList().ToList();

            Assert.That(result.Count(), Is.EqualTo(2));

            // check order
            var firstRow = result[0];
            Assert.That(firstRow.FirstName, Is.EqualTo("fname2"));
            var secondRow = result[1];
            Assert.That(secondRow.FirstName, Is.EqualTo("fname1"));
        }
    }
}
