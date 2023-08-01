//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.Internal
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Interop methods.
    /// </summary>
    internal static class NativeMethods
    {
        private const string PiGpioLibName = "pigpio";
        private const string PiGpiodInterfaceLibName = "pigpiod_if2";

        /// <summary>
        /// Init library.
        /// </summary>
        /// <returns>A value less than zero on failure; otherwise, success.</returns>
        [DllImport(
            PiGpioLibName,
            EntryPoint = "gpioInitialise",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpioInit();

        /// <summary>
        /// Terminate library.
        /// </summary>
        [DllImport(
            PiGpioLibName,
            EntryPoint = "gpioTerminate",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern void GpioTerminate();

        /// <summary>
        /// Connect to the pigpio daemon.
        /// </summary>
        /// <param name="addrString">Remote host name or <see langword="null"/> for the local Pi.</param>
        /// <param name="portString">Port or <see langword="null"/> for the default port.</param>
        /// <returns>A value greater than or equal to zero on success. The value is used as the id of the Pi for subsequent calls.</returns>
        [DllImport(
            PiGpiodInterfaceLibName,
            EntryPoint = "pigpio_start",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int PiGpioStart(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string? addrString,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string? portString);

        /// <summary>
        /// Terminates the connection to a pigpio daemon.
        /// </summary>
        /// <param name="pi">The identifier of the pi returned by <see cref="PiGpioStart"/>.</param>
        [DllImport(
            PiGpiodInterfaceLibName,
            EntryPoint = "pigpio_stop",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern void PiGpioStop(int pi);

        /// <summary>
        /// Sets the GPIO mode.
        /// </summary>
        /// <param name="pi">The identifier of the pi returned by <see cref="PiGpioStart"/>.</param>
        /// <param name="gpio">GPIO pin 0-53.</param>
        /// <param name="mode">PI_INPUT, PI_OUTPUT, PI_ALT0, PI_ALT1, PI_ALT2, PI_ALT3, PI_ALT4, PI_ALT5.</param>
        /// <returns>Returns 0 if OK; othewise PI_BAD_GPIO, PI_BAD_MODE, or PI_NOT_PERMITTED.</returns>
        [DllImport(
            PiGpiodInterfaceLibName,
            EntryPoint = "set_mode",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int SetMode(int pi, uint gpio, uint mode);

        /// <summary>
        /// Sets the GPIO mode.
        /// </summary>
        /// <param name="pi">The identifier of the pi returned by <see cref="PiGpioStart"/>.</param>
        /// <param name="gpio">GPIO pin 0-53.</param>
        /// <returns>Returns mode if OK; othewise PI_BAD_GPIO.</returns>
        [DllImport(
            PiGpiodInterfaceLibName,
            EntryPoint = "get_mode",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetMode(int pi, uint gpio);

        /// <summary>
        /// Read the GPIO level.
        /// </summary>
        /// <param name="pi">&gt;=0 (as returned by [*pigpio_start*]).</param>
        /// <param name="gpio">0-53.</param>
        /// <returns>Returns the GPIO level if OK, otherwise PI_BAD_GPIO.</returns>
        [DllImport(
            PiGpiodInterfaceLibName,
            EntryPoint = "gpio_read",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpioRead(int pi, uint gpio);

        /// <summary>
        /// Write the GPIO level.
        /// </summary>
        /// <param name="pi">&gt;=0 (as returned by [*pigpio_start*]).</param>
        /// <param name="gpio">0-53.</param>
        /// <param name="level">0, 1.</param>
        /// <returns>Returns 0 if OK, otherwise PI_BAD_GPIO, PI_BAD_LEVEL, or PI_NOT_PERMITTED.</returns>
        /// <remarks>
        /// If PWM or servo pulses are active on the GPIO they are switched off.
        /// </remarks>
        [DllImport(
            PiGpiodInterfaceLibName,
            EntryPoint = "gpio_write",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int GpioWrite(int pi, uint gpio, uint level);
    }
}
