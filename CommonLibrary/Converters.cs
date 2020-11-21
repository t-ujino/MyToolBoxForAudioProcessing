using System;
using System.Linq;
using System.Collections.Generic;

namespace MyToolBoxCommonLibrary
{
    public enum ENDIAN
    {
        LittleEndian,
        BigEndian
    }

    public class Converters
    {
        public static IEnumerable<byte> ToIeee754(float value, ENDIAN toEndian = ENDIAN.LittleEndian)
        {
            var ret = BitConverter.GetBytes(value);
            var isToLittleEndian = (ENDIAN.LittleEndian == toEndian);
            return (isToLittleEndian == BitConverter.IsLittleEndian) ? ret : ret.Reverse();
        }
    }
}
