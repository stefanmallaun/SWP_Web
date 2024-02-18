using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace Web_Grundlagen.Controllers{
    public class PDFController : ControllerBase {
        [HttpGet]
        public IActionResult GeneratePdf(string content) {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedPDFs", "GeneratedPDF.pdf");

            CreatePdf(filePath, content);

            return Ok(new { Message = "PDF erfolgreich erstellt unter: " + filePath });
        }

        public void CreatePdf(string filePath, string content) {
            PdfDocument pdf = new PdfDocument();

            PdfPage page = pdf.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("sans-serif", 20);

            XRect rect = new XRect(100, 100, page.Width, page.Height);
            gfx.DrawString(content, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            pdf.Save(filePath);
        }
    }

}