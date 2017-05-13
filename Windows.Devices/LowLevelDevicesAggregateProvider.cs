//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//
using Windows.Devices.Gpio.Provider;

namespace Windows.Devices
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LowLevelDevicesAggregateProvider : ILowLevelDevicesAggregateProvider
    {
        /// <summary>
        /// </summary>
        public IGpioControllerProvider GpioControllerProvider { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LowLevelDevicesAggregateProvider"/> class.
        /// </summary>
        /// <param name="gpio">The gpio.</param>
        public LowLevelDevicesAggregateProvider(IGpioControllerProvider gpio)
        {
            GpioControllerProvider = gpio;
        }
    }
}
