using OfficeOpenXml;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Agriculture.Presentation.Models;
using Agriculture.DataAccessLayer.Concrete;

namespace Agriculture.Presentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // StaticReport metodu, statik bir Excel raporu oluşturur ve kullanıcıya indirmesi için sunar.
        // Bu metot, önceden belirlenmiş statik verilerle bir Excel dosyası oluşturur. Hücrelere manuel olarak girilen ürün bilgileriyle dolu olan dosya, kullanıcının indirmesi için hazır hale getirilir.
        public IActionResult StaticReport()
        {
            // ExcelPackage, bir Excel dosyası oluşturmak için kullanılan bir nesnedir. Bu class, EPPlus kütüphanesinden gelir ve Excel dosyalarıyla çalışmak için kullanılır.
            ExcelPackage excelPackage = new ExcelPackage();

            // excelPackage nesnesine Dosya1 adında yeni bir çalışma sayfası eklenir.
            // İlk satırdaki hücrelere sütun başlıkları atanır. Bu başlıklar Excel dosyasının ilk satırında yer alır ve her sütunun içeriğini gösterir.
            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            // Hücrelerin konumları ([satır, sütun]) belirtilerek her hücreye ilgili değer atanır.
            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";

            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "785 Kg";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "1.986 Kg";

            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "167 Kg";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");
        }

        // Database'den Contact tablosundan veri almak için oluşturulmuş bir metottur.
        // Burada oluşturulan List ile Contact nesnesi, ContactModel nesnesine dönüştürülür.
        // ContactList metodu ile database'den Contacts tablosundaki verileri ContactModel formatında çekerek kullanıma hazır bir liste döndürülmesini sağlanır.
        // Böylece database modeli yerine, ihtiyaca uygun şekilde tasarlanmış olan ContactModel ile çalışmak daha kolay olur ve dış katmanlarda veri gösterimi yapılırken daha az bağımlılık sağlanır.
        public List<ContactModel> ContactList()
        {
            // contactModels nesnesi metot sonunda dolmuş olarak döndürülmek üzere boş olarak tanımlanır
            List<ContactModel> contactModels = new List<ContactModel>();

            // DbContext kullanılarak using bloğu içinde bir bağlantı oluşturulur.
            // Bu, EF kullanarak database'e erişim sağlamak için kullanılır ve işlem sonunda context nesnesini otomatik olarak bellekten temizler.
            using (var context = new AgricultureContext())
            {
                // Select sorgusu ile data çekilir.
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactId = x.ContactId,
                    ContactName = x.Name,
                    ContactMail = x.Mail,
                    ContactDate = x.Date,
                    ContactMessage = x.Message
                }).ToList();
            }

            // Metodun sonunda, contactModels listesindeki veriler döndürülür.
            return contactModels;
        }

        // MessageReport metodu, ContactList() metodundan elde edilen verilerle bir Excel dosyası oluşturur ve kullanıcının indirmesi için hazırlar.
        public IActionResult MessageReport()
        {
            // XLWorkBook class'ı, ClosedXML kütüphanesinden gelir ve Excel dosyası oluşturulmasına olanak sağlar.
            // using ifadesi, workBook nesnesini metot tamamlandığında bellekten otomatik olarak temizler.
            using (var workBook = new XLWorkbook())
            {
                // workBook nesnesine "Mesaj Listesi" adında yeni bir sayfa eklenir.
                // İk satırda başlık hücreleri tanımlanır. Bu başlıklar, Excel dosyasının ilk satırında yer alır ve sütunların ne içerdiğini gösterir.
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");

                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                // contactRowCount değişkeni, verilerin ikinci satırdan başlayarak yazılmasını sağlar ve her döngüde bir artırılır.
                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactId;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;
                }

                // MemoryStream kullanılarak dosya bellek üzerinde geçici olarak tutulur.
                using (var stream = new MemoryStream())
                {
                    // SaveAs(stream) ile workBook, bu hafıza akışına kaydedilir.
                    workBook.SaveAs(stream);

                    // content adlı bir byte dizi olarak dosya içeriği alınır ve File metodu ile kullanılarak indirme işlemi gerçekleştirilir. Bu işlemde, dosya tipi ve adı belirtillir.
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRaporu.xlsx");
                }
            }
        }

        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();

            using (var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncementId = x.AnnouncementId,
                    AnnouncementName = x.AnnouncementName,
                    Description = x.Description,
                    Date = x.Date,
                    Status = x.Status
                }).ToList();
            }

            return announcementModels;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");

                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Adı";
                workSheet.Cell(1, 3).Value = "Açıklama";
                workSheet.Cell(1, 4).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 5).Value = "Duyuru Durumu";

                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(announcementRowCount, 1).Value = item.AnnouncementId;
                    workSheet.Cell(announcementRowCount, 2).Value = item.AnnouncementName;
                    workSheet.Cell(announcementRowCount, 3).Value = item.Description;
                    workSheet.Cell(announcementRowCount, 4).Value = item.Date;
                    workSheet.Cell(announcementRowCount, 5).Value = item.Status == true ? "Aktif" : "Pasif";
                    announcementRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    // Random isim gelmesi için
                    string GuidKey = Guid.NewGuid().ToString() + ".xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", GuidKey);
                }
            }
        }
    }
}
