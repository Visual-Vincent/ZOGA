using System;
using System.Runtime.InteropServices;

namespace ZOGA.Classes
{
    public static class NativeMethods
    {
        public const uint DISPLAY_DEVICE_ATTACHED_TO_DESKTOP = 0x00000001;

        [DllImport("gdi32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetDeviceGammaRamp(IntPtr hdc, void* lpRamp);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DISPLAY_DEVICE
        {
            public int cb;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
            public string DeviceName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
            public string DeviceString;

            public uint StateFlags;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
            public string DeviceID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
            public string DeviceKey;
        }
    }
}
