using System;
using System.Reflection;
using System.Text;

namespace NetInfoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;

            // Lấy thông tin Assembly hiện tại
            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyName = assembly.GetName().Name ?? "NetInfoApp";

            Console.WriteLine("==================================================");
            Console.WriteLine($"   THÔNG TIN MÔI TRƯỜNG THỰC THI ({assemblyName.ToUpper()})");
            Console.WriteLine("==================================================\n");

            // 1. Phiên bản CLR / .NET
            Console.WriteLine($"1. Phiên bản CLR/.NET Core: {Environment.Version}");

            // 2. Tên máy tính và tên người dùng
            Console.WriteLine($"2. Tên máy tính (Machine Name): {Environment.MachineName}");
            Console.WriteLine($"   Tên người dùng (User Name):   {Environment.UserName}");

            // 3. Hệ điều hành và kiến trúc CPU
            Console.WriteLine($"3. Hệ điều hành (OS Version):  {Environment.OSVersion}");
            Console.WriteLine($"   Kiến trúc CPU Process:       {(Environment.Is64BitProcess ? "64-bit" : "32-bit")}");
            Console.WriteLine($"   Kiến trúc CPU OS:            {(Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit")}");

            // 4. Dung lượng bộ nhớ RAM do Garbage Collector (GC) quản lý
            long totalMemoryBytes = GC.GetTotalMemory(false);
            double totalMemoryMB = totalMemoryBytes / (1024.0 * 1024.0);

            Console.WriteLine($"4. Bộ nhớ RAM do GC quản lý:  {totalMemoryBytes:N0} bytes ({totalMemoryMB:F2} MB)");

            Console.WriteLine("\n==================================================");
            Console.WriteLine("Nhấn một phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
