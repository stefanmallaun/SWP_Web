using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using iTextSharp.text.pdf;
using Web_Grundlagen.Extensions;
using Web_Grundlagen.Models;



namespace Web_Grundlagen.Controllers{
    public class PDFController : Controller {

        [HttpPost]
        public IActionResult PDF()
        {
            using (MemoryStream ms = new MemoryStream())
            {

                HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.Session.Get<User>("User");
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                
                var image = iTextSharp.text.Image.GetInstance("wwwroot/image/clariente jung.jpg");
                image.Alignment = Element.ALIGN_CENTER;
                document.Add(image);
                Paragraph para1 = new Paragraph("Username: " + user.Name, new Font(Font.FontFamily.HELVETICA, 20));
                //para1.Alignment = Element.ALIGN_CENTER;
                document.Add(para1);
                Paragraph para2 = new Paragraph("Email: " + user.Email, new Font(Font.FontFamily.HELVETICA, 20));
                //para2.Alignment = Element.ALIGN_CENTER;
                document.Add(para2);
                Paragraph para3 = new Paragraph("Geburtstag: " + user.Birthdate, new Font(Font.FontFamily.HELVETICA, 20));
                //para3.Alignment = Element.ALIGN_CENTER;
                document.Add(para3);
                Paragraph para4 = new Paragraph("Hashed Passwort: " + user.Pwd, new Font(Font.FontFamily.HELVETICA, 20));
                //para4.Alignment = Element.ALIGN_CENTER;
                document.Add(para4);

                document.Close();
                writer.Close();
                var constant = ms.ToArray();
                return File(constant, "application/vnd", "Fristpdf.pdf");


            }
        }
    }

}