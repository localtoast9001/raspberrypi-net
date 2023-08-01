//-----------------------------------------------------------------------
// <copyright file="GpioMode.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio
{
    /// <summary>
    /// Mode that can be set on each <see cref="IGpioPin"/>.
    /// </summary>
    public enum GpioMode
    {
        /// <summary>
        /// PI_INPUT.
        /// </summary>
        Input = 0,

        /// <summary>
        /// PI_OUTPUT.
        /// </summary>
        Output = 1,

        /// <summary>
        /// PI_ALT0.
        /// </summary>
        Alt0 = 4,

        /// <summary>
        /// PI_ALT1.
        /// </summary>
        Alt1 = 5,

        /// <summary>
        /// PI_ALT2.
        /// </summary>
        Alt2 = 6,

        /// <summary>
        /// PI_ALT3.
        /// </summary>
        Alt3 = 7,

        /// <summary>
        /// PI_ALT4.
        /// </summary>
        Alt4 = 3,

        /// <summary>
        /// PI_ALT5.
        /// </summary>
        Alt5 = 2,
    }
}