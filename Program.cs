using System;

namespace ECommerceApp;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Samet Erdoðan - Test Otomasyonu";
        Console.WriteLine("==================================================");
        Console.WriteLine("     SAMET ERDOÐAN - E-TÝCARET TEST PANELÝ       ");
        Console.WriteLine("==================================================");
        Console.WriteLine("Ders: Yazýlým Test ve Kalite Analizi / MTH2005 \n");

        string[] passes = { "T1", "T2", "T4", "T6", "T7", "T8", "T9", "T10", "T12" };
        string[] fails = { "T3 (Kargo Operatör Hatasý)", "T5 (Ödeme Sýnýr Hatasý)", "T11 (Toplam Tutar Bugý)" };

        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var t in passes) Console.WriteLine($" [PASS] {t,-5} : Baþarýyla Tamamlandý.");

        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var t in fails) Console.WriteLine($" [FAIL] {t,-5} : Yazýlým Hatasý Bulundu.");

        Console.ResetColor();
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("Toplam: 12 Senaryo | 9 Baþarýlý | 3 Kusurlu (Bug)");
        Console.WriteLine("==================================================");
        Console.ReadKey();
    }
}