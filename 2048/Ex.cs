using System;
using System.Collections.Generic;

namespace _2048 {
    static class Ex {

        private static Random rng = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        public static List<T> Shuffle<T>(this List<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

    }
}
