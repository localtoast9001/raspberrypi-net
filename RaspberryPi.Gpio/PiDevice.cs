//-----------------------------------------------------------------------
// <copyright file="PiDevice.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.Gpio
{
    using System;
    using RaspberryPi.Gpio.Internal;

    /// <summary>
    /// Represents a single Pi device.
    /// </summary>
    public sealed class PiDevice : IPiDevice
    {
        private const int PinCount = 54;
        private readonly IPiGpioDaemonLibrary lib;
        private readonly int id;
        private readonly IGpioPin[] pins = new IGpioPin[PinCount];
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="PiDevice"/> class.
        /// </summary>
        /// <param name="lib">Daemon library interface.</param>
        /// <param name="id">The connection id.</param>
        internal PiDevice(IPiGpioDaemonLibrary lib, int id)
        {
            this.lib = lib ?? throw new ArgumentNullException(nameof(lib));
            if (this.id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            this.id = id;
            for (int i = 0; i < this.pins.Length; i++)
            {
                this.pins[i] = new GpioPin(this, i);
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PiDevice"/> class.
        /// </summary>
        ~PiDevice()
        {
            this.InnerDispose();
        }

        /// <inheritdoc/>
        public int Id => this.id;

        /// <inheritdoc/>
        public IReadOnlyList<IGpioPin> GpioPins => this.pins;

        /// <summary>
        /// Gets a reference to the library being used for this device.
        /// </summary>
        internal IPiGpioDaemonLibrary Lib => this.lib;

        /// <summary>
        /// Opens an interface to the local Pi daemon.
        /// </summary>
        /// <returns>A new instance of the <see cref="PiDevice"/> class.</returns>
        public static PiDevice Open()
        {
            return Open(null, null);
        }

        /// <summary>
        /// Opens an interface to a local or remote pi daemon.
        /// </summary>
        /// <param name="addrString">Remote server name or <see langword="null"/> for the local Pi.</param>
        /// <param name="portString">Remove server port string or <see langword="null"/> for the default port.</param>
        /// <returns>A new instance of the <see cref="PiDevice"/> class.</returns>
        public static PiDevice Open(string? addrString, string? portString)
        {
            return Open(addrString, portString, PiGpioDaemonLibrary.Default);
        }

        /// <inheritdoc/>
        public void Close()
        {
            this.Dispose();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.InnerDispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Opens an interface to a local or remote pi daemon.
        /// </summary>
        /// <param name="addrString">Remote server name or <see langword="null"/> for the local Pi.</param>
        /// <param name="portString">Remove server port string or <see langword="null"/> for the default port.</param>
        /// <param name="lib">Interface library implementation.</param>
        /// <returns>A new instance of the <see cref="PiDevice"/> class.</returns>
        internal static PiDevice Open(string? addrString, string? portString, IPiGpioDaemonLibrary lib)
        {
            int id = lib.PiGpioStart(addrString, portString);
            if (id < 0)
            {
                throw new InvalidOperationException("Unable to open a connection to pigpiod on the target device.");
            }

            return new PiDevice(lib, id);
        }

        private void InnerDispose()
        {
            if (!this.disposed)
            {
                this.lib.PiGpioStop(this.id);
                this.disposed = true;
            }
        }
    }
}