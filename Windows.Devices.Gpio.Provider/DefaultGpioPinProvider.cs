//
// Copyright (c) 2017 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//
using System;
using System.Runtime.CompilerServices;

namespace Windows.Devices.Gpio.Provider
{
    internal sealed class DefaultGpioPinProvider : IGpioPinProvider, IDisposable
    {
        
        [MethodImpl(MethodImplOptions.InternalCall)] private extern void NativeWrite(int pin, byte value);
        [MethodImpl(MethodImplOptions.InternalCall)] private extern ProviderGpioPinValue NativeRead(int pin);
        [MethodImpl(MethodImplOptions.InternalCall)] private extern void NativeSetDriveMode(int pin, ProviderGpioPinDriveMode driveMode);
        [MethodImpl(MethodImplOptions.InternalCall)] private extern bool NativeOpenpin(int pinNumber);
        [MethodImpl(MethodImplOptions.InternalCall)] private extern bool NativeIsDriveModeSupported(byte driveMode);
        [MethodImpl(MethodImplOptions.InternalCall)] private extern void NativeDispose();       //TODO: Provide native side dispose if needed

        private bool _disposed;
        private ProviderGpioPinDriveMode _pinDriveMode;
        private int _pinNumber = -1;

        public extern TimeSpan DebounceTimeout
        {
            [MethodImpl(MethodImplOptions.InternalCall)] get;
            [MethodImpl(MethodImplOptions.InternalCall)] set;
        }

        public ProviderGpioPinValue Read()
        {
            if (_pinNumber == -1) throw new InvalidOperationException();
            return NativeRead(_pinNumber);
        }

        public void Write(ProviderGpioPinValue value)
        {
            if (_pinNumber == -1) return;
            NativeWrite(_pinNumber, (byte)value);
        }

        public int PinNumber
        {
            get
            {
                if (_disposed) throw new ObjectDisposedException(null);
                return _pinNumber;
            }
        }

        public ProviderGpioSharingMode SharingMode => ProviderGpioSharingMode.Exclusive;

        public ProviderGpioPinDriveMode GetDriveMode()
        {
            if (_pinNumber == -1) throw new InvalidOperationException();
            if (_disposed) throw new ObjectDisposedException(null);

            return _pinDriveMode;
        }

        public bool IsDriveModeSupported(ProviderGpioPinDriveMode driveMode)
        {
            return NativeIsDriveModeSupported((byte) driveMode);
        }

        public void SetDriveMode(ProviderGpioPinDriveMode value)
        {
            if (_disposed) throw new ObjectDisposedException(null);
            if (!IsDriveModeSupported(value)) throw new ArgumentException();
            if (value == _pinDriveMode) return;
            if (_pinNumber == -1) return;

            NativeSetDriveMode(_pinNumber, value);
            _pinDriveMode = value;
        }

        internal bool OpenPin(int pinNumber, ProviderGpioSharingMode sharingMode)
        {
            //NOTE: sharingMode is currently ignored. Pins are used exclusively at the moment.
            if (NativeOpenpin(pinNumber))
            {
                _pinNumber = pinNumber;
                return true;
            }
            return false;
        }

        #region Dispose implementation

        public void Dispose()
        {
            if (_disposed) return;
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            NativeDispose();
        }

        ~DefaultGpioPinProvider()
        {
            Dispose(false);
        }
        #endregion
    }
}
