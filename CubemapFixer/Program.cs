using System;
using System.Drawing;
using System.IO;

namespace CubemapFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            // Specify the source and destination file paths
            if (args != null && args.Length == 2)
            {
                string sourceFilePath = args[0];
                string destinationFilePath = args[1];

                // Load the source image
                Bitmap sourceImage = new Bitmap(sourceFilePath);
                Console.WriteLine(sourceImage.Width + " " + sourceImage.Height);

                // Create a new bitmap for the destination image
                Bitmap destinationImage = new Bitmap(sourceImage.Width * 4, sourceImage.Width * 3);
                Rectangle bottomSection1 = new Rectangle(0, 0, sourceImage.Width, sourceImage.Width);
                Bitmap bottomImage1 = sourceImage.Clone(bottomSection1, sourceImage.PixelFormat);
                // Save the new image to a file
                bottomImage1.RotateFlip(RotateFlipType.Rotate180FlipX);
                Rectangle bottomSection2 = new Rectangle(0, sourceImage.Width, sourceImage.Width, sourceImage.Width);
                Bitmap bottomImage2 = sourceImage.Clone(bottomSection2, sourceImage.PixelFormat);
                // Save the new image to a file
                bottomImage2.RotateFlip(RotateFlipType.Rotate180FlipX);
                Rectangle bottomSection = new Rectangle(0, sourceImage.Width * 2, sourceImage.Width, sourceImage.Width);
                Bitmap bottomImage = sourceImage.Clone(bottomSection, sourceImage.PixelFormat);
                // Save the new image to a file
                bottomImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                Rectangle bottomSection4 = new Rectangle(0, sourceImage.Width * 3, sourceImage.Width, sourceImage.Width);
                Bitmap bottomImage4 = sourceImage.Clone(bottomSection4, sourceImage.PixelFormat);
                // Save the new image to a file
                bottomImage4.RotateFlip(RotateFlipType.Rotate180FlipY);
                Rectangle bottomSection5 = new Rectangle(0, sourceImage.Width * 4, sourceImage.Width, sourceImage.Width);
                Bitmap bottomImage5 = sourceImage.Clone(bottomSection5, sourceImage.PixelFormat);
                // Save the new image to a file
                bottomImage5.RotateFlip(RotateFlipType.Rotate180FlipX);
                Rectangle bottomSection6 = new Rectangle(0, sourceImage.Width * 5, sourceImage.Width, sourceImage.Width);
                Bitmap bottomImage6 = sourceImage.Clone(bottomSection6, sourceImage.PixelFormat);
                // Save the new image to a file
                bottomImage6.RotateFlip(RotateFlipType.Rotate180FlipX);
                Graphics graphics = Graphics.FromImage(destinationImage);

                // Draw the foreground image on the composite image at (x, y)
                graphics.DrawImage(bottomImage1, 0, sourceImage.Width);
                graphics.DrawImage(bottomImage2, sourceImage.Width * 2, sourceImage.Width);
                graphics.DrawImage(bottomImage, sourceImage.Width, 0);
                graphics.DrawImage(bottomImage4, sourceImage.Width, sourceImage.Width * 2);
                graphics.DrawImage(bottomImage5, sourceImage.Width * 3, sourceImage.Width);
                graphics.DrawImage(bottomImage6, sourceImage.Width, sourceImage.Width);
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
                // Create a new bitmap for the destination image
                /*Bitmap destinationImage = new Bitmap(sourceImage.Width * 3, sourceImage.Width * 4);

                // Copy the pixels from the source image to the destination image
                /*for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int y = 0; y < sourceImage.Height; y++)
                    {
                        destinationImage.SetPixel(x, y, sourceImage.GetPixel(x, y));
                    }
                }

                // Save the destination image to a file
                destinationImage.Save(destinationFilePath, System.Drawing.Imaging.ImageFormat.Png);

                // Clean up
                sourceImage.Dispose();
                destinationImage.Dispose();*/
            } else
            {
                Console.WriteLine("ERROR to start program need 2 paths");
            }
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey();
        }
    }
}



