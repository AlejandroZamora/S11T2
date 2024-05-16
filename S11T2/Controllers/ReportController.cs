using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using S11T2.Models;

namespace S11T2.Controllers
{
    public class ReportController : Controller
    {
        private readonly StoreContext _context;
        public ReportController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult GeneratePdf()
        {
            var employees = _context.Employees.ToList();
            byte[] pdf = GeneratePdfReport(employees);
            return File(pdf, "application/pdf", "EmployeesReport.pdf");
        }
        private byte[] GeneratePdfReport(List<Employee> empleado)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                document.Add(new Paragraph("Employees Report"));
                var table = new Table(4, true);
                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("Position");
                table.AddCell("Salary");
                foreach (var empleados in empleado)
                {
                    table.AddCell(empleados.EmployeeID.ToString());
                    table.AddCell(empleados.FirstName);
                    table.AddCell(empleados.LastName);
                    table.AddCell(empleados.Address);
                }
                document.Add(table);
                document.Close();
                return stream.ToArray();
            }
        }
    }
}
