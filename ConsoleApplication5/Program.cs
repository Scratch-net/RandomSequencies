using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {

        private static uint F1(uint x)
        {
            return RotateRight(x, 22) ^ RotateRight(x, 13) ^ (x >> 3);
        }

        private static uint F2(uint x)
        {
            return RotateRight(x, 18) ^ RotateRight(x, 4) ^ (x >> 9);
        }

        private static ulong Sigma0(ulong x)
        {
            return ((x << 63) | (x >> 1)) ^ ((x << 56) | (x >> 8)) ^ (x >> 7);
        }

        private static ulong Sigma1(ulong x)
        {
            return ((x << 45) | (x >> 19)) ^ ((x << 3) | (x >> 61)) ^ (x >> 6);
        }


        private static ulong Sum0(ulong x)
        {
            return ((x << 36) | (x >> 28)) ^ ((x << 30) | (x >> 34)) ^ ((x << 25) | (x >> 39));
        }

        private static ulong Sum1(ulong x)
        {
            return ((x << 50) | (x >> 14)) ^ ((x << 46) | (x >> 18)) ^ ((x << 23) | (x >> 41));
        }


        private static uint Sum0(
             uint x)
        {
            return ((x >> 2) | (x << 30)) ^ ((x >> 13) | (x << 19)) ^ ((x >> 22) | (x << 10));
        }

        private static uint Sum1(
            uint x)
        {
            return ((x >> 6) | (x << 26)) ^ ((x >> 11) | (x << 21)) ^ ((x >> 25) | (x << 7));
        }

        private static uint Theta0(
            uint x)
        {
            return ((x >> 7) | (x << 25)) ^ ((x >> 18) | (x << 14)) ^ (x >> 3);
        }

        private static uint Theta1(
            uint x)
        {
            return ((x >> 17) | (x << 15)) ^ ((x >> 19) | (x << 13)) ^ (x >> 10);
        }


        private static uint RotateLeft(uint x, int bits)
        {
            return (x << bits) | (x >> -bits);
        }

        private static uint RotateRight(uint x, int bits)
        {
            return (x >> bits) | (x << -bits);
        }

        static readonly ulong[] map = new ulong[67108864];

        static void SetBit(uint index)
        {
            //var byteIndex = index / 64;
            //var bitInByteIndex = (int)index % 64;
            //var mask = (ulong)1 << ((int)index % 64);
            map[index / 64] |= (ulong)1 << ((int)index % 64);
        }

        static bool GetBit(uint index)
        {
            //var byteIndex = index / 64;
            //var bitInByteIndex = (int)index % 64;
            //var bit = (map[byteIndex] >> bitInByteIndex) & 1;
            return ((map[index / 64] >> (int)index % 64) & 1) == 1;
        }

        public static uint Next(uint current)
        {
            return (uint) (((ulong)current << 1) % 4294967291);
        }

        static void Main(string[] args)
        {
            uint current = 1;
            SetBit(current);
            for (uint i = 0; i < uint.MaxValue; i++)
            {
               // Console.WriteLine(Convert.ToBase64String(BitConverter.GetBytes(Sum1(Theta0(Sum0(Theta1(i)))))).Replace("=",""));

                current = Next(current);
                if (GetBit(current))
                {
                    Console.WriteLine("Fuck");
                }
                SetBit(current);

            }
            /*
            ulong part = 536870912; //2^32 / 8
            for (ulong i = 0; i < 8; i++)
            {
                var i1 = part * i;
                new Thread(() =>
                {
                    CalcPart(i1, i1 + part);
                }).Start();
            }*/
        }

        static void CalcPart(ulong start, ulong end)
        {
            for (ulong i = start; i < end; i++)
            {
                var res = Sum1(Theta0(Sum0(Theta1((uint)i))));

                if (!GetBit(res))
                {
                    SetBit(res);
                }
                else
                {
                    Console.WriteLine("Damn");
                }
            }
        }
    }
}
