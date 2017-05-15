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
    public sealed class LowLevelDevicesController
    {
        /// <summary>
        /// Gets or sets the default provider.
        /// </summary>
        /// <value>
        /// The default provider.
        /// </value>
        public static ILowLevelDevicesAggregateProvider DefaultProvider { get; set; } = new LowLevelDevicesAggregateProvider(
                DefaultGpioControllerProvider.ControllerProviderInstance);
    }
}
