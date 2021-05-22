using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Sorting_Pixels
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of picture that you want to be sorted (with extension): ");
            string imagePath = Console.ReadLine();
            Directory.SetCurrentDirectory(@"..\..\..\Pictures");
            // check if the specifed file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("The specifed file \"{0}\" could not be found!", imagePath);
                return;
            }
            // converting from jpg to bmp file
            var name = Path.GetFileNameWithoutExtension(imagePath);
            Bitmap image = new Bitmap(imagePath);
            image.Save(name + ".bmp", ImageFormat.Bmp);
            // actual sorting
            PixelArray array = new PixelArray(name + ".bmp");
            HeapSortArray.Sort(array);
            // outputing picture
            array.OutputPicture(name + "_Sorted.bmp");
            Console.WriteLine("File sorted");
            File.Delete(name + ".bmp");
            Console.ReadKey();
        }
    }
}
