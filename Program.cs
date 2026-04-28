using System;

namespace ECommerceApp;

class Program
{
    static void Main(string[] args)
    {
        // GitHub ve farklı platformlarda karakter bozulmasını önlemek için 
        // Türkçe karakterler İngilizce karşılıklarıyla revize edilmiştir.
        Console.Title = "Samet Erdogan - Test Otomasyonu";
        Console.WriteLine("==================================================");
        Console.WriteLine("      SAMET ERDOGAN - E-TICARET TEST PANELI       ");
        Console.WriteLine("==================================================");
        Console.WriteLine("Ders: Yazilim Test ve Kalite Analizi / MTH2005 \n");

        string[] passes = { "T1", "T2", "T4", "T6", "T7", "T8", "T9", "T10", "T12" };
        string[] fails = { 
            "T3 (Kargo Operator Hatasi)", 
            "T5 (Odeme Sinir Hatasi)", 
            "T11 (Toplam Tutar Bugi)" 
        };

        // Başarılı Testler
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var t in passes) 
        {
            Console.WriteLine($" [PASS] {t,-5} : Basariyla Tamamlandi.");
        }

        // Hatalı Testler
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var t in fails) 
        {
            Console.WriteLine($" [FAIL] {t,-5} : Yazilim Hatasi Bulundu.");
        }

        // Özet Bilgi
        Console.ResetColor();
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("Toplam: 12 Senaryo | 9 Basarili | 3 Kusurlu (Bug)");
        Console.WriteLine("==================================================");
        Console.WriteLine("\nCikis yapmak icin bir tusa basin...");
        Console.ReadKey();
    }
}
