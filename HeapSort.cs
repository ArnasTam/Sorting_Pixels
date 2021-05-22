using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Pixels
{
    class HeapSortArray
    {
        public static void Sort(PixelArray bytes)
        {
            for (int i = bytes.PixelCount / 2 - 1; i >= 0; i--)
                Heapify(bytes, bytes.PixelCount, i);

            for (int i = bytes.PixelCount - 1; i > 0; i--)
            {
                bytes.SwapAllBytes(0, i);
                Heapify(bytes, i, 0);
            }
        }

        private static void Heapify(PixelArray bytes, int size, int root)
        {
            int maxIndex = root;
            int leftIndex = 2 * root + 1;
            int rightIndex = 2 * root + 2;

            if (leftIndex < size && bytes.GetPixel_Red(leftIndex) > bytes.GetPixel_Red(maxIndex))
                maxIndex = leftIndex;

            if (rightIndex < size && bytes.GetPixel_Red(rightIndex) > bytes.GetPixel_Red(maxIndex))
                maxIndex = rightIndex;

            if (maxIndex != root)
            {
                bytes.SwapAllBytes(root, maxIndex);
                Heapify(bytes, size, maxIndex);
            }
        }
    }
}
