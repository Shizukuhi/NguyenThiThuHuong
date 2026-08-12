using System;
using System.Reflection;
using System.Text;

namespace NetInfoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyName = assembly.GetName().Name ?? "NetInfoApp";

            Console.WriteLine("==================================================");
            Console.WriteLine($"   THÔNG TIN MÔI TRƯỜNG THỰC THI ({assemblyName.ToUpper()})");
            Console.WriteLine("==================================================\n");

            Console.WriteLine($"1. Phiên bản CLR/.NET Core: {Environment.Version}");

            Console.WriteLine($"2. Tên máy tính (Machine Name): {Environment.MachineName}");
            Console.WriteLine($"   Tên người dùng (User Name):   {Environment.UserName}");

            Console.WriteLine($"3. Hệ điều hành (OS Version):  {Environment.OSVersion}");
            Console.WriteLine($"   Kiến trúc CPU Process:       {(Environment.Is64BitProcess ? "64-bit" : "32-bit")}");
            Console.WriteLine($"   Kiến trúc CPU OS:            {(Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit")}");

            long totalMemoryBytes = GC.GetTotalMemory(false);
            double totalMemoryMB = totalMemoryBytes / (1024.0 * 1024.0);

            Console.WriteLine($"4. Bộ nhớ RAM do GC quản lý:  {totalMemoryBytes:N0} bytes ({totalMemoryMB:F2} MB)");

            Console.WriteLine("\n==================================================");
            Console.WriteLine("Nhấn một phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
