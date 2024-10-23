using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Dizi> diziler = new List<Dizi>(); // Dizilerin tutulduğu ana liste
        bool devamEt = true;

        while (devamEt)
        {
            Dizi yeniDizi = DiziBilgileriniAl(); // Yeni dizi bilgilerini al
            diziler.Add(yeniDizi); // Listeye ekle

            Console.WriteLine("Başka bir dizi eklemek istiyor musunuz? (E/H): ");
            string cevap = Console.ReadLine().ToLower();

            if (cevap != "e")
                devamEt = false; // Kullanıcı 'e' dışında bir şey yazarsa döngüden çık
        }

        // Komedi türündeki dizilerden yeni bir liste oluştur
        List<Komediler> komediListesi = diziler
            .Where(d => d.Tur.ToLower() == "komedi")
            .Select(d => new Komediler(d.Ad, d.Tur, d.Yonetmen))
            .OrderBy(k => k.Ad).ThenBy(k => k.Yonetmen) // Sıralama işlemi
            .ToList();

        // Komedi dizilerini ekrana yazdır
        Console.WriteLine("\n--- Komedi Dizileri ---");
        foreach (var komedi in komediListesi)
        {
            Console.WriteLine($"Dizi Adı: {komedi.Ad}, Türü: {komedi.Tur}, Yönetmen: {komedi.Yonetmen}");
        }
    }

    static Dizi DiziBilgileriniAl()
    {
        Console.Write("Dizi Adı: ");
        string ad = Console.ReadLine();

        Console.Write("Dizi Türü: ");
        string tur = Console.ReadLine();

        Console.Write("Yönetmen: ");
        string yonetmen = Console.ReadLine();

        Console.Write("Sezon Sayısı: ");
        int sezonSayisi = int.Parse(Console.ReadLine());

        Console.Write("Bölüm Sayısı: ");
        int bolumSayisi = int.Parse(Console.ReadLine());

        return new Dizi(ad, tur, yonetmen, sezonSayisi, bolumSayisi);
    }
}

// Ana Dizi Sınıfı
class Dizi
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yonetmen { get; set; }
    public int SezonSayisi { get; set; }
    public int BolumSayisi { get; set; }

    public Dizi(string ad, string tur, string yonetmen, int sezonSayisi, int bolumSayisi)
    {
        Ad = ad;
        Tur = tur;
        Yonetmen = yonetmen;
        SezonSayisi = sezonSayisi;
        BolumSayisi = bolumSayisi;
    }
}

// Komedi Türündeki Dizileri Tutacak Sınıf
class Komediler
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yonetmen { get; set; }

    public Komediler(string ad, string tur, string yonetmen)
    {
        Ad = ad;
        Tur = tur;
        Yonetmen = yonetmen;
    }
}

