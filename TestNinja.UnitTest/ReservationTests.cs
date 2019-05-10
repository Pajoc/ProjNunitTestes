using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ResewrvationTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(new User { Name = "Pedro", IsAdmin = true });
            //Assert
            Assert.That(result,Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserWhoReserved_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            var user = new User { Name = "Pedro", IsAdmin = false };
            reservation.MadeBy = user;

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsAnyUser_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();
            var user = new User { Name = "Pedro", IsAdmin = false };
            reservation.MadeBy = user;

            //Act
            var result = reservation.CanBeCancelledBy(new User { Name = "Silva", IsAdmin = false });

            //Assert
            Assert.That(result, Is.False);
        }
    }
}