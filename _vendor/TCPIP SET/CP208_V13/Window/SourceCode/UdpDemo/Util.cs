using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    public static class Util
    {
        public static string HexArray2String(this byte[] bytes, bool isSpace = true)
        {
            return bytes.HexArray2String(0, bytes.Length, isSpace);
        }

        public static string HexArray2String(this byte[] bytes, int index, int len, bool isSpace = true)
        {
            // 检查边界条件
            if (bytes == null || bytes.Length == 0 || index < 0 || len < 0 || index + len > bytes.Length)
                throw new ArgumentOutOfRangeException("Invalid index or length.无效的索引或长度");

            if (len == 0)
                return string.Empty;
            if (len == 1)
                return bytes[index].ToString("X2");

            // 初始化 StringBuilder
            int capacity = len * 2 + (isSpace ? (len - 1) : 0);
            StringBuilder sb = new StringBuilder(capacity);

            // 构建十六进制字符串
            for (int i = index; i < index + len; ++i)
            {
                sb.Append(bytes[i].ToString("X2"));
                if (isSpace && i < index + len - 1)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public static T ByteArray2Struct<T>(this byte[] buffer)
        {
            object structure = null;
            int size = Marshal.SizeOf(typeof(T));
            IntPtr allocIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(buffer, 0, allocIntPtr, size);
                structure = Marshal.PtrToStructure(allocIntPtr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(allocIntPtr);
            }
            return (T)structure;
        }

        public static byte[] String2HexArray(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return new byte[0];

            return str.String2HexArray(new List<byte>(1024));
        }

        public static byte[] String2HexArray(this string str, List<byte> bytes)
        {
            if (string.IsNullOrEmpty(str))
                return new byte[0];

            byte btCur = 0;
            int nibbleCount = 0; // 用来记录当前字节已处理的4位数的数量

            foreach (char ch in str)
            {
                if (char.IsWhiteSpace(ch))
                    continue;

                if (!((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'F') || (ch >= 'a' && ch <= 'f')))
                    throw new FormatException($"Incorrect hex string '{str}'. 错误的十六进制字符串'{str}'");

                byte btTmp = Char2Hex(ch);
                if (nibbleCount == 0)
                {
                    btCur = (byte)(btTmp << 4); // 将第一个4位数左移4位
                    nibbleCount++;
                }
                else
                {
                    btCur |= btTmp; // 将第二个4位数与第一个4位数组合
                    bytes.Add(btCur);
                    nibbleCount = 0; // 重置计数器
                }
            }

            // 如果最后一个字节只包含一个4位数，也要添加到列表中
            if (nibbleCount == 1)
                bytes.Add(btCur);

            return bytes.ToArray();
        }

        public static byte Char2Hex(this char ch)
        {
            if (ch >= '0' && ch <= '9')
                return (byte)(ch - '0');
            if (ch >= 'A' && ch <= 'F')
                return (byte)(ch - 'A' + 10);
            if (ch >= 'a' && ch <= 'f')
                return (byte)(ch - 'a' + 10);
            throw new ArgumentException($"Invalid hex char:{ch}. 无效的十六进制字符: {ch}");
        }

        public static byte[] Struct2ByteArray<T>(this T obj)
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(obj, bufferIntPtr, false);
                Marshal.Copy(bufferIntPtr, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(bufferIntPtr);
            }
            return buffer;
        }

        public static byte[] FillZero(this byte[] bytes, int length)
        {
            byte[] result = new byte[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = i < bytes.Length ? bytes[i] : (byte)0;
            }

            return result;
        }
    }
}
