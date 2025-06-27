using System;

public abstract class ReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("Generating report header...");
        Export();
    }
    protected abstract void Export();
}

public class PdfReportGenerator : ReportGenerator
{
    protected override void Export() => Console.WriteLine("Exporting to PDF...");
}
public class ExcelReportGenerator : ReportGenerator
{
    protected override void Export() => Console.WriteLine("Exporting to Excel...");
}

public class TemplateMethodDemo
{
    public static void Main()
    {
        var pdfReport = new PdfReportGenerator();
        pdfReport.GenerateReport();
        var excelReport = new ExcelReportGenerator();
        excelReport.GenerateReport();
    }
}
