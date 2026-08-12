using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NetInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "NET Info App - Thông tin môi trường thực thi";

            PrintHeader("THÔNG TIN MÔI TRƯỜNG THỰC THI .NET");
            PrintSeparator();

            // ── 1. Phiên bản CLR / .NET Core ──
            PrintSection("1. PHIÊN BẢN CLR / .NET");
            Console.WriteLine($"  • Phiên bản CLR (Environment.Version):  {Environment.Version}");
            Console.WriteLine($"  • Phiên bản Assembly đang chạy:        {typeof(object).Assembly.GetName().Version}");
            Console.WriteLine($"  • Framework mô tả:                     {RuntimeInformation.FrameworkDescription}");

            PrintSeparator();

            // ── 2. Tên máy tính và tên người dùng ──
            PrintSection("2. THÔNG TIN MÁY TÍNH & NGƯỜI DÙNG");
            Console.WriteLine($"  • Tên máy tính (MachineName):          {Environment.MachineName}");
            Console.WriteLine($"  • Tên người dùng (UserName):           {Environment.UserName}");
            Console.WriteLine($"  • Tên miền người dùng (UserDomainName):{Environment.UserDomainName}");

            PrintSeparator();

            // ── 3. Hệ điều hành và kiến trúc CPU ──
            PrintSection("3. HỆ ĐIỀU HÀNH & KIẾN TRÚC CPU");
            Console.WriteLine($"  • Hệ điều hành (OSVersion):            {Environment.OSVersion}");
            Console.WriteLine($"  • Phiên bản OS chi tiết:               {RuntimeInformation.OSDescription}");
            Console.WriteLine($"  • Kiến trúc OS (OSArchitecture):        {RuntimeInformation.OSArchitecture}");
            Console.WriteLine($"  • Kiến trúc tiến trình (ProcessArch):   {RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"  • 64-bit OS?                           {Environment.Is64BitOperatingSystem}");
            Console.WriteLine($"  • 64-bit Process?                      {Environment.Is64BitProcess}");
            Console.WriteLine($"  • Số lượng bộ xử lý (ProcessorCount):  {Environment.ProcessorCount}");

            PrintSeparator();

            // ── 4. Dung lượng RAM do GC quản lý ──
            PrintSection("4. BỘ NHỚ RAM (GARBAGE COLLECTOR)");
            // Ép GC thu thập rác để có số liệu chính xác nhất
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long totalMemory = GC.GetTotalMemory(false);
            Console.WriteLine($"  • Tổng bộ nhớ GC đang quản lý (bytes): {totalMemory:N0}");
            Console.WriteLine($"  • Tổng bộ nhớ GC đang quản lý (MB):    {totalMemory / (1024.0 * 1024.0):F2} MB");
            Console.WriteLine($"  • Số thế hệ GC:                         {GC.MaxGeneration + 1}");

            // Thông tin bộ nhớ hệ thống
            var gcInfo = GC.GetGCMemoryInfo();
            Console.WriteLine($"  • Tổng bộ nhớ khả dụng (GC):            {gcInfo.TotalAvailableMemoryBytes:N0} bytes ({gcInfo.TotalAvailableMemoryBytes / (1024.0 * 1024.0):F2} MB)");
            Console.WriteLine($"  • Bộ nhớ heap đã commit:                {gcInfo.HeapSizeBytes:N0} bytes ({gcInfo.HeapSizeBytes / (1024.0 * 1024.0):F2} MB)");
            Console.WriteLine($"  • Bộ nhớ đã commit:                     {gcInfo.TotalCommittedBytes:N0} bytes ({gcInfo.TotalCommittedBytes / (1024.0 * 1024.0):F2} MB)");

            PrintSeparator();

            // ── 5. Thông tin bổ sung ──
            PrintSection("5. THÔNG TIN BỔ SUNG");
            Console.WriteLine($"  • Thư mục hiện hành:                    {Environment.CurrentDirectory}");
            Console.WriteLine($"  • Thư mục hệ thống:                     {Environment.SystemDirectory}");
            Console.WriteLine($"  • Đường dẫn thực thi:                   {Environment.ProcessPath}");
            Console.WriteLine($"  • Phiên bản Assembly entry:             {Assembly.GetEntryAssembly()?.GetName().Version}");
            Console.WriteLine($"  • Ticks từ lúc khởi động (ms):          {Environment.TickCount64}");
            Console.WriteLine($"  • Dung lượng Working Set (bytes):       {Environment.WorkingSet:N0}");

            PrintSeparator();
            Console.WriteLine("  Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  ╔══════════════════════════════════════════════════════╗");
            Console.WriteLine($"  ║  {title,-50}  ║");
            Console.WriteLine($"  ╚══════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        static void PrintSection(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ┌─ {title}");
            Console.ResetColor();
        }

        static void PrintSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ─────────────────────────────────────────────────────");
            Console.ResetColor();
        }
    }
}
