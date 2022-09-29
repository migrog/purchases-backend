
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using purchase.domain.entities.dtos;

namespace purchase.api.Utils
{
    public sealed class GeneratePDF
    {
        private readonly static GeneratePDF _instance = new GeneratePDF();
        private GeneratePDF() { }
        public static GeneratePDF Instance
        {
            get { return _instance; }
        }
        public FileStream GeneratePurchaseFile(PurchasePrintResponse value)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("purchase.pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("Orden de Compra: #" + value.Purchase.Id);
            doc.Add(title);

            //Maestro
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Cliente: " + value.Purchase.Customer));
            doc.Add(new Paragraph("Fecha de compra: " + value.Purchase.Date));
            doc.Add(new Paragraph("Moneda: " + value.Purchase.Currency));
            doc.Add(new Paragraph(" "));


            //Detalle
            PdfPTable table = new PdfPTable(4);
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            //cabecera
            table.AddCell("Item");
            table.AddCell("Cantidad");
            table.AddCell("Precio");
            table.AddCell("Total");

            //items
            foreach(var item in value.Detail)
            {
                table.AddCell(item.Item);
                table.AddCell(item.Quantity.ToString());
                table.AddCell(item.UnitPrice.ToString());
                table.AddCell((item.Quantity*item.UnitPrice).ToString());
            }
            

            doc.Add(table);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Monto total: " + value.Purchase.Currency + " " + value.Purchase.Total));

            doc.Close();

            return new FileStream("purchase.pdf", FileMode.Open, FileAccess.Read);
        }
    }
}
