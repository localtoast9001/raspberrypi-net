//-----------------------------------------------------------------------
// <copyright file="NativeMethodsTest.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.UnitTest
{
    using RaspberryPi.Gpio.Internal;

    /// <summary>
    /// Unit tests for the <see cref="NativeMethods"/> class.
    /// </summary>
    [TestClass]
    public class NativeMethodsTest
    {
        /// <summary>
        /// Tests library init.
        /// </summary>
        [TestMethod]
        [Ignore]
        public void InitTest()
        {
            int actual = NativeMethods.GpioInit();
            try
            {
                Assert.IsTrue(actual >= 0, $"actual: {actual}.");
            }
            finally
            {
                NativeMethods.GpioTerminate();
            }
        }

        /// <summary>
        /// Init local Pi using pigpiod.
        /// </summary>
        [TestMethod]
        public void InitLocalPiTest()
        {
            int actual = NativeMethods.PiGpioStart(null, null);
            Assert.IsTrue(actual >= 0, $"Expected a number greater than or equal to 0. Actual: {actual}.");
            NativeMethods.PiGpioStop(actual);
        }
   }
}
