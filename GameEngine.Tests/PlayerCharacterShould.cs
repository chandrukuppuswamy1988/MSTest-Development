using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        public void NotHaveNickNameByDefault()
        {
            var sut = new PlayerCharacter();

            Assert.IsNull(sut.Nickname);
        }
        [TestMethod]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();

            Assert.AreEqual(100, sut.Health);
        }

        [TestMethod]
        public void TakeDamage()
        {
            var sut = new PlayerCharacter();

            sut.TakeDamage(1);

            Assert.AreEqual(99, sut.Health);
        }

        [TestMethod]
        public void TakeDamage_NotEqual()
        {
            var sut = new PlayerCharacter();

            sut.TakeDamage(1);

            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        public void IncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter();

            sut.Sleep();

            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert.AreEqual("Sarah Smith", sut.FullName);// case sensitive on string
            Assert.AreEqual("SARAH SMITH", sut.FullName,true);

        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.StartsWith(sut.FullName,"Sarah");
        }

    }
}
