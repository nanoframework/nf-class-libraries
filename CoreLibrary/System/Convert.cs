//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Specifies whether relevant Convert.ToBase64CharArray and Convert.ToBase64String methods insert line breaks in their output.
    /// </summary>
    [Flags]
    public enum Base64FormattingOptions
    {
        /// <summary>
        /// Does not insert line breaks after every 76 characters in the string representation.
        /// </summary>
        None = 0,
        /// <summary>
        /// Inserts line breaks after every 76 characters in the string representation.
        /// </summary>
        InsertLineBreaks = 1
    }

    //We don't want to implement this whole class, but VB needs an external function to convert any integer type to a Char.
    /// <summary>
    /// Converts a base data type to another base data type.
    /// </summary>
    [ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)]
    public static class Convert
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int NativeToInt32(string hexNumber, int fromBase);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern long NativeToInt64(string value, bool signed, long min, long max);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern double NativeToDouble(string s);

        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer to convert.</param>
        /// <returns>A Unicode character that is equivalent to value.</returns>
        [CLSCompliant(false)]
        public static char ToChar(ushort value)
        {
            return (char)value;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>An 8-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static sbyte ToSByte(string value)
        {
            return (sbyte)NativeToInt64(value, true, SByte.MinValue, SByte.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>An 8-bit unsigned integer that is equivalent to value, or zero if value is null.</returns>
        public static byte ToByte(string value)
        {
            return (byte)NativeToInt64(value, false, Byte.MinValue, Byte.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 16-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static short ToInt16(string value)
        {
            return (short)NativeToInt64(value, true, Int16.MinValue, Int16.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 16-bit unsigned integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static ushort ToUInt16(string value)
        {
            return (ushort)NativeToInt64(value, false, UInt16.MinValue, UInt16.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static int ToInt32(string value)
        {
            return (int)NativeToInt64(value, true, Int32.MinValue, Int32.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 32-bit unsigned integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static uint ToUInt32(string value)
        {
            return (uint)NativeToInt64(value, false, UInt32.MinValue, UInt32.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A string that contains a number to convert.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static long ToInt64(string value)
        {
            return NativeToInt64(value, true, Int64.MinValue, Int64.MaxValue);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A string that contains the number to convert.</param>
        /// <returns>A 64-bit signed integer that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        [CLSCompliant(false)]
        public static ulong ToUInt64(string value)
        {
            return (ulong)NativeToInt64(value, false, 0, 0);
        }

        /// <summary>
        /// Converts the string representation of a number in a specified base to an equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="hexNumber">A string that contains the number to convert.</param>
        /// <param name="fromBase">The base of the number in value, which must be between 2 and 36 inclusive.</param>
        /// <returns>A 32-bit signed integer that is equivalent to the number in value, or 0 (zero) in case of error.</returns>
        public static int ToInt32(string hexNumber, int fromBase)
        {
            return NativeToInt32(hexNumber, fromBase);
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double-precision floating-point number.
        /// </summary>
        /// <param name="s">A string that contains the number to convert.</param>
        /// <returns>A double-precision floating-point number that is equivalent to the number in value, or 0 (zero) if value is null.</returns>
        public static double ToDouble(string s)
        {
            return NativeToDouble(s);
        }

        /*
        private static long ToInt64(string value, bool signed, long min, long max)
        {
            return NativeToInt64(value, signed, min, max);
        }
        */
/*
        private static double GetDoubleNumber(char[] chars, int start, int length, out int numLeadingZeros)
        {
            double number = 0;
            var isNeg = false;
            var end = start + length;

            numLeadingZeros = 0;

            if (chars[start] == '-')
            {
                isNeg = true;
                start++;
            }
            else if (chars[start] == '+')
            {
                start++;
            }

            for (var i = start; i < end; i++)
            {
                int digit;
                var c = chars[i];

                // switch statement is faster than subtracting '0'                
                switch (c)
                {
                    case '0':
                        // update the number of leading zeros (used for normalizing)
                        if (numLeadingZeros + start == i)
                        {
                            numLeadingZeros++;
                        }
                        digit = 0;
                        break;
                    case '1':
                        digit = 1;
                        break;
                    case '2':
                        digit = 2;
                        break;
                    case '3':
                        digit = 3;
                        break;
                    case '4':
                        digit = 4;
                        break;
                    case '5':
                        digit = 5;
                        break;
                    case '6':
                        digit = 6;
                        break;
                    case '7':
                        digit = 7;
                        break;
                    case '8':
                        digit = 8;
                        break;
                    case '9':
                        digit = 9;
                        break;
                    default:
                        throw new Exception();
                }

                number *= 10;
                number += digit;
            }

            return isNeg ? -number : number;
        }
*/

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent String representation encoded with base 64 digits.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers. </param>
        /// <returns>The String representation, in base 64, of the contents of <paramref name="inArray"/>.</returns>
        public static string ToBase64String(byte[] inArray)
        {
            if (inArray == null) throw new ArgumentNullException();

            return ToBase64String(inArray, 0, inArray.Length, Base64FormattingOptions.None);
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits. A parameter specifies whether to insert line breaks in the return value.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers.</param>
        /// <param name="options"><see cref="Base64FormattingOptions.InsertLineBreaks"/> to insert a line break every 76 characters, or None to not insert line breaks.</param>
        /// <returns>The string representation in base 64 of the elements in <paramref name="inArray"/>.</returns>
        public static String ToBase64String(byte[] inArray, Base64FormattingOptions options)
        {
            if (inArray == null) throw new ArgumentNullException();

            return ToBase64String(inArray, 0, inArray.Length, options);
        }

        /// <summary>
        /// Converts a subset of an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits. Parameters specify the subset as an offset in the input array, the number of elements in the array to convert, and whether to insert line breaks in the return value.
        /// </summary>
        /// <param name="inArray">An array of 8-bit unsigned integers. </param>
        /// <param name="offset">An offset in <paramref name="inArray"/>.</param>
        /// <param name="length">The number of elements of <paramref name="inArray"/> to convert.</param>
        /// <param name="options">cref="System.InsertLineBreaks" to insert a line break every 76 characters, or None to not insert line breaks.</param>
        /// <returns>The string representation in base 64 of <paramref name="length"/> elements of <paramref name="inArray"/>, starting at position <paramref name="offset"/>.</returns>
        public static string ToBase64String(byte[] inArray, int offset, int length, Base64FormattingOptions options)
        {
            //Do data verfication
            if (inArray == null) throw new ArgumentNullException();
            if (length < 0) throw new ArgumentOutOfRangeException();
            if (offset < 0) throw new ArgumentOutOfRangeException();
            if (options < Base64FormattingOptions.None || options > Base64FormattingOptions.InsertLineBreaks) throw new ArgumentException();

            return ToBase64String(inArray, offset, length);
        }

        /// <summary>
        /// Conversion array from 6 bit of value into base64 encoded character.
        /// </summary>
        private static readonly char[] RgchBase64EncodingDefault = {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', /* 12 */
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', /* 24 */
            'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', /* 36 */
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', /* 48 */
            'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', /* 60 */
            '8', '9', '!', '*'            /* 64 */
        };

        private static readonly char[] RgchBase64Encoding = RgchBase64EncodingDefault;

        private static readonly byte[] RgbBase64Decode = {
            // Note we also accept ! and + interchangably.
            // Note we also accept * and / interchangably.
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, /*   0 -   7 */
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, /*   8 -  15 */
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, /*  16 -  23 */
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, /*  24 -  31 */
            0x00, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, /*  32 -  39 */
            0x00, 0x00, 0x3f, 0x3e, 0x00, 0x00, 0x00, 0x3f, /*  40 -  47 */
            0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, /*  48 -  55 */
            0x3c, 0x3d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, /*  56 -  63 */
            0x00, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, /*  64 -  71 */
            0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, /*  72 -  79 */
            0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, /*  80 -  87 */
            0x17, 0x18, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, /*  88 -  95 */
            0x00, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f, 0x20, /*  96 - 103 */
            0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, /* 104 - 111 */
            0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 0x30, /* 112 - 119 */
            0x31, 0x32, 0x33, 0x00, 0x00, 0x00, 0x00, 0x00  /* 120 - 127 */
        };

        // ReSharper disable InconsistentNaming
        private const int CCH_B64_IN_QUARTET = 4;
        private const int CB_B64_OUT_TRIO = 3;
        // ReSharper restore InconsistentNaming

        private static int GetBase64EncodedLength(int binaryLen)
        {
            return (binaryLen / 3 + (binaryLen % 3 != 0 ? 1 : 0)) * 4;
        }

        private static string ToBase64String(byte[] inArray, int offset, int length)
        {
            if (inArray == null) throw new ArgumentNullException();
            if (length == 0) return "";
            if (offset + length > inArray.Length) throw new ArgumentOutOfRangeException();

            // Create array of characters with appropriate length.
            var inArrayLen = length;
            var outArrayLen = GetBase64EncodedLength(inArrayLen);
            var outArray = new char[outArrayLen];

            /* encoding starts from end of string */

            /*
            ** Convert the input buffer bytes through the encoding table and
            ** out into the output buffer.
            */
            var iInputEnd = offset + (outArrayLen / CCH_B64_IN_QUARTET - 1) * CB_B64_OUT_TRIO;
            int iInput = offset, iOutput = 0;
            byte uc0, uc1, uc2;
            // Loop is for all trios except of last one.
            for (; iInput < iInputEnd; iInput += CB_B64_OUT_TRIO, iOutput += CCH_B64_IN_QUARTET)
            {
                uc0 = inArray[iInput];
                uc1 = inArray[iInput + 1];
                uc2 = inArray[iInput + 2];
                // Writes data to output character array.
                outArray[iOutput] = RgchBase64Encoding[uc0 >> 2];
                outArray[iOutput + 1] = RgchBase64Encoding[((uc0 << 4) & 0x30) | ((uc1 >> 4) & 0xf)];
                outArray[iOutput + 2] = RgchBase64Encoding[((uc1 << 2) & 0x3c) | ((uc2 >> 6) & 0x3)];
                outArray[iOutput + 3] = RgchBase64Encoding[uc2 & 0x3f];
            }

            // Now we process the last trio of bytes. This trio might be incomplete and thus require special handling.
            // This code could be incorporated into main "for" loop, but hte code would be slower becuase of extra 2 "if"
            uc0 = inArray[iInput];
            uc1 = iInput + 1 < offset + inArrayLen ? inArray[iInput + 1] : (byte)0;
            uc2 = iInput + 2 < offset + inArrayLen ? inArray[iInput + 2] : (byte)0;
            // Writes data to output character array.
            outArray[iOutput] = RgchBase64Encoding[uc0 >> 2];
            outArray[iOutput + 1] = RgchBase64Encoding[((uc0 << 4) & 0x30) | ((uc1 >> 4) & 0xf)];
            outArray[iOutput + 2] = RgchBase64Encoding[((uc1 << 2) & 0x3c) | ((uc2 >> 6) & 0x3)];
            outArray[iOutput + 3] = RgchBase64Encoding[uc2 & 0x3f];

            switch (inArrayLen % CB_B64_OUT_TRIO)
            {
                /*
                ** One byte out of three, add padding and fall through
                */
                case 1:
                    outArray[outArrayLen - 2] = '=';
                    goto case 2;
                /*
                ** Two bytes out of three, add padding.
                */
                case 2:
                    outArray[outArrayLen - 1] = '=';
                    break;
            }

            // Creates string out of character array and return it.
            return new string(outArray);
        }

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="inString">The string to convert.</param>
        /// <returns>An array of 8-bit unsigned integers that is equivalent to <paramref name="inString"/></returns>
        /// <remarks>s is composed of base-64 digits, white-space characters, and trailing padding characters. The base-64 digits in ascending order from zero are the uppercase characters "A" to "Z", lowercase characters "a" to "z", numerals "0" to "9", and the symbols "+" and "/".
        /// The white-space characters, and their Unicode names and hexadecimal code points, are tab(CHARACTER TABULATION, U+0009), newline(LINE FEED, U+000A), carriage return (CARRIAGE RETURN, U+000D), and blank(SPACE, U+0020). An arbitrary number of white-space characters can appear in s because all white-space characters are ignored.
        /// The valueless character, "=", is used for trailing padding. The end of s can consist of zero, one, or two padding characters.
        /// </remarks>
        public static byte[] FromBase64String(string inString)
        {
            if (inString == null) throw new ArgumentNullException();

            var chArray = inString.ToCharArray();

            return FromBase64CharArray(chArray, 0, chArray.Length);
        }

        /// <summary>
        /// Converts a subset of a Unicode character array, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array. Parameters specify the subset in the input array and the number of elements to convert.
        /// </summary>
        /// <param name="inArray">A Unicode character array.</param>
        /// <param name="offset">A position within <paramref name="inArray"/>.</param>
        /// <param name="length">The number of elements in <paramref name="inArray"/> to convert. </param>
        /// <returns>An array of 8-bit unsigned integers equivalent to <paramref name="length"/> elements at position <paramref name="offset"/> in <paramref name="inArray"/>.</returns>
        public static byte[] FromBase64CharArray(char[] inArray, int offset, int length)
        {
            if (inArray == null) throw new ArgumentNullException();
            if (length < 0) throw new ArgumentOutOfRangeException();
            if (offset < 0) throw new ArgumentOutOfRangeException();
            if (offset > inArray.Length - length) throw new ArgumentOutOfRangeException();

            // copy to new array
            var destinationArray = new char[length];
            Array.Copy(inArray, offset, destinationArray, 0, length);

            if (length == 0) return new byte[0];

            // Checks that length of string is multiple of 4
            var inLength = length;
            if (inLength % CCH_B64_IN_QUARTET != 0) throw new ArgumentException("Encoded string length should be multiple of 4");

            // Maximum buffer size needed.
            var outCurPos = (inLength + (CCH_B64_IN_QUARTET - 1)) / CCH_B64_IN_QUARTET * CB_B64_OUT_TRIO;
            if (inArray[offset + inLength - 1] == '=')
            {   // If the last was "=" - it means last byte was padded/
                --outCurPos;
                // If one more '=' - two bytes were actually padded.
                if (inArray[offset + inLength - 2] == '=') --outCurPos;
            }

            // Output array.
            var retArray = new byte[outCurPos];
            // Array of 4 bytes - temporary.
            var rgbOutput = new byte[CCH_B64_IN_QUARTET];
            // Loops over each 4 bytes quartet.
            for (var inCurPos = offset + inLength;
                inCurPos > offset;
                inCurPos -= CCH_B64_IN_QUARTET)
            {
                var ibDest = 0;
                for (; ibDest < CB_B64_OUT_TRIO + 1; ibDest++)
                {
                    var ichGet = inCurPos + ibDest - CCH_B64_IN_QUARTET;
                    // Equal sign can be only at the end and maximum of 2
                    if (inArray[ichGet] == '=')
                    {
                        if (ibDest < 2 || inCurPos != offset + inLength) throw new ArgumentException("Invalid base64 encoded string");
                        break;
                    }
                    // Applies decoding table to the character.
                    rgbOutput[ibDest] = RgbBase64Decode[inArray[ichGet]];
                }

                // Convert 4 bytes in rgbOutput, each having 6 bits into three bytes in final data.
                switch (ibDest)
                {
                    default:
                        retArray[--outCurPos] = (byte)(((rgbOutput[2] & 0x03) << 6) | rgbOutput[3]);
                        goto case 3;

                    case 3:
                        retArray[--outCurPos] = (byte)(((rgbOutput[1] & 0x0F) << 4) | ((rgbOutput[2] & 0x3C) >> 2));
                        goto case 2;

                    case 2:
                        retArray[--outCurPos] = (byte)((rgbOutput[0] << 2) | ((rgbOutput[1] & 0x30) >> 4));
                        break;
                }
            }

            return retArray;
        }
    }
}
