//-----------------------------------------------------------------------
// <copyright file="GpioPin.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio.Internal
{
    /// <summary>
    /// GPIO pin that uses the pigpiod library.
    /// </summary>
    internal class GpioPin : IGpioPin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GpioPin"/> class.
        /// </summary>
        /// <param name="device">The device owning this pin.</param>
        /// <param name="pin">The number of the pin.</param>
        internal GpioPin(PiDevice device, int pin)
        {
            this.Pin = pin;
            this.Device = device ?? throw new ArgumentNullException(nameof(device));
        }

        /// <inheritdoc/>
        public int Pin { get; }

        /// <inheritdoc/>
        public GpioMode Mode
        {
            get
            {
                int mode = this.Device.Lib.GetMode(this.Device.Id, (uint)this.Pin);
                if (mode < 0)
                {
                    throw new InvalidOperationException($"Internal error. Unexpected error code {mode} returned from get_mode");
                }

                return (GpioMode)mode;
            }

            set
            {
                uint mode = (uint)value;
                if (mode > 7)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                int result = this.Device.Lib.SetMode(this.Device.Id, (uint)this.Pin, mode);
                if (result < 0)
                {
                    throw new InvalidOperationException($"Internal error. Unexpected error code {result} returned from set_mode");
                }
            }
        }

        /// <summary>
        /// Gets a reference to the device that has this pin.
        /// </summary>
        internal PiDevice Device { get; }

        /// <inheritdoc/>
        public bool Read()
        {
            int level = this.Device.Lib.GpioRead(this.Device.Id, (uint)this.Pin);
            if (level < 0)
            {
                throw new InvalidOperationException($"Internal error. Unexpected error code {level} returned from gpio_read.");
            }

            return level != 0;
        }

        /// <inheritdoc/>
        public void Write(bool level)
        {
            int result = this.Device.Lib.GpioWrite(this.Device.Id, (uint)this.Pin, level ? 1U : 0U);
            if (result < 0)
            {
                throw new InvalidOperationException($"Internal error. Unexpected error code {result} returned from gpio_write.");
            }
        }
    }
}