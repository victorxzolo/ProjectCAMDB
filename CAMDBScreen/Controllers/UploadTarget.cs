using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.Extensions.Configuration;
using CAMDBScreen.Models;
using NPOI.SS.Util;
using System.Collections;

namespace CAMDBScreen.Controllers
{
    public class UploadTargetController : Controller
    {

        private readonly ILogger<UploadTargetController> _logger;
        private IHostingEnvironment _hostingEnvironment;
        public UploadTargetController(ILogger<UploadTargetController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult datatable()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {

                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    // string tb = @"<table class='table table-bordered' id='dataTable' width='100%' cellspacing='0'><thead><tr>";
                    //sb.Append(tb);
                    //for (int j = 0; j < cellCount; j++)
                    //{
                    //    NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                    //    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    //    sb.Append("<th>" + cell.ToString() + "</th>");
                    //}
                    //sb.Append("</tr></thead>");
                    //sb.AppendLine("<tbody>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        sb.Append("<tr>");
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                        sb.Append("</tr>");
                    }
                    //sb.Append("</tbody>");
                }
            }
            return this.Content(sb.ToString());
        }
        public ActionResult Showdata()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {

                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    // string tb = @"<table class='table table-bordered' id='dataTable' width='100%' cellspacing='0'><thead><tr>";
                    //sb.Append(tb);
                    //for (int j = 0; j < cellCount; j++)
                    //{
                    //    NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                    //    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    //    sb.Append("<th>" + cell.ToString() + "</th>");
                    //}
                    //sb.Append("</tr></thead>");
                    //sb.AppendLine("<tbody>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        sb.Append("<tr>");
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                        sb.Append("</tr>");
                    }
                    //sb.Append("</tbody>");
                }
            }
            return this.Content(sb.ToString());
        }
        public ActionResult Validatedata()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            string res = "";

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                IWorkbook workBook;
                string fullPath = Path.Combine(newPath, file.FileName);
                string log = Path.Combine(newPath, "Log.txt");
                System.IO.File.AppendAllText(log, "End Time start uploadfile = " + DateTime.Now.ToString("HH:mm:ss:fff") + Environment.NewLine);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  


                        workBook = hssfwb;
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                        workBook = hssfwb;
                        System.IO.File.AppendAllText(log, "End Time Loadfile excle = " + DateTime.Now.ToString("HH:mm:ss:fff") + Environment.NewLine);
                    }

                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    Hashtable hashCheckDup = new Hashtable();

                    for (int i = (sheet.FirstRowNum); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        sb.Append("<tr>");
                        bool validate = true;
                        var key = row.GetCell(1).ToString() + row.GetCell(2).ToString() + row.GetCell(3).ToString();
                        if (hashCheckDup.Count < 1) hashCheckDup.Add(key, i);
                        if (hashCheckDup.ContainsKey(key))
                        {
                            string td = "<td id='error'>" + row.GetCell(0).ToString() +
                                          "</td><td id='error'>" + row.GetCell(1).ToString() + "</td>" +
                                          "</td><td id='error'>" + row.GetCell(2).ToString() + "</td>" +
                                          "</td><td id='error'>" + row.GetCell(3).ToString() + "</td>";
                            validate = false;
                            sb.Append(td);
                            continue;
                        }
                        else
                        {
                            hashCheckDup.Add(key, i);

                        }
                        if (validate == true)
                        {
                            res = requiredNum(sheet, i);
                            if (res != "") { sb.Append(res); }
                        }

                        sb.Append("</tr>");
                        sb.Replace("<tr></tr>", "");

                    }
                    //end for row

                    System.IO.File.AppendAllText(log, "End Time function validate = " + DateTime.Now.ToString("HH:mm:ss:fff") + Environment.NewLine);
                    res = sb.ToString();
                }
            }
            return this.Content(res);
        }

        public string ForLoop(ISheet sheet, IWorkbook workbook)
        {
            IRow headerRow = sheet.GetRow(0); //Get Header Row
            int cellCount = headerRow.LastCellNum;

            XSSFFormulaEvaluator formula = new XSSFFormulaEvaluator(workbook);
            StringBuilder sb = new StringBuilder();
            for (int i = (sheet.FirstRowNum); i <= sheet.LastRowNum; i++) //Read Excel File
            {

                StringBuilder text = new StringBuilder();
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                sb.Append("<tr>");
                bool validate = true;
                bool validatedup = true;

                System.String colB = "COUNTIF(B:B, B" + (i + 1) + ")>1";
                System.String colC = "COUNTIF(C:C, C" + (i + 1) + ")>1";
                sheet.GetRow(i).CreateCell(50).SetCellFormula(colB);
                sheet.GetRow(i).CreateCell(51).SetCellFormula(colC);
                var cellB = sheet.GetRow(i).GetCell(50);
                var cellC = sheet.GetRow(i).GetCell(51);
                if (cellB != null && cellB.CellType == CellType.Formula) { var b = formula.Evaluate(cellB); if (b.BooleanValue == true) validatedup = false; }
                if (cellC != null && cellC.CellType == CellType.Formula) { var c = formula.Evaluate(cellC); if (c.BooleanValue == true) validatedup = false; }

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        string spec = row.GetCell(j).ToString().Replace(" ", string.Empty);
                        bool isNumeric = long.TryParse(spec.Trim(), out long l);
                        int let = spec.Length;
                        if (let != 0)
                        {
                            if (j == 0 || j == 1 || j == 2) if (isNumeric == false)
                                {
                                    text.Append("<td id='error'>" + "Numeric" + "</td>"); validate = false; continue;
                                }


                            if (j == 0 && let > 7)
                            {
                                text.Append("<td id='error'>" + "Maximum 7 characters" + "</td>"); validate = false; continue;
                            }
                            else if (j == 1 && let > 8)
                            {
                                text.Append("<td id='error'>" + "Maximum 8 characters" + "</td>"); validate = false; continue;
                            }
                            else if (j == 2 && let > 16)
                            {
                                text.Append("<td id='error'>" + "Maximum 16 characters" + "</td>"); validate = false; continue;
                            }
                            else if (j == 3 && let > 15)
                            {
                                text.Append("<td id='error'>" + "Maximum 15 characters" + "</td>"); validate = false; continue;
                            }
                            else
                            {
                                if (validatedup == false)
                                {
                                    text.Append("<td id='error'>" + row.GetCell(j).ToString() + "</td>"); validate = false; continue;
                                }
                                else
                                {
                                    text.Append("<td>" + row.GetCell(j).ToString() + "</td>"); continue;
                                }


                            }
                        }
                        else
                        {
                            validate = false;
                            text.Append("<td id='error'>" + "required" + "</td>");
                            continue;
                        }
                    }
                }
                if (validate == false)
                {
                    sb.Append(text.ToString());
                    //string log = Path.Combine(newPath, "Log.txt");
                    // System.IO.File.AppendAllText(log, i + ":" + text.ToString() + Environment.NewLine);
                }

                sb.Append("</tr>");
                sb.Replace("<tr></tr>", "");

            }
            return sb.ToString();
        }
        public string requiredNum(ISheet sheet, int irow)
        {
            IRow headerRow = sheet.GetRow(0);
            StringBuilder sb = new StringBuilder();
            StringBuilder text = new StringBuilder();
            IRow row = sheet.GetRow(irow);
            bool validate = true;
            int cellCount = headerRow.LastCellNum;
            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) != null)
                {
                    string spec = row.GetCell(j).ToString().Replace(" ", string.Empty);
                    bool isNumeric = long.TryParse(spec.Trim(), out long l);
                    int let = spec.Length;
                    if (let != 0)
                    {
                        if (j == 0 || j == 1 || j == 2) if (isNumeric == false)
                            {
                                text.Append("<td id='error'>" + "Numeric" + "</td>"); validate = false; continue;
                            }

                        if (j == 0 && let > 7)
                        {
                            text.Append("<td id='error'>" + "Maximum 7 characters" + "</td>"); validate = false; continue;
                        }
                        else if (j == 1 && let > 8)
                        {
                            text.Append("<td id='error'>" + "Maximum 8 characters" + "</td>"); validate = false; continue;
                        }
                        else if (j == 2 && let > 16)
                        {
                            text.Append("<td id='error'>" + "Maximum 16 characters" + "</td>"); validate = false; continue;
                        }
                        else if (j == 3 && let > 15)
                        {
                            text.Append("<td id='error'>" + "Maximum 15 characters" + "</td>"); validate = false; continue;
                        }
                        else
                        {
                            text.Append("<td>" + row.GetCell(j).ToString() + "</td>"); continue;
                        }
                    }
                    else
                    {

                        text.Append("<td id='error'>" + "required" + "</td>");
                        validate = false;
                        continue;
                    }
                }
            }

            if (validate == false)
            {
                sb.Append(text.ToString());
            }

            return sb.ToString();
        }
        public async Task<IActionResult> Export()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"Employees.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("employee");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("EmployeeId");
                row.CreateCell(1).SetCellValue("EmployeeName");
                row.CreateCell(2).SetCellValue("Age");
                row.CreateCell(3).SetCellValue("Sex");
                row.CreateCell(4).SetCellValue("Designation");

                row = excelSheet.CreateRow(1);
                row.CreateCell(0).SetCellValue(1);
                row.CreateCell(1).SetCellValue("Jack Supreu");
                row.CreateCell(2).SetCellValue(45);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Solution Architect");

                row = excelSheet.CreateRow(2);
                row.CreateCell(0).SetCellValue(2);
                row.CreateCell(1).SetCellValue("Steve khan");
                row.CreateCell(2).SetCellValue(33);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Software Engineer");

                row = excelSheet.CreateRow(3);
                row.CreateCell(0).SetCellValue(3);
                row.CreateCell(1).SetCellValue("Romi gill");
                row.CreateCell(2).SetCellValue(25);
                row.CreateCell(3).SetCellValue("FeMale");
                row.CreateCell(4).SetCellValue("Junior Consultant");

                row = excelSheet.CreateRow(4);
                row.CreateCell(0).SetCellValue(4);
                row.CreateCell(1).SetCellValue("Hider Ali");
                row.CreateCell(2).SetCellValue(34);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Accountant");

                row = excelSheet.CreateRow(5);
                row.CreateCell(0).SetCellValue(5);
                row.CreateCell(1).SetCellValue("Mathew");
                row.CreateCell(2).SetCellValue(48);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Human Resource");

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }

        public ActionResult Download()
        {
            string Files = "wwwroot/UploadExcel/CoreProgramm_ExcelImport.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Files);
            System.IO.File.WriteAllBytes(Files, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "employee.xlsx");
        }


    }
}