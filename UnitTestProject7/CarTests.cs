using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClassLibrary7.Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void Car_GetInspectionFrequency_Default_ReturnsEmptyString()
        {
            // Arrange
            var car = new Car(DateTime.Now, 10000, "Toyota", "Sedan", OwnerType.Individual, DateTime.Now);

            // Act
            string result = car.GetInspectionFrequency();

            // Assert
            Assert.AreEqual("", result);
        }
    }

    [TestClass]
    public class IndividualCarTests
    {
        [TestMethod]
        public void IndividualCar_GetInspectionFrequency_Over10Years_ReturnsAnnual()
        {
            // Arrange
            var individualCar = new IndividualCar(new DateTime(2010, 1, 1), 50000, "Toyota", "Sedan", new DateTime(2022, 1, 1), new IndividualOwner("John Doe"));

            // Act
            string result = individualCar.GetInspectionFrequency();

            // Assert
            Assert.AreEqual("Ежегодно", result);
        }

        [TestMethod]
        public void IndividualCar_GetInspectionFrequency_Under10Years_ReturnsEvery2Years()
        {
            // Arrange
            var individualCar = new IndividualCar(new DateTime(2020, 1, 1), 20000, "Honda", "SUV", new DateTime(2022, 1, 1), new IndividualOwner("Jane Doe"));

            // Act
            string result = individualCar.GetInspectionFrequency();

            // Assert
            Assert.AreEqual("Раз в 2 года", result);
        }
    }

    [TestClass]
    public class LegalCarTests
    {
        [TestMethod]
        public void LegalCar_GetInspectionFrequency_ReturnsEvery6Months()
        {
            // Arrange
            var legalCar = new LegalCar(new DateTime(2015, 1, 1), 30000, "Ford", "SUV", new DateTime(2022, 1, 1), new LegalOwner("ABC Company"));

            // Act
            string result = legalCar.GetInspectionFrequency();

            // Assert
            Assert.AreEqual("Раз в полгода", result);
        }
    }
}
