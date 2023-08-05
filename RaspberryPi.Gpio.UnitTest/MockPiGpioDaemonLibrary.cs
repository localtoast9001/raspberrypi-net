//-----------------------------------------------------------------------
// <copyright file="MockPiGpioDaemonLibrary.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.UnitTest
{
    using System;
    using System.Collections.Generic;
    using RaspberryPi.Gpio.Internal;

    /// <summary>
    /// Mock implementation of the daemon lib.
    /// </summary>
    internal class MockPiGpioDaemonLibrary : IPiGpioDaemonLibrary
    {
        /// <summary>
        /// Gets the list of open devices.
        /// </summary>
        public IDictionary<int, MockPi> Devices { get; } = new Dictionary<int, MockPi>();

        /// <inheritdoc/>
        public int GetMode(int pi, uint gpio)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public int GpioRead(int pi, uint gpio)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public int GpioWrite(int pi, uint gpio, uint level)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public int PiGpioStart(string? addrString, string? portString)
        {
            MockPi pi = new MockPi
            {
                AddrString = addrString,
                PortString = portString,
            };

            int id = this.Devices.Count;
            this.Devices.Add(id, pi);
            return id;
        }

        /// <inheritdoc/>
        public void PiGpioStop(int pi)
        {
            _ = this.Devices.Remove(pi);
        }

        /// <inheritdoc/>
        public int SetMode(int pi, uint gpio, uint mode)
        {
            throw new NotImplementedException();
        }
    }
}