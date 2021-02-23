using System;
using System.Runtime.InteropServices;

namespace ZOGA.Classes
{
    /// <summary>
    /// A static class providing methods for managing gamma correction.
    /// </summary>
    public static class Gamma
    {
        /// <summary>
        /// Represents the largest possible gamma correction level.
        /// </summary>
        public const float MaxValue = 4.0f;

        /// <summary>
        /// Represents the smallest possible gamma correction level.
        /// </summary>
        public const float MinValue = 0.3f; // Effective minimum (tested on Windows 10 20H2)

        /// <summary>
        /// Sets the gamma correction level on all screens.
        /// </summary>
        /// <param name="gamma">The new gamma correction level.</param>
        /// <remarks></remarks>
        public static void SetGamma(float gamma)
        {
            uint i = 0;

            while (true)
            {
                NativeMethods.DISPLAY_DEVICE display = new NativeMethods.DISPLAY_DEVICE();
                display.cb = Marshal.SizeOf(typeof(NativeMethods.DISPLAY_DEVICE));

                if (!NativeMethods.EnumDisplayDevices(null, i, ref display, 0))
                    break;

                if ((display.StateFlags & NativeMethods.DISPLAY_DEVICE_ATTACHED_TO_DESKTOP) != NativeMethods.DISPLAY_DEVICE_ATTACHED_TO_DESKTOP)
                {
                    i++;
                    continue;
                }

                // Thanks to Zalewa for finding out that CreateDC is more reliable than GetDC
                IntPtr hdc = NativeMethods.CreateDC(null, display.DeviceName, null, IntPtr.Zero);

                if (hdc != IntPtr.Zero)
                {
                    SetHdcGamma(hdc, gamma);
                    NativeMethods.DeleteDC(hdc);
                }

                i++;
            }
        }

        /// <summary>
        /// Sets the gamma correction level for a specific device context.
        /// </summary>
        /// <param name="hdc">The device context whose gamma correction level to set.</param>
        /// <param name="gamma">The new gamma correction level.</param>
        /// <remarks></remarks>
        public static bool SetHdcGamma(IntPtr hdc, float gamma)
        {
            // Originally from the Zandronum source code:
            // https://github.com/TorrSamaho/zandronum/blob/d48d3378838a7d2ad24323fd8e85eca75b9979a5/src/gl/system/gl_framebuffer.cpp#L249

            /*
            ** Copyright 2000-2007 Christoph Oelckers
            ** All rights reserved.
            **
            ** Redistribution and use in source and binary forms, with or without
            ** modification, are permitted provided that the following conditions
            ** are met:
            **
            ** 1. Redistributions of source code must retain the above copyright
            **    notice, this list of conditions and the following disclaimer.
            ** 2. Redistributions in binary form must reproduce the above copyright
            **    notice, this list of conditions and the following disclaimer in the
            **    documentation and/or other materials provided with the distribution.
            ** 3. The name of the author may not be used to endorse or promote products
            **    derived from this software without specific prior written permission.
            ** 4. When not used as part of GZDoom or a GZDoom derivative, this code will be
            **    covered by the terms of the GNU Lesser General Public License as published
            **    by the Free Software Foundation; either version 2.1 of the License, or (at
            **    your option) any later version.
            ** 5. Full disclosure of the entire project's source code, except for third
            **    party libraries is mandatory. (NOTE: This clause is non-negotiable!)
            **
            ** THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
            ** IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
            ** OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
            ** IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
            ** INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
            ** NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
            ** DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
            ** THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
            ** (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
            ** THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
            */

            ushort[] gammaTable = new ushort[768];

            gamma = MathHelper.Clamp(gamma, MinValue, MaxValue);

            // Standard values in the GZDoom/Zandronum engine
            float contrast = 1.0f;
            float bright = 0.0f;

            // This formula is taken from Doomsday
            double invgamma = 1 / gamma;
            double norm = Math.Pow(255.0, invgamma - 1);

            for (int i = 0; i < 256; i++)
            {
                double val = i * contrast - (contrast - 1) * 127;
                if(gamma != 1) val = Math.Pow(val, invgamma) / norm;
                val += bright * 128;

                gammaTable[i] = gammaTable[i + 256] = gammaTable[i + 512] = (ushort)MathHelper.Clamp(val*256, 0, 0xffff);
            }

            unsafe
            {
                fixed (void* ptr = gammaTable)
                {
                    return NativeMethods.SetDeviceGammaRamp(hdc, ptr);
                }
            }
        }
    }
}
