//-----------------------------------------------------------------------
// <copyright file="IGpioPin.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio
{
    /// <summary>
    /// Abstract interface for a single GPIO pin.
    /// </summary>
    public interface IGpioPin
    {
        /// <summary>
        /// Gets the number of the pin.
        /// </summary>
        int Pin { get; }

        /// <summary>
        /// Gets or sets the mode of the pin.
        /// </summary>
        GpioMode Mode { get; set; }

        /// <summary>
        /// Reads the logic level of the pin.
        /// </summary>
        /// <returns><c>True</c> if the logic level is on; <c>false</c> if the logic level is off.</returns>
        bool Read();

        /// <summary>
        /// Writes a logic level to the pin.
        /// </summary>
        /// <param name="level"><c>true</c> to set the pin high or on; <c>false</c> to set the pin lo or off.</param>
        void Write(bool level);
    }
}