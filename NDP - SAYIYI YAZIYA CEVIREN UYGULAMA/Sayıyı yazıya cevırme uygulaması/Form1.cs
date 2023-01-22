using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

                            /****************************************************************************
                            ** SAKARYA ÜNİVERSİTESİ
                            ** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
                            ** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
                            ** NESNEYE DAYALI PROGRAMLAMA DERSİ
                            ** 2021-2022 BAHAR DÖNEMİ
                            **
                            ** ÖDEV NUMARASI..........: 2
                            ** ÖĞRENCİ ADI............: Osman Tahir Ozdemir
                            ** ÖĞRENCİ NUMARASI.......: G211210059
                            ** DERSİN ALINDIĞI GRUP...: B
                            ****************************************************************************/

namespace NDP_ODEV_2
{
    public partial class Form1 : Form
        {
          // FORM ELEMANLARINI OLUSTURMA
                Label lblYazi = new Label();
                TextBox txtSayi = new TextBox();
                Label X = new Label();
                Label Y = new Label();
                Button btnHesapla = new Button();

        public Form1()
        {
                 InitializeComponent();
        }
        // Form1 Uygulamasini Calistirdigimizda calisan metot
        private void Form1_Load(object sender, EventArgs e)
        {
                // Formun ozelliklerini degistirme 
                this.Width = 1000;
                this.Height = 650;
                this.Text = "Fonksiyon Hesabı";
                // Textboximizin boyutunu belirleme
                txtSayi.Width = 150;
                txtSayi.Height = 25;
                // Labelimizin boyutunu ve arkaplan rengini belirleme
                lblYazi.Width = 700;
                lblYazi.Height = 25;
                lblYazi.BackColor = Color.LightGray;
                // X labelinin boyutunu belirleme
                X.Height = 25;
                X.Width = 25;
                X.Text = "X";
                // Y labelinin boyutunu belirleme
                Y.Height = 25;
                Y.Width = 25;
                Y.Text = "Y";
                // Butonumuzun boyutunu belirleme
                btnHesapla.Width = 90;
                btnHesapla.Height = 50;
                // Olusturdugumuz araclari forma ekleme
                Controls.Add(txtSayi);
                Controls.Add(X);
                Controls.Add(Y);
                Controls.Add(lblYazi);
                Controls.Add(btnHesapla);
                // X labelinin konumunu belirleme
                X.Left = 80;
                X.Top = 80;
                // Y labelinin konumunu belirleme
                Y.Left = 80;
                Y.Top = 160;
                // Textboximizin konumunu belirleme
                txtSayi.Left = 150;
                txtSayi.Top = 80;
                // Yazi labelinin konumunu belirleme
                lblYazi.Left = 150;
                lblYazi.Top = 160;
                // Butonumuzun konumunu belirleme
                btnHesapla.Left = 165;
                btnHesapla.Top = 250;
                btnHesapla.Text = "Hesapla";
                // Belirli fonksiyonlari olusturma
                btnHesapla.Click += BtnHesapla_Click;
                txtSayi.TextChanged += TxtSayi_TextChanged;
        }
        // Textboxa girilen degerleri kontrol eden metot
        private void TxtSayi_TextChanged(object sender, EventArgs e)
        {
                        // Sadece rakam ve nokta gibi kullanilmasi gerekilen ozel sembollere izin veren if kosulu
                 if (System.Text.RegularExpressions.Regex.IsMatch(txtSayi.Text, "[^0-9-.]"))
                {
                    MessageBox.Show("Lutfen sadece rakam veya nokta giriniz !");
                    txtSayi.Text = "";
                
                }   
        }
        // Butona tiklandiginda islem yapan metot
         private void BtnHesapla_Click(object sender, EventArgs e)
        {
                   // Gerekli string dizilerin olusturulmasi
                     string[] birler = {"","Bir", "Iki", "Uc", "Dort", "Bes", "Alti", "Yedi", "Sekiz", "Dokuz" };
                     string[] onlar = {"", "On", "Yirmi", "Otuz", "Kirk", "Elli", "Altmis", "Yetmis", "Seksen", "Doksan"};
                     string[] yuzler = {"", "Yuz", "Iki Yuz", "Uc Yuz", "Dort Yuz", "Bes Yuz ", "Alti Yuz ", "Yedi Yuz", "Sekiz Yuz ", "Dokuz yuz " };
                     string[] binler = {"", "Bin", "Iki Bin", "Uc Bin", "Dort Bin", "Bes Bin ", "Alti Bin ", "Yedi Bin", "Sekiz Bin ", "Dokuz Bin " };
                    // Girilen TL degeri
                   double Tl;
                    Tl =  Convert.ToDouble(txtSayi.Text);
                    // TL degerini basamaklara ayirma
                    int BirlerTl = (int) Tl % 10;
                    int OnlarTl = (int) (Tl%100) / 10;
                    int Yuzler = (int) (Tl % 1000) / 100;
                    int Binler = (int) (Tl % 10000) / 1000;
                    int Onbinler = (int) (Tl % 100000) / 10000;
                    // Kusurati olmayan Tl degiskeni. Ornegin 125.6 --> 125 e donusmesi
                    double Tl2 = Math.Floor(Tl);
                   // Kusuratli TL den Kusuratsiz TL yi cikarttigimizda kusurati buluruz ve bunu 100 ile carparak noktadan sayiyi elde ederiz
                    double Kurus = (Tl-Tl2)*100;
                    // Noktadan sonraki sayiyi basamaklara ayirma
                    int OnlarKurus = (Convert.ToInt32(Kurus)) / 10;
                    int BirlerKurus = (Convert.ToInt32(Kurus)) % 10;
                    // En fazla 5 basamakli ve kusuratla en fazla 6 basamakli sayiyi kontrol eden if kosulu
            if (Convert.ToDouble(txtSayi.Text) < 100000 && txtSayi.Text.Length <= 7)
            {
                    // Tum basamaklar 0 ise ekrana 0 tl yazdirilir
                     if (Onbinler == 0 &&Binler ==0 && Yuzler == 0 && OnlarTl == 0 && BirlerTl == 0 && OnlarKurus == 0 && BirlerKurus == 0)
                    {
                        // lblYazi labelina yazdirma
                        lblYazi.Text = "Sifir TL";
                    }
                    // Sadece kurus varsa sadece kurus olan kisim yazilir
                    else if (Onbinler == 0 && Binler == 0 && Yuzler == 0 && OnlarTl == 0 && BirlerTl == 0)
                    {
                        // lblYazi labelina yazdirma
                        lblYazi.Text = onlar[OnlarKurus] + " " + birler[BirlerKurus] + " Kurus";
                    }
                    // Kurus kismi yoksa sadece Tl kismi yazilir
                    else if(OnlarKurus==0 && BirlerKurus==0) 
                    {
                        // lblYazi labelina yazdirma
                        lblYazi.Text = onlar[Onbinler] + " " + binler[Binler] + " " + yuzler[Yuzler] + " " + onlar[OnlarTl] + " " + birler[BirlerTl] + " TL"; 
                    }
                    // Tum durumlarin yazildigi durum
                    else
                    {
                        // lblYazi labelina yazdirma
                        lblYazi.Text = onlar[Onbinler] + " " + binler[Binler] + " " + yuzler[Yuzler] + " " + onlar[OnlarTl] + " " + birler[BirlerTl] + " TL"
                       + " " + onlar[OnlarKurus] + " " + birler[BirlerKurus] + " Kurus";
                    }   
                }
            else
            {
                // Ekrana uyari mesaji verme
                MessageBox.Show("Lutfen maksimum bes basamakli bir sayi giriniz ! ondalikli sayi ise 6 basamaga kadar girebilirsiniz ");
                txtSayi.Text = "";
            }
        }
        }
    }

