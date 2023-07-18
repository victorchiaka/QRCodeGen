using QRCoder;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRCodeGen.Controllers;

public class QRCodeController : Controller
{
    private readonly ILogger<QRCodeController> _logger;

    public QRCodeController(ILogger<QRCodeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
    private static Byte[] BitmapToByteArray(Bitmap bitmap)
    {
        using (var stream = new MemoryStream())
        {
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }

    public IActionResult Generate(string payload)
    {
        QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);

        using (MemoryStream stream = new())
        {
            using (Bitmap bitmap = qrCode.GetGraphic(20))
            {
                bitmap.Save(stream, ImageFormat.Png);
                ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
            }
        }

        // return View();
        return View("Index");
    }
}
