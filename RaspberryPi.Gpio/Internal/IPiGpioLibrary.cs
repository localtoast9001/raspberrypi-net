//-----------------------------------------------------------------------
// <copyright file="IPiGpioLibrary.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.Internal
{
    /// <summary>
    /// Mockable interface for the pigpio C library (libpigpio).
    /// </summary>
    internal interface IPiGpioLibrary
    {
        /// <summary>
        /// Init library.
        /// </summary>
        /// <returns>A value less than zero on failure; otherwise, success.</returns>
        int GpioInit();

        /// <summary>
        /// Terminate library.
        /// </summary>
        void GpioTerminate();
    }
}