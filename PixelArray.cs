using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sorting_Pixels
{
    class PixelArray
    {
        // BMP file has a header, containing inforamtion
        // about picture that takes up 54 bytes
        public const int Header = 54;
        public int PixelCount { get; set; }

        private byte[] allBytes;

        public PixelArray(string fileName)
        {
            using (FileStream file = new FileStream(fileName,FileMode.Open, FileAccess.Read))
            {
                allBytes = new byte[file.Length];
                file.Read(allBytes, 0, (int)file.Length);

                // 0x0012, 0x0016 is the location of bytes containing info about width and height of picture
                int width = BitConverter.ToInt32(allBytes,
                    0x0012); //paveikslėlio plotis
                int length = BitConverter.ToInt32(allBytes,
                    0x0016); //paveikslėlio aukštis

                this.PixelCount = length * width;
                file.Close();
            }
        }

        public byte Get(int i)
        {
            return allBytes[i];
        }

        public byte GetPixel_Red(int i)
        {
            // pixels start form header(Header +)
            // each pixel has 3 bytes so i'th pixel is i*3'th byte
            // Adding two because Red color byte(0-255) is the third byte Pixel(Blue byte, Green byte, Red Byte)
            return Get(Header + i * 3 + 2);
        }

        public void SwapAllBytes(int indexOne, int indexTwo)
        {
            // To swap a pixel you need to swap all 3 bytes of color
            this.SwapOneByte(Header + indexOne * 3,
                Header + indexTwo * 3);
            this.SwapOneByte(Header + indexOne * 3 + 1,
                Header + indexTwo * 3 + 1);
            this.SwapOneByte(Header + indexOne * 3 + 2,
                Header + indexTwo * 3 + 2);
        }

        public void SwapOneByte(int indexOne, int indexTwo)
        {
            byte temp = allBytes[indexTwo];
            allBytes[indexTwo] = allBytes[indexOne];
            allBytes[indexOne] = temp;
        }

        public void OutputPicture(string outputPath)
        {
            using (FileStream file2 =
                new FileStream(outputPath,
                FileMode.Create, FileAccess.Write))
            {
                file2.Seek(0, SeekOrigin.Begin);
                file2.Write(allBytes);
                file2.Close();
            }
        }
    }
}
