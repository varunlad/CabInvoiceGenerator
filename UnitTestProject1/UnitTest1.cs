using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //UC1 Given total distance and time should return total fair (NORMAL) of the journey 
        [TestMethod]
        [TestCategory ("Fare")]
        public void GivenDistanceAndTimeShouldReturnNormalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            //Calculating Fair
            double fare = invoiceGenerator.CalculateFair(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        //UC5 Given total distance and time should return total fair (PREMIUM) of the journey 
        [TestMethod]
        [TestCategory("Fare")]
        public void GivenDistanceAndTimeShouldReturnPremiumFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PRIMIUM);
            double distance = 5.0;
            int time = 10;
            //Calculating Fair
            double fare = invoiceGenerator.CalculateFair(distance, time);
            double expected = 95;
            Assert.AreEqual(expected, fare);
        }
    }
}
