using NUnit.Framework;

namespace No1.Solution.Tests
{
    [TestFixture]
    public class TestPasswodChecker
    {
        [Test]
        public void TestDefaultValidatorWithSqlRepository()
        {
            IRepository repository = new SqlRepository();
            var pcs = new PasswordCheckerService(repository);

            Assert.That(pcs.VerifyPassword("pa55word").Item2, Is.EqualTo("Password is Ok. User was created"));
            Assert.That(pcs.VerifyPassword(string.Empty).Item2, Is.EqualTo("password is empty"));
            Assert.That(pcs.VerifyPassword("a1").Item2, Is.EqualTo("a1 length too short"));
            Assert.That(pcs.VerifyPassword("abcdef0123456789").Item2, Is.EqualTo("abcdef0123456789 length too long"));
            Assert.That(pcs.VerifyPassword("abcdefghij").Item2, Is.EqualTo("abcdefghij hasn't digits"));
            Assert.That(pcs.VerifyPassword("0123456789").Item2, Is.EqualTo("0123456789 hasn't alphanumerical chars"));
        }

        [Test]
        public void TestCustomValidatorWithSqlRepository()
        {
            IRepository repository = new SqlRepository();
            var pcs = new PasswordCheckerService(repository);
            
            Assert.That(pcs.VerifyPassword("pa55word", CustomValidator.Validate).Item2, Is.EqualTo("Password is Ok. User was created"));
            Assert.That(pcs.VerifyPassword(string.Empty, CustomValidator.Validate).Item2, Is.EqualTo("password is empty"));
            Assert.That(pcs.VerifyPassword("a1", CustomValidator.Validate).Item2, Is.EqualTo("a1 length too short"));
            Assert.That(pcs.VerifyPassword("abcdef0123456789", CustomValidator.Validate).Item2, Is.EqualTo("abcdef0123456789 length too long"));
            Assert.That(pcs.VerifyPassword("admin0", CustomValidator.Validate).Item2, Is.EqualTo("admin0 can't contain admin word"));
            Assert.That(pcs.VerifyPassword("abc123!", CustomValidator.Validate).Item2, Is.EqualTo("abc123! contains unavailable symbols"));
        }
    }
}
