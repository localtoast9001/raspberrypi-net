//-----------------------------------------------------------------------
// <copyright file="PiDeviceTest.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.UnitTest
{
    /// <summary>
    /// Unit tests for the <see cref="PiDevice"/> class.
    /// </summary>
    [TestClass]
    public class PiDeviceTest
    {
        /// <summary>
        /// Unit test for the <see cref="PiDevice.Open(string?, string?, Internal.IPiGpioDaemonLibrary)"/> method.
        /// </summary>
        [TestMethod]
        public void OpenTest()
        {
            MockPiGpioDaemonLibrary lib = new MockPiGpioDaemonLibrary();
            PiDevice target = PiDevice.Open(null, null, lib);
            Assert.IsNotNull(target);
        }
    }
}