using NUnit.Framework;
using IIG.PasswordHashingUtils;
namespace TestLab3
{
    public class Tests
    {


        
        [Test]
        public void AreInitAndGetHashEqual()
        {
            string salt = "do u have a sigarette";
            PasswordHasher.Init(salt, 65521);
            string resultHash = PasswordHasher.GetHash("gimmeone", salt, 65521);
            Assert.AreEqual(PasswordHasher.GetHash("gimmeone"), resultHash);
        }

        [Test]
        public void DefaultValues()
        {
            string salt = "do u have a sigarette";
            string defaultHash = PasswordHasher.GetHash("gimmeone");
            string resultHash = PasswordHasher.GetHash("gimmeone", salt, 65521);
            Assert.AreEqual(defaultHash, resultHash);
        }


        [Test]
        [TestCase("do u have a sigarette")]
        [TestCase(null)]
        [TestCase("日本動畫片")]
        [TestCase("")]
        public void SaltExceptsNotNull(string salt)
        {
            string password = "gimmeone";
            string result = PasswordHasher.GetHash(password, salt, 65521);
            Assert.NotNull(result);

        }

        public class TestAdler
        {
            [Test]
            public void AnotherAdler()
            {
                string salt = "do u have a sigarette";
                string password = "gimmeone";
                string result = PasswordHasher.GetHash(password, salt, 42);
                Assert.NotNull(result);
            }
            [Test]
            public void AdlerZero()
            {
                string salt = "do u have a sigarette";
                string password = "gimmeone";
                string result = PasswordHasher.GetHash(password, salt, 0);
                Assert.NotNull(result);
            }

            [Test]
            public void AdlerIsEmpty()
            {

                string salt = "do u have a sigarette";
                string password = "gimmeone";
                string result = PasswordHasher.GetHash(password, salt);
                Assert.NotNull(result);
            }
        }

        public class TestPassword
        {
            [Test]
            public void PasswordString()
            {
                string password = "gimme1or2";
                string result = PasswordHasher.GetHash(password);
                Assert.NotNull(result);
            }

            [Test]
            public void EmptyPassword()
            {
                string salt = "do u have a sigarette";
                string password = "";
                string result = PasswordHasher.GetHash(password, salt, 65521);
                Assert.NotNull(result);

            }
            public void PasswordIsNull()
            {
                string pass = null;
                string salt = "do u have a sigarette";
                string result = PasswordHasher.GetHash(pass, salt, 65521);
                Assert.Null(result);
            }


            [Test]
            public void PasswordSymbols()
            {
                string password = "日本動畫片!";
                string salt = "do u have a sigarette";

                string result = PasswordHasher.GetHash(password, salt, 65521);
                Assert.NotNull(result);

            }


        }
    }
}
