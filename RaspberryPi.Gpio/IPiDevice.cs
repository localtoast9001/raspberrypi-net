//-----------------------------------------------------------------------
// <copyright file="IPiDevice.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio
{
    /// <summary>
    /// Abstract Pi device that can be mocked for unit tests.
    /// </summary>
    public interface IPiDevice : IDisposable
    {
        /// <summary>
        /// Gets the id of the connection to the device.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the array of GPIO pins.
        /// </summary>
        IReadOnlyList<IGpioPin> GpioPins { get; }

        /// <summary>
        /// Closes the device and connection to the daemon.
        /// </summary>
        void Close();
    }
}