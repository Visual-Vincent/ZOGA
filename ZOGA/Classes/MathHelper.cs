using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZOGA.Classes
{
    /// <summary>
    /// An extension to the Math class.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Clamps the specified value between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <remarks></remarks>
        public static int Clamp(int value, int min, int max)
        {
            if (value > max)
                return max;
            else if (value < min)
                return min;

            return value;
        }

        /// <summary>
        /// Clamps the specified value between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <remarks></remarks>
        public static long Clamp(long value, long min, long max)
        {
            if (value > max)
                return max;
            else if (value < min)
                return min;

            return value;
        }

        /// <summary>
        /// Clamps the specified value between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <remarks></remarks>
        public static double Clamp(double value, double min, double max)
        {
            if (value > max)
                return max;
            else if (value < min)
                return min;

            return value;
        }

        /// <summary>
        /// Clamps the specified value between <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <remarks></remarks>
        public static float Clamp(float value, float min, float max)
        {
            if (value > max)
                return max;
            else if (value < min)
                return min;

            return value;
        }
    }
}
