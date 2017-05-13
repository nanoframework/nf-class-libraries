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
    public interface ILowLevelDevicesAggregateProvider
    {
        /// <summary>
        /// 
        /// </summary>
        IGpioControllerProvider GpioControllerProvider { get; }
    }
}
