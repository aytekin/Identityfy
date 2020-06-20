using Identityfy.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Core
{
    [TestClass]
    public class TrIdentityTest
    {
        [TestMethod]
        public void ValidateTRINO_ValidValue()
        {
            var result = TRIdentity.ValidateTRINO("75230734056");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateTRINO_InvalidValueNinthDigit()
        {
            var result = TRIdentity.ValidateTRINO("75230734016");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateTRINO_InvalidValueTenthDigit()
        {
            var result = TRIdentity.ValidateTRINO("75230734052");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateTRINO_ShortLengthValue()
        {
            var result = TRIdentity.ValidateTRINO("7523073");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateTRINO_LongLengthValue()
        {
            var result = TRIdentity.ValidateTRINO("75230734056921912");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateTRINO_FirstDigitZero()
        {
            var result = TRIdentity.ValidateTRINO("05230734056");

            Assert.IsFalse(result);
        }



        [TestMethod]
        public void GetRandomValidTRINO_GetResult()
        {
            var result = TRIdentity.GetRandomValidTRINO();
            var validation = TRIdentity.ValidateTRINO(result);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.IsTrue(validation);

        }



    }
}
