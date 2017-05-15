//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//
using System;
using System.Runtime.CompilerServices;

namespace Windows.Devices.Gpio.Provider
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IGpioControllerProvider" />
    public sealed class DefaultGpioControllerProvider : IGpioControllerProvider
    {
        /// <summary>
        /// Gets the controller provider instance.
        /// </summary>
        /// <value>
        /// The controller provider instance.
        /// </value>
        public static DefaultGpioControllerProvider ControllerProviderInstance { get; } = new DefaultGpioControllerProvider();

        /// <summary>
        /// Gets the number of general-purpose I/O (GPIO) pins available.
        /// </summary>
        /// <value>
        /// The number of GPIO pins available.
        /// </value>
        public extern int PinCount
        {
            [MethodImpl(MethodImplOptions.InternalCall)] get;
        }

        /// <summary>
        /// Opens the pin provider.
        /// </summary>
        /// <param name="pinNumber">The pin number.</param>
        /// <param name="sharingMode">The sharing mode.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public IGpioPinProvider OpenPinProvider(int pinNumber, ProviderGpioSharingMode sharingMode)
        {
            var defaultGpioPinProvider = new DefaultGpioPinProvider();

            if (defaultGpioPinProvider.OpenPin(pinNumber, sharingMode)) return defaultGpioPinProvider;
            throw new InvalidOperationException();
        }
    }
}
