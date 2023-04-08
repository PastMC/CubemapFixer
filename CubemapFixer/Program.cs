using System;
using System.Drawing;
using System.IO;

namespace CubemapFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            // args[0] = pathToBreaked Cubemap args[1] = path to save fixed cubemap
            Console.WriteLine(args.Length);
            if (args != null && args.Length == 2)
            {
                string sourceFilePath = args[0];
                string destinationFilePath = args[1];

                // Load the source image
                Bitmap sourceImage = new Bitmap(sourceFilePath);
                Console.WriteLine(sourceImage.Width + " " + sourceImage.Height);

                // Create a new bitmap for the destination image
                Bitmap destinationImage = new Bitmap(sourceImage.Width * 4, sourceImage.Width * 3);
                // Rectangle for cut and paste the images
                Rectangle bottomSection1 = new Rectangle(0, 0, sourceImage.Width, sourceImage.Width);
                Rectangle bottomSection2 = new Rectangle(0, sourceImage.Width, sourceImage.Width, sourceImage.Width);
                Rectangle bottomSection = new Rectangle(0, sourceImage.Width * 2, sourceImage.Width, sourceImage.Width);
                Rectangle bottomSection4 = new Rectangle(0, sourceImage.Width * 3, sourceImage.Width, sourceImage.Width);
                Rectangle bottomSection5 = new Rectangle(0, sourceImage.Width * 4, sourceImage.Width, sourceImage.Width);
                Rectangle bottomSection6 = new Rectangle(0, sourceImage.Width * 5, sourceImage.Width, sourceImage.Width);
                
                //Create Bitmaps
                Bitmap bottomImage1 = sourceImage.Clone(bottomSection1, sourceImage.PixelFormat);
                Bitmap bottomImage2 = sourceImage.Clone(bottomSection2, sourceImage.PixelFormat);
                Bitmap bottomImage = sourceImage.Clone(bottomSection, sourceImage.PixelFormat);
                Bitmap bottomImage4 = sourceImage.Clone(bottomSection4, sourceImage.PixelFormat);
                Bitmap bottomImage5 = sourceImage.Clone(bottomSection5, sourceImage.PixelFormat);
                Bitmap bottomImage6 = sourceImage.Clone(bottomSection6, sourceImage.PixelFormat);
                
                // Flip Images
                bottomImage1.RotateFlip(RotateFlipType.Rotate180FlipX);
                bottomImage2.RotateFlip(RotateFlipType.Rotate180FlipX);
                bottomImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                bottomImage4.RotateFlip(RotateFlipType.Rotate180FlipY);
                bottomImage5.RotateFlip(RotateFlipType.Rotate180FlipX);
                bottomImage6.RotateFlip(RotateFlipType.Rotate180FlipX);
                
                //Create Graphics
                Graphics graphics = Graphics.FromImage(destinationImage);

                // Draw the foreground image on the composite image at (x, y)
                graphics.DrawImage(bottomImage1, 0, sourceImage.Width);
                graphics.DrawImage(bottomImage2, sourceImage.Width * 2, sourceImage.Width);
                graphics.DrawImage(bottomImage, sourceImage.Width, 0);
                graphics.DrawImage(bottomImage4, sourceImage.Width, sourceImage.Width * 2);
                graphics.DrawImage(bottomImage5, sourceImage.Width * 3, sourceImage.Width);
                graphics.DrawImage(bottomImage6, sourceImage.Width, sourceImage.Width);
                
                //Save Image
                destinationImage.Save(destinationFilePath, System.Drawing.Imaging.ImageFormat.Png);

                // Clean up
                graphics.Dispose();
                sourceImage.Dispose();
                bottomImage1.Dispose();
                bottomImage2.Dispose();
                bottomImage.Dispose();
                bottomImage4.Dispose();
                bottomImage5.Dispose();
                bottomImage6.Dispose();
                destinationImage.Dispose();
            } else
            {
                Console.WriteLine("ERROR to start program need 2 paths");
            }
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}



