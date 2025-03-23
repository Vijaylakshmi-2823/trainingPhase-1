using System;
using System.IO;

// SRP: Separate responsibilities for report generation and saving
public class ReportGenerator
{
    public string GenerateReport()
    {
        return "Report Content";
    }
}

public class ReportSaver : IReportSaver
{
    public void Save(string content, string filePath)
    {
        File.WriteAllText(filePath, content);
    }
}

// OCP: Open for extension but closed for modification using Strategy Pattern
public interface IReportFormatter
{
    string Format(string content);
}

public class PdfReportFormatter : IReportFormatter
{
    public string Format(string content)
    {
        return "PDF Formatted: " + content;
    }
}

public class ExcelReportFormatter : IReportFormatter
{
    public string Format(string content)
    {
        return "Excel Formatted: " + content;
    }
}

// LSP: Derived classes should be substitutable for base class
public abstract class Report
{
    public abstract string GetContent();
}

// ISP: Split large interfaces into smaller, more specific ones
public interface IReportContentProvider
{
    string GetContent();
}

public interface IReportSaver
{
    void Save(string content, string filePath);
}

// DIP: Depend on abstractions, not concrete implementations
public class ReportService
{
    private readonly IReportContentProvider _report;
    private readonly IReportFormatter _formatter;
    private readonly IReportSaver _saver;

    public ReportService(IReportContentProvider report, IReportFormatter formatter, IReportSaver saver)
    {
        _report = report;
        _formatter = formatter;
        _saver = saver;
    }

    public void GenerateAndSaveReport(string filePath)
    {
        string content = _report.GetContent();
        string formattedContent = _formatter.Format(content);
        _saver.Save(formattedContent, filePath);
    }
}

// Implementation of specific reports
public class FinancialReport : Report, IReportContentProvider
{
    public override string GetContent()
    {
        return "Financial Report Data";
    }
}

public class SalesReport : Report, IReportContentProvider
{
    public override string GetContent()
    {
        return "Sales Report Data";
    }
}

// Implementation Example
class Program
{
    static void Main()
    {
        IReportContentProvider report = new FinancialReport(); // You can also use SalesReport here

        IReportFormatter formatter = new PdfReportFormatter(); // You can switch to ExcelReportFormatter if needed
        IReportSaver saver = new ReportSaver();

        ReportService reportService = new ReportService(report, formatter, saver);
        reportService.GenerateAndSaveReport("report.pdf");
    }
}