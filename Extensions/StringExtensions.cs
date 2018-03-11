using System;

namespace OdeToFood.Extensions
{
    public static class StringExtensions
    {
        public static String ToPageName(this String value)
        {
            return $"{value}".Replace("Model", "");
        }
    }
}