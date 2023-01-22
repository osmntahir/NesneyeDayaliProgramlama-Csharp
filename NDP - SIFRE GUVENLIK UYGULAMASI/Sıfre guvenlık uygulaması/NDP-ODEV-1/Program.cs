using System;
using System.Text.RegularExpressions;

namespace NDP_ODEV_1
{
    class SifreProgrami
    {

                                    /****************************************************************************
                                    * SAKARYA ÜNİVERSİTESİ
                                    ** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
                                    ** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
                                    ** NESNEYE DAYALI PROGRAMLAMA DERSİ
                                    ** 2021-2022 BAHAR DÖNEMİ
                                    **
                                    ** ÖDEV NUMARASI..........: 1
                                    ** ÖĞRENCİ ADI............: Osman Tahir Özdemir
                                    ** ÖĞRENCİ NUMARASI.......: G211210059
                                    ** DERSİN ALINDIĞI GRUP...: 2-B
                                    ****************************************************************************/

        // BUYUK HARF SAYIISNI HESAPLAYAN METOT
        static int BuyukHarfHesaplayici(string sifre)
        {
                        //Buyuk harf sayisini hesaplatma
                        int BuyukHarfSayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
                        // Buyuk harf sayisini geri dondurme
                        return BuyukHarfSayisi;
        }
        // KUCUK HARF SAYISINI HESAPLAYAN METOT
        static int KucukHarfHesaplayici(string sifre)
        {
                        // Kucuk harf sayisini hesaplatma
                        int KucukHarfSayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
                        // Kucuk harf sayisini geri dondurme
                        return KucukHarfSayisi;
        }
        // RAKAM SAYISINI HESAPLAYAN METOT
        static int RakamHesaplayici(string sifre)
        {
                        // Rakam sayisini hesaplatma
                        int RakamSayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
                        // Rakam sayisini geri dondurme
                        return RakamSayisi;
        }
        // SEMBOL SAYISINI HESAPLAYAN METOT
        static int SembolHesaplayici(string sifre)
        {
                        // Sembol Sayisini hesaplatma
                        int SembolSayisi = sifre.Length - Regex.Replace(sifre, "[!-/:-@[-`{-~]", "").Length;
                        // Sembol sayisini geri dondurme
                        return SembolSayisi;
        }
        // Sifre Kurallarini Ekrana Yazdiran Metot
        static void SifreOlusturmaKurallari()
        {
                        Console.WriteLine("***** SIFRE OLUSTURMA KURALLARI *****");
                        Console.WriteLine();
                        Console.WriteLine("En az 9 haneli bir sifre olsuturunuz");
                        Console.WriteLine("Sifre olusturuken en az bir buyuk harf , kucuk harf , sembol ve rakam kullaniniz");
                        Console.WriteLine();
                        Console.WriteLine("***** SIFRE PUANLAMA KURALLARI *****");
                        Console.WriteLine();
                        Console.WriteLine("Her bir küçük harf 10 puan ve 20 puandan fazla küçük harften verilemez");
                        Console.WriteLine("Her bir büyük harf 10 puan ve 20 puandan fazla büyük harften verilemez");
                        Console.WriteLine("Her bir rakam 10 puan ve 20 puandan fazla rakamdan verilemez");
                        Console.WriteLine("Her bir sembol 10 puandır.");
                        Console.WriteLine();
                        Console.WriteLine("***** SIFRE GUVENLIK KURALLARI *****");
                        Console.WriteLine();
                        Console.WriteLine("Genel puan 70 den küçük ise şifre kabul edilemez.");
                        Console.WriteLine("Genel puan 70 ile 90 arasında ise şifre kabul edilir ");
                        Console.WriteLine("Genel puan 90 ile 100 şifre kabul edilir ve güçlü.");
                        Console.WriteLine();
        }
        // Main Metotu
        static void Main(string[] args)
        {
                        SifreOlusturmaKurallari();
                        // Sifre olusturma ve kullanicidan isteme
                        string Sifre;
                        Console.Write("Kurallara gore bir sifre giriniz : ");
                        Sifre = Console.ReadLine();
                        // Sifre puani degiskeni olusturma 
                        int SifrePuani = 0;

            // SIFRE OLUSMASI ICIN KARAR YAPILARI
            if (Sifre.Length < 9) // Sifre.Length --> Sifrenin boyutunu verir
            {
                        Console.WriteLine("Sifre olsuturulamadi ! Lutfen en az 9 haneli bir sifre olusturun ");
            }
            else
            {
                    // Sifre olusturma kurallarindaki sartlari kontrol ettirme
                      if (BuyukHarfHesaplayici(Sifre) == 0 || KucukHarfHesaplayici(Sifre) == 0 || RakamHesaplayici(Sifre) == 0 || SembolHesaplayici(Sifre) == 0)
                    {
                              Console.WriteLine("Sifre olusturulamadi ! Lutfen en az bir buyuk harf , kucuk harf , sembol veya rakam giriniz !!");
                    }
                    else
                    {
                            //SIFRE OLUSTURUKDU

                            // OLUSTURULAN SIFREYI PUANLAMA KISMI

                            // Eger 20 puan ve daha az bir puan almissa 10 ile carparak bulunur. Mesela 1 tane buyuk harf varsa 1*10 || 2 tane varsa 2*10
                            // Aksi durumda ise yani 20 yi asmissa 20 puan alir. Cunku 20 puana ulasmistir vc fazlasi verilemez
                            if (BuyukHarfHesaplayici(Sifre) * 10 <= 20)
                            {
                                SifrePuani += BuyukHarfHesaplayici(Sifre) * 10;
                            }
                            else
                            {
                                SifrePuani += 20;
                            }
                            if (KucukHarfHesaplayici(Sifre) * 10 <= 20)
                            {
                                SifrePuani += KucukHarfHesaplayici(Sifre) * 10;
                            }
                            else
                            {
                                SifrePuani += 20;
                            }
                            if (RakamHesaplayici(Sifre) * 10 <= 20)
                            {
                                SifrePuani += RakamHesaplayici(Sifre) * 10;
                            }
                            else
                            {
                                SifrePuani += 20;
                            }
                                // Sembol sayisinda kisitlama olmadigi icin direkt 10 ile carpilir
                                SifrePuani += SembolHesaplayici(Sifre) * 10;

                            // Sifre hanesi 9 ise 10 puan verilme durumu 
                            if (Sifre.Length == 9)
                            {
                                SifrePuani += 10;
                            }


                            // HESAPLANAN PUANA GORE SIFRENIN GUVENLIK DURUMU

                            if (SifrePuani < 70)
                            {
                                Console.WriteLine("Yetersiz guclukte sifre. Lutfen kurallara gore daha guclu bir sifre giriniz");
                            }
                            else if (SifrePuani >= 70 && SifrePuani < 90)
                            {
                                Console.WriteLine("Orta guclukte bir sifre olusturuldu");
                            }
                            else if (SifrePuani >= 90 && SifrePuani <= 100)
                            {
                                Console.WriteLine("Guclu bir sifre olusturuldu");
                            }
                            else
                            {
                                Console.WriteLine("Tebrikler !! Coook Gucluu bir sifre olusturulduu !!");
                            }

                            Console.WriteLine("Sifre puaniniz : " + SifrePuani);
                        }
                    }
             }
    }
}

                                                                            // ODEV BITMISTIR :))