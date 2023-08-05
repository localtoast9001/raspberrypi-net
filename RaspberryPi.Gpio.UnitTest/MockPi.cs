//-----------------------------------------------------------------------
// <copyright file="MockPi.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace RaspberryPi.Gpio.UnitTest
{
    /// <summary>
    /// Mock Pi device implementation used by <see cref="MockPiGpioDaemonLibrary"/>.
    /// </summary>
    internal class MockPi
    {
        /// <summary>
        /// Gets or sets the address string.
        /// </summary>
        public string? AddrString { get; set; }

        /// <summary>
        /// Gets or sets the port string.
        /// </summary>
        public string? PortString { get; set; }
    }
}