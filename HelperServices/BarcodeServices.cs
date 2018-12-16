using IHelperServices;
using Microsoft.Extensions.Options;
using Models.DTOs;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ZXing;

namespace HelperServices
{
    public class BarcodeServices : _HelperService, IBarcodeServices
    {
        private readonly AppSettings _AppSettings;
        private readonly string _RootPath;

        public BarcodeServices(IOptions<AppSettings> appSettings)
        {
            _AppSettings = appSettings.Value;
            _RootPath = _AppSettings.FileSettings.RelativeDirectory;
        }

        private byte[] GetBarcode(string input, int? width = 100, int? height = 100, BarcodeFormat format = BarcodeFormat.CODE_128)
        {
            BarcodeWriterPixelData writer = new BarcodeWriterPixelData
            {
                Format = format,
                Options = new ZXing.Common.EncodingOptions
                {
                    PureBarcode = true,
                    Margin = 0,
                    Width = width.Value,
                    Height = height.Value
                }
            };
            //return Encoding.UTF8.GetBytes(barcodeWriter.Encode(input).ToString());
            ZXing.Rendering.PixelData pixelData = writer.Write(input);
            using (Bitmap bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                    try
                    {
                        // we assume that the row stride of the bitmap is aligned to 4 byte multiplied by the width of the image
                        Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }

                    // PNG or JPEG or whatever you want
                    bitmap.SetResolution(70F, 70F);
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        public byte[] GetBarcode(string input, int? width = 100, int? height = 100, string format = "CODE_128")
        {
            BarcodeFormat barcodeFormat = (BarcodeFormat)Enum.Parse(typeof(BarcodeFormat), format);
            return GetBarcode(input, width, height, barcodeFormat);
        }
    }
}