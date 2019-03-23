using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {

        PlayerCharacter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PlayerCharacter();
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        //[Ignore]
        public void BeInexperiencedWhenNew()
        {
            

            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        [TestCategory("Player Defaults")]
        //[Ignore("Ignore for Refactoring")] un comment to ignore with message
        public void NotHaveNickNameByDefault()
        {
           
            Assert.IsNull(sut.Nickname);
        }
        [TestMethod]
        [TestCategory("Player Defaults")]
        public void StartWithDefaultHealth()
        {           

            Assert.AreEqual(100, sut.Health);
        }

        public static IEnumerable<object[]> Damages
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1,99},
                    new object[]{0,100},
                    new object[]{100,1},
                    new object[]{101,1},
                    new object[]{ 50,50}
                };
            }
        }

        public static IEnumerable<object[]> GetDamages()
        {

            return new List<object[]>
                {
                    new object[]{1,99},
                    new object[]{0,100},
                    new object[]{100,1},
                    new object[]{101,1},
                    new object[]{ 50,50}
                };
        }

        [DataTestMethod]
        //[DynamicData(nameof(Damages))]
        //[DynamicData(nameof(GetDamages),DynamicDataSourceType.Method)
        [DynamicData(nameof(DamageData.GetDamages),typeof(DamageData), DynamicDataSourceType.Method)]
        [DynamicData(nameof(ExternalHealthDamageTestData.TestData), typeof(ExternalHealthDamageTestData), DynamicDataSourceType.Property)]
        //[DataRow(1,99)]
        //[DataRow(0, 100)]
        //[DataRow(100, 1)]
        //[DataRow(101, 1)]
        [TestCategory("Player Health")]
        public void TakeDamage(int damage,int expectedHealth)
        {
            

            sut.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, sut.Health);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamage_NotEqual()
        {          

            sut.TakeDamage(1);

            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void IncreaseHealthAfterSleeping()
        {

            sut.Sleep();

            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {          
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            // Assert.AreEqual("Sarah Smith", sut.FullName);// case sensitive on string
            Assert.AreEqual("SARAH SMITH", sut.FullName,true);

        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {          

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.StartsWith(sut.FullName,"Sarah");
        }

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {

           

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.EndsWith(sut.FullName, "Smith");
        }


        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {

          

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.Contains(sut.FullName, "ah Sm");
        }


        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            //Complimentary string doesNotMatch exists
        }

        [TestMethod]
        public void HaveALongBow()
        {
           

            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
         
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapon()
        {
           

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
           
            
            CollectionAssert.AllItemsAreUnique(sut.Weapons); // order can be different
        }

        [TestMethod]
        public void HaveAtleastOneKindOfSword()
        {
            

            Assert.IsTrue(sut.Weapons.Any(p => p.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapon()
        {
            Assert.IsFalse(sut.Weapons.Any(p => string.IsNullOrWhiteSpace(p)));
        }
    }
}
