//-----------------------------------------------------------------------
// <copyright file="PiGpioLibrary.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.Internal
{
    /// <summary>
    /// Default implementation of the pigpio C library.
    /// </summary>
    internal class PiGpioLibrary : IPiGpioLibrary
    {
        /// <summary>
        /// Gets the default library implementation.
        /// </summary>
        public static IPiGpioLibrary Default { get; } = new PiGpioLibrary();

        /// <inheritdoc/>
        public int GpioInit()
        {
            return NativeMethods.GpioInit();
        }

        /// <inheritdoc/>
        public void GpioTerminate()
        {
            NativeMethods.GpioTerminate();
        }
    }
}