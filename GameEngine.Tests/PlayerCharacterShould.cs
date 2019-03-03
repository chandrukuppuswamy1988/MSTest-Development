using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

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

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {

            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.EndsWith(sut.FullName, "Smith");
        }


        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {

            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.Contains(sut.FullName, "ah Sm");
        }


        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {

            var sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            //Complimentary string doesNotMatch exists
        }

        [TestMethod]
        public void HaveALongBow()
        {
            var sut = new PlayerCharacter();

            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            var sut = new PlayerCharacter();

            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapon()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new string[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(expectedWeapons,sut.Weapons); // order should be same

        }
        [TestMethod]
        public void HaveAllExpectedWeapon_AnyOrder()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new string[]
            {
                "Short Bow",
                "Long Bow",                
                "Short Sword"
            };

            CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons); // order can be different
        }
        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            var sut = new PlayerCharacter();

            
            CollectionAssert.AllItemsAreUnique(sut.Weapons); // order can be different
        }

        [TestMethod]
        public void HaveAtleastOneKindOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.Weapons.Any(p => p.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapon()
        {
            var sut = new PlayerCharacter();

            Assert.IsFalse(sut.Weapons.Any(p => string.IsNullOrWhiteSpace(p)));
        }
    }
}
