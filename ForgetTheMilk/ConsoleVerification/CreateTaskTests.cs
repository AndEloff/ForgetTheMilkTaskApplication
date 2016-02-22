using System;
using ForgetTheMilk.Controllers;
using NUnit.Framework;

namespace ConsoleVerification
{
    [TestFixture]
    public class CreateTaskTests : AssertionHelper
    {
        [Test]
        public void TestDescriptionAndNoDueDate()
        {
            var input = "Pick up groceries";

            var task = new Task(input, default(DateTime));

            //Assert.AreEqual(input, task.Description);
            Expect(task.Description, Is.EqualTo(input));
            //Expect(task.DueDate, Is.EqualTo(null));
            Assert.AreEqual(null, task.DueDate);
        }

        [Test]
        public void TestMayDueDateDoesWrapYear()
        {
            var input = "Pick up groceries may 5 - as of 2015-05-31";
            var today = new DateTime(2015, 5, 31);

            var task = new Task(input, today);

            Expect(task.DueDate,Is.EqualTo(new DateTime(2016, 5, 5)));
        }

        [Test]
        public void TestMayDueDateDoesNotWrapYear()
        {
            var input = "Pick up groceries may 5 - as of 2015-05-04";
            var today = new DateTime(2015, 5, 4);

            var task = new Task(input, today);

            Expect(task.DueDate, Is.EqualTo(new DateTime(2015, 5, 5)));
        }
    }
}
