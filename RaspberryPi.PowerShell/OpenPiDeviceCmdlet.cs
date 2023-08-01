//-----------------------------------------------------------------------
// <copyright file="OpenPiDeviceCmdlet.cs" company="Jon Rowlett">
//      Copyright (C) Jon Rowlett. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace RaspberryPi.PowerShell
{
    using System.Management.Automation;
    using RaspberryPi.Gpio;

    /// <summary>
    /// Cmdlet to open a pi device.
    /// </summary>
    [Cmdlet(VerbsCommon.Open, Nouns.PiDevice)]
    [OutputType(typeof(PiDevice))]
    public class OpenPiDeviceCmdlet : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [Parameter]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        [Parameter]
        public int? Port { get; set; }

        /// <inheritdoc/>
        protected override void BeginProcessing()
        {
            string? portString = null;
            if (this.Port != null)
            {
                portString = this.Port!.ToString();
            }

            this.WriteObject(PiDevice.Open(this.Address, portString));
        }
    }
}