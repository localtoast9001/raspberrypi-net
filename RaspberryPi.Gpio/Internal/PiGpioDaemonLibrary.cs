//-----------------------------------------------------------------------
// <copyright file="PiGpioDaemonLibrary.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.Internal
{
    /// <summary>
    /// Real implementation of the pigpiod interface library.
    /// </summary>
    internal class PiGpioDaemonLibrary : IPiGpioDaemonLibrary
    {
        /// <summary>
        /// Gets the singleton default library.
        /// </summary>
        public static IPiGpioDaemonLibrary Default { get; } = new PiGpioDaemonLibrary();

        /// <inheritdoc/>
        public int PiGpioStart(
            string? addrString,
            string? portString)
        {
            return NativeMethods.PiGpioStart(addrString, portString);
        }

        /// <inheritdoc/>
        public void PiGpioStop(int pi)
        {
            NativeMethods.PiGpioStop(pi);
        }

        /// <inheritdoc/>
        public int SetMode(int pi, uint gpio, uint mode)
        {
            return NativeMethods.SetMode(pi, gpio, mode);
        }

        /// <inheritdoc/>
        public int GetMode(int pi, uint gpio)
        {
            return NativeMethods.GetMode(pi, gpio);
        }

        /// <inheritdoc/>
        public int GpioRead(int pi, uint gpio)
        {
            return NativeMethods.GpioRead(pi, gpio);
        }

        /// <inheritdoc/>
        public int GpioWrite(int pi, uint gpio, uint level)
        {
            return NativeMethods.GpioWrite(pi, gpio, level);
        }
    }
}