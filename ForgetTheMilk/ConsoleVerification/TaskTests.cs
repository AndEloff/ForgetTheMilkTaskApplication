using System;
using ForgetTheMilk.Controllers;
using NUnit.Framework;

namespace ConsoleVerification
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void TestDescriptionAndNoDueDate()
        {
            var input = "Pick up groceries";
            Console.WriteLine("Scenario: " + input);

            var task = new Task(input, default(DateTime));

            var descriptionShouldBe = input;
            DateTime? dueDateShouldBe = null;
            var success = descriptionShouldBe == task.Description && dueDateShouldBe == task.DueDate;
            var failureMessage = "Description: " + task.Description + "should be" + descriptionShouldBe
                + Environment.NewLine
                + "Due Date: " + task.DueDate + "should be" + dueDateShouldBe;
            Assert.That(success, failureMessage);
        }

        [Test]
        public void TestMayDueDateDoesWrapYear()
        {
            var input = "Pick up groceries may 5 - as of 2015-05-31";
            Console.WriteLine("Scenario: " + input);
            var today = new DateTime(2015, 5, 31);

            var task = new Task(input, today);

            var dueDateShouldBe = new DateTime(2016, 5, 5);
            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;
            Assert.That(success, failureMessage);
        }

        [Test]
        public void TestMayDueDateDoesNotWrapYear()
        {
            var input = "Pick up groceries may 5 - as of 2015-05-04";
            Console.WriteLine("Scenario: " + input);
            var today = new DateTime(2015, 5, 4);

            var task = new Task(input, today);

            var dueDateShouldBe = new DateTime(2015, 5, 5);
            var success = dueDateShouldBe == task.DueDate;
            var failureMessage = "Due Date: " + task.DueDate + " should be " + dueDateShouldBe;
            Assert.That(success, failureMessage);
        }
    }
}
