using Core.Utilities.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    [TestFixture]
    public class PasswordTest
    {
        [Test]
        public void CheckUserPassword()
        {
            HashingHelper.HashPassword("axmed123", out byte[] passwordHash, out byte[] paswordSalt);
            var data = HashingHelper.VerifyPassword("axmed123", passwordHash, paswordSalt);
            Assert.True(data);
        }

        [Test]
        public void CheckUserWrongPassword()
        {
            HashingHelper.HashPassword("axmed123", out byte[] passwordHash, out byte[] paswordSalt);
            var data = HashingHelper.VerifyPassword("axmed1234", passwordHash, paswordSalt);
            Assert.False(data);
        }
    }
}
