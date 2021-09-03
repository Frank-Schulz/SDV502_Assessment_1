using CinemaFunctions;
using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    [TestFixture]
    public class TestingTicketPriceController
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [TestCase(1, "Adult", "Monday", 4, 14.50)]
        [TestCase(2, "Adult", "Monday", 4, 29.00)]
        [TestCase(0, "Adult", "Monday", 4, -1)]
        [TestCase(1, "Student", "Monday", 4, -1)]
        [TestCase(1, "Adult", "Tuesday", 4, -1)]
        [TestCase(1, "Adult", "Monday", 6, -1)]
        public void Testing_Adult_Before_5(
            int quantity,
            string person,
            string day,
            decimal time,
            decimal expected
        )
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Adult_Before_5(quantity, person, day, time);

            Assert.That(price == expected);
        }

        [TestCase(1, "Adult", "Monday", 6, 17.50)]
        [TestCase(2, "Adult", "Monday", 6, 35.00)]
        [TestCase(0, "Adult", "Monday", 6, -1)]
        [TestCase(1, "Student", "Monday", 6, -1)]
        [TestCase(1, "Adult", "Tuesday", 6, -1)]
        [TestCase(1, "Adult", "Monday", 4, -1)]
        public void Testing_Adult_After_5(
            int quantity,
            string person,
            string day,
            decimal time,
            decimal expected
        )
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Adult_After_5(quantity, person, day, time);

            Assert.That(price == expected);
        }

        [TestCase(1, "Adult", "Tuesday", 13.00)]
        [TestCase(2, "Adult", "Tuesday", 26.00)]
        [TestCase(0, "Adult", "Tuesday", -1)]
        [TestCase(1, "Student", "Tuesday", -1)]
        [TestCase(1, "Adult", "Monday", -1)]
        [TestCase(1, "Adult", "Friday", -1)]
        public void Testing_Adult_Tuesday(
            int quantity,
            string person,
            string day,
            decimal expected
        )
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Adult_Tuesday(quantity, person, day);

            Assert.That(price == expected);
        }

        [TestCase(1, "Child", 12.00)]
        [TestCase(2, "Child", 24.00)]
        [TestCase(0, "Child", -1)]
        [TestCase(1, "Student", -1)]
        [TestCase(1, "Adult", -1)]
        [TestCase(2, "Adult", -1)]
        public void Testing_Child_Under_16(int quantity, string person, decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Child_Under_16(quantity, person);

            Assert.That(price == expected);
        }

        [TestCase(1, "Senior", 12.50)]
        [TestCase(2, "Senior", 25.00)]
        [TestCase(0, "Senior", -1)]
        [TestCase(1, "Student", -1)]
        [TestCase(1, "Child", -1)]
        [TestCase(2, "Child", -1)]
        public void Testing_Senior(int quantity, string person, decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Senior(quantity, person);

            Assert.That(price == expected);
        }

        [TestCase(1, "Student", 14.00)]
        [TestCase(2, "Student", 28.00)]
        [TestCase(0, "Student", -1)]
        [TestCase(1, "Child", -1)]
        [TestCase(1, "Adult", -1)]
        [TestCase(2, "Adult", -1)]
        public void Testing_Student(int quantity, string person, decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Student(quantity, person);

            Assert.That(price == expected);
        }

        [TestCase(1, 2, 2, 46.00)]
        [TestCase(1, 1, 3, 46.00)]
        [TestCase(2, 2, 2, 92.00)]
        [TestCase(1, 0, 3, -1)]
        [TestCase(1, 2, 0, -1)]
        [TestCase(2, 2, 3, -1)]
        public void Testing_Family_Pass(
            int quantity_ticket,
            int quantity_adult,
            int quantity_child,
            decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Family_Pass(quantity_ticket, quantity_adult, quantity_child);

            Assert.That(price == expected);
        }

        [TestCase(1, "Adult", "Thursday", 21.50)]
        [TestCase(2, "Adult", "Thursday", 43.00)]
        [TestCase(0, "Adult", "Thursday", -1)]
        [TestCase(1, "Child", "Thursday", -1)]
        [TestCase(1, "Adult", "Wednesday", -1)]
        [TestCase(2, "Student", "Thursday", -1)]
        public void Testing_Chick_Flick_Thursday(
            int quantity,
            string person,
            string day,
            decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Chick_Flick_Thursday(quantity, person, day);

            Assert.That(price == expected);
        }

        [TestCase(1, "Wednesday", false, 12.00)]
        [TestCase(2, "Wednesday", false, 24.00)]
        [TestCase(0, "Wednesday", false, -1)]
        [TestCase(1, "Wednesday", true, -1)]
        [TestCase(1, "Thursday", true, -1)]
        [TestCase(2, "Monday", true, -1)]
        public void Testing_Kids_Pass(
            int quantity,
            string day,
            bool holiday,
            decimal expected)
        {
            TicketPriceController TPC = new TicketPriceController();

            decimal price = TPC.Kids_Pass(quantity, day, holiday);

            Assert.That(price == expected);
        }
    }
}
