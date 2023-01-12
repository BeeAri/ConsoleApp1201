namespace ConsoleApp1201
{
    internal class Program
    {
        static List<string> isimler1 = new() { "Al", "Ak", "At", "Az","Ab" };
        static List<string> isimler2 = new() { "Bl", "Bk", "Bt", "Bz","Bb" };
        static List<string> bolumler = new() { "IK", "Satış", "Pazarlama", "Arge", "Satın Alma" };
        static List<Personel> personelListesi = new();
        static List<Musteri> musteriListesi = new();
        static void Main(string[] args)
        {
            Random random1 = new Random();
            for (int i = 0; i < 10; i++)
            {
                personelListesi.Add(new() 
                { AdSoyad = isimler1[random1.Next(isimler1.Count)], 
                  Departman = bolumler[random1.Next(bolumler.Count)] });
            }

            for (int i = 0; i < 10; i++)
            {
                musteriListesi.Add(new() 
                { AdSoyad = isimler2[random1.Next(isimler1.Count)] });                  
            }
            List<object> pikniktayfası = new();
            pikniktayfası.AddRange(musteriListesi);
            pikniktayfası.AddRange(personelListesi);

            Yazdır(pikniktayfası);
            MarkajListesiYazdır();

            static void Yazdır(List<Object> tayfa)
            {
                foreach (var item in tayfa)
                {
                    if (item is Personel)
                    {
                        Personel personel = (Personel)item;
                        Console.Write(personel.AdSoyad+": ");
                        Console.WriteLine(personel.Departman);
                    }
                    else
                    {
                        Musteri musteri = (Musteri)item;
                        Console.WriteLine(musteri.AdSoyad);
                    }
                }
            }

            static void MarkajListesiYazdır()
            {
                var markajListesi = musteriListesi.Zip(personelListesi);

                foreach (var item in markajListesi)
                {
                    Console.WriteLine("{0} - {1}:{2}", item.First.AdSoyad, item.Second.AdSoyad, item.Second.Departman);
                }
            }      
        }
    }

    class Personel
    {
        public string AdSoyad { get; set; }
        public string Departman { get; set; }
    }
    class Musteri
    {
        public string AdSoyad { get; set; }
    }

}