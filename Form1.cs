using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public Dukkan d = new Dukkan();
        public UrunKatalogu uk = new UrunKatalogu();
        public Satis s = new Satis();
        public SatisKalemi sk = new SatisKalemi();
        public Musteri m = new Musteri();
        public KasaGorevlisi kg = new KasaGorevlisi();
        public KrediKarti kre = new KrediKarti();
        public Terminal t = new Terminal();
        public HesapDefteri hd = new HesapDefteri();

        private void Form1_Load(object sender, EventArgs e)
        {
            lblSaatVeTarih.Text = DateTime.Now.ToString("HH:mm.ss") + "\n" + DateTime.Now.Date.ToString("dd/MM/yyyy");
            
            tpAnaMenu.TabPages.Remove(tpUrunIleIlgili);
            tpAnaMenu.TabPages.Remove(tpSatis);
            tpAnaMenu.TabPages.Remove(tpMusteri);
            
            KasaGorevlisi kg1 = new KasaGorevlisi("Bahadır", "Karaağaç", "82401708044", "0531 669 21 66", "Cumhuriyet Mah. Ülkü Sk. No: 80/5 Turgutlu/Manisa", "kasiyer1", "1234"); kg.KasiyerEkle(kg1);
            KasaGorevlisi kg2 = new KasaGorevlisi("Aylin", "Sarpkaya", "99195636446", "0547 398 82 39", "İstiklal Mah. Akçakmak Yolu Sk. No: 55/1 Turgutlu/Manisa", "kasiyer2", "1235"); kg.KasiyerEkle(kg2);
            KasaGorevlisi kg3 = new KasaGorevlisi("Mete", "Işıkara", "25666590054", "0541 477 94 14", "Şehitler Mah. Şehit Oğuz Erbay Sk. No: 36/2 Turgutlu/Manisa", "kasiyer3", "1236"); kg.KasiyerEkle(kg3);
            KasaGorevlisi kg4 = new KasaGorevlisi("Dolunay", "Tellioğlu", "44371933048", "0533 541 20 22", "Selvilitepe Mah. Akıncılar Sk. No: 67/4 Turgutlu/Manisa", "kasiyer4", "1237"); kg.KasiyerEkle(kg4);
        }


        void ListViewUrunler(ListView Liste)
        {
            Liste.Columns.Add("Ürün Kodu", 75);
            Liste.Columns.Add("Ürün Adı", 150);
            Liste.Columns.Add("Ürün Türü", 150);
            Liste.Columns.Add("Ürün Adedi", 75);
            Liste.Columns.Add("Ürün Ağırlığı", 100);
            Liste.Columns.Add("Ürün Fiyatı", 100);
            Liste.Columns.Add("Ürün Alış Tarihi", 100);
            Liste.Columns.Add("Ürün Açıklaması", 400);
        }

        void ListViewSepet(ListView Liste)
        {
            Liste.Columns.Add("Ad", 148);
            Liste.Columns.Add("Tür", 148);
            Liste.Columns.Add("Adet", 50);
        }

        void ListViewSatilan(ListView Liste)
        {
            Liste.Columns.Add("Ad", 148);
            Liste.Columns.Add("Tür", 148);
            Liste.Columns.Add("Adet", 50);
        }
        void ListViewMusteri(ListView Liste)
        {
            Liste.Columns.Add("Müşteri ID", 150);
            Liste.Columns.Add("Ad", 150);
            Liste.Columns.Add("Soyad", 150);
            Liste.Columns.Add("Aldığı Ürün Miktarı", 150);
            Liste.Columns.Add("Ödediği Fiyat", 100);
            Liste.Columns.Add("Ödeme Türü", 100);
        }
        
        string girisyapanKasiyer = "";
        
        private bool btnKasiyerGirisiTiklandi = false, btnKasiyerCikisiTiklandi = true, GirisYapildiMi = false;
        
        int kullaniciGirisSayac = 0;

        private void btnKasiyerGirisi_Click(object sender, EventArgs e)
        {
            string girisyapanKasiyerKullaniciAdi = "", girisyapanKasiyerParola = "";
            foreach (KasaGorevlisi item in kg.KasiyerListe)
            {
                if (String.Equals(item.KullaniciAdi, txtKasiyerKullaniciAdi.Text))
                {
                    girisyapanKasiyerKullaniciAdi = txtKasiyerKullaniciAdi.Text;
                    if (String.Equals(item.Parola, txtKasiyerParola.Text))
                    {
                        girisyapanKasiyerParola = txtKasiyerParola.Text;
                        btnKasiyerGirisiTiklandi = true; btnKasiyerCikisiTiklandi = false;
                        tpAnaMenu.TabPages.Insert(1, tpUrunIleIlgili);
                        tpAnaMenu.TabPages.Insert(2, tpSatis);
                        tpAnaMenu.TabPages.Insert(3, tpMusteri);
                        girisyapanKasiyer = item.Ad + " " + item.Soyad;
                        MessageBox.Show(girisyapanKasiyer + " - Sisteme girişi sağladınız.");
                        GirisYapildiMi = true;
                        btnKasiyerGirisi.Enabled = false;
                    }
                }
            }
            if (GirisYapildiMi == false)
            {
                if ((txtKasiyerKullaniciAdi.Text == "") && (txtKasiyerParola.Text == ""))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre alanını boş bırakmayın.");
                    kullaniciGirisSayac++;
                }
                
                else if (txtKasiyerKullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı adı alanını boş bırakmayın.");
                    kullaniciGirisSayac++;
                }
                
                else if (txtKasiyerParola.Text == "")
                {
                    MessageBox.Show("Parola alanını boş bırakmayın.");
                    kullaniciGirisSayac++;
                }
                
                else if (girisyapanKasiyerKullaniciAdi == "")
                {
                    MessageBox.Show("Böyle bir kullanıcı adı sistemde yok.");
                    kullaniciGirisSayac++;
                }
                
                else if (girisyapanKasiyerParola == "")
                {
                    MessageBox.Show("Girdiğiniz kullanıcı adı sistemde kayıtlı, fakat parolası yanlış.");
                    kullaniciGirisSayac++;
                }

                if (kullaniciGirisSayac == 1)
                    MessageBox.Show("2 hakkınız kaldı.");
                else if (kullaniciGirisSayac == 2)
                    MessageBox.Show("1 hakkınız kaldı.");
                else if (kullaniciGirisSayac == 3)
                {
                    MessageBox.Show("Maalesef hakkınız kalmadı.\nProgram kapanacaktır.");
                    Application.Exit();
                }
            }

            txtKasiyerKullaniciAdi.ResetText();
            txtKasiyerParola.ResetText();

        }

        private void btnKasiyerCikisi_Click(object sender, EventArgs e)
        {
            btnKasiyerCikisiTiklandi = true;
            tpAnaMenu.TabPages.Remove(tpUrunIleIlgili);
            tpAnaMenu.TabPages.Remove(tpSatis);
            tpAnaMenu.TabPages.Remove(tpMusteri);
            btnKasiyerGirisi.Enabled = true;
            MessageBox.Show(girisyapanKasiyer + " - Sistemden çıkışı sağladınız.");
        }

        private void btnProgramiKapat_Click(object sender, EventArgs e)
        {
            if ((btnKasiyerGirisiTiklandi == true) && (btnKasiyerCikisiTiklandi == false))
            {
                MessageBox.Show("Lütfen açtığınız oturumu kapatın.");
            }
            else if ((btnKasiyerGirisiTiklandi == true) && (btnKasiyerCikisiTiklandi == true))
            {
                Application.Exit();
            }
        }

        private void cbUrunKataloguSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbUrunAltKatalogu.ResetText();
            cbUrunAltKatalogu.Items.Clear();

            if (cbUrunKataloguSecimi.SelectedIndex == 0)
            {
                cbUrunAltKatalogu.Items.Add("Bakliyat ve Makarna");
                cbUrunAltKatalogu.Items.Add("Çorba ve Bulyon");
                cbUrunAltKatalogu.Items.Add("Dondurulmuş Gıda");
                cbUrunAltKatalogu.Items.Add("Hazır Yemek, Konserve ve Salça");
                cbUrunAltKatalogu.Items.Add("Yağ, Tuz ve Baharat");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 1)
            {
                cbUrunAltKatalogu.Items.Add("Yumurta");
                cbUrunAltKatalogu.Items.Add("Zeytin");
                cbUrunAltKatalogu.Items.Add("Kahvaltılık");
                cbUrunAltKatalogu.Items.Add("Pastane Ürünleri");
                cbUrunAltKatalogu.Items.Add("Krema ve Sos");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 2)
            {
                cbUrunAltKatalogu.Items.Add("Kırmızı Et");
                cbUrunAltKatalogu.Items.Add("Kümes Hayvanları");
                cbUrunAltKatalogu.Items.Add("Balık");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 3)
            {
                cbUrunAltKatalogu.Items.Add("Süt");
                cbUrunAltKatalogu.Items.Add("Peynir");
                cbUrunAltKatalogu.Items.Add("Yoğurt");
                cbUrunAltKatalogu.Items.Add("Tereyağı ve Margarin");
                cbUrunAltKatalogu.Items.Add("Dondurma ve Sütlü Tatlı");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 4)
            {
                cbUrunAltKatalogu.Items.Add("Meyve");
                cbUrunAltKatalogu.Items.Add("Sebze");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 5)
            {
                cbUrunAltKatalogu.Items.Add("Gazlı İçecek");
                cbUrunAltKatalogu.Items.Add("Çay ve Kahve");
                cbUrunAltKatalogu.Items.Add("Günlük İçecek");
                cbUrunAltKatalogu.Items.Add("Gazsız İçecek");
                cbUrunAltKatalogu.Items.Add("Su ve Maden Suyu");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 6)
            {
                cbUrunAltKatalogu.Items.Add("Çikolata ve Gofret");
                cbUrunAltKatalogu.Items.Add("Bisküvi ve Çerez");
                cbUrunAltKatalogu.Items.Add("Şekersiz Tatlandırıcı Ürünler");
                cbUrunAltKatalogu.Items.Add("Sakız ve Şekerleme");
                cbUrunAltKatalogu.Items.Add("Unlu Mamül ve Tatlı");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 7)
            {
                cbUrunAltKatalogu.Items.Add("Çamaşır Yıkama");
                cbUrunAltKatalogu.Items.Add("Bulaşık Yıkama");
                cbUrunAltKatalogu.Items.Add("Banyo ve Çamaşır Gereçleri");
                cbUrunAltKatalogu.Items.Add("Ev Temizleyiciler");
                cbUrunAltKatalogu.Items.Add("Ev Temizlik Gereçleri");
            }
            else if (cbUrunKataloguSecimi.SelectedIndex == 8)
            {
                cbUrunAltKatalogu.Items.Add("Kağıt Ürünleri");
                cbUrunAltKatalogu.Items.Add("Ağız Bakım");
                cbUrunAltKatalogu.Items.Add("Saç Bakım");
                cbUrunAltKatalogu.Items.Add("Traş Malzemeleri");
                cbUrunAltKatalogu.Items.Add("Duş ve Banyo");
                cbUrunAltKatalogu.Items.Add("Yüz Bakım");
                cbUrunAltKatalogu.Items.Add("Vücut ve El Bakım");
                cbUrunAltKatalogu.Items.Add("Güneş Bakım");
                cbUrunAltKatalogu.Items.Add("Makyaj Malzemeleri ve Aksesuar");
                cbUrunAltKatalogu.Items.Add("Parfüm ve Deodorant");
                cbUrunAltKatalogu.Items.Add("Ağda ve Tüy Dökücüler");
                cbUrunAltKatalogu.Items.Add("Sağlık Ürünleri");
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            UrunTanimi urunEkle = new UrunTanimi();
            int dongu1 = 0;
            
            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                if (Convert.ToInt32(txtUrunKodu.Text) == item.Kod)
                {
                    MessageBox.Show("Girdiğiniz bu ürün koduyla ekleme yapamazsınız.\nSebebi aynı ürün koduna sahip bir ürün olmasındandır.");
                    txtUrunKodu.ResetText();
                    dongu1 = dongu1 + 1;
                }
                
                else if (String.Equals(txtUrunAdi.Text, item.Ad))
                {
                    if (String.Equals(txtUrunTuru.Text, item.Tur))
                    {
                        MessageBox.Show("Girdiğiniz bu ürün türüyle ekleme yapamazsınız.\nSebebi bu ürün içinde böyle bir tür bulunmasındandır.");
                        txtUrunTuru.ResetText();
                        dongu1 = dongu1 + 1;
                    }
                }
            }
            
            if (dongu1 == 0)
            {
                urunEkle.Kod = Convert.ToInt32(txtUrunKodu.Text);
                urunEkle.Katalog = cbUrunKataloguSecimi.SelectedItem.ToString();
                urunEkle.AltKatalog = cbUrunAltKatalogu.SelectedItem.ToString();
                urunEkle.Ad = txtUrunAdi.Text;
                urunEkle.Tur = txtUrunTuru.Text;
                urunEkle.Adet = Convert.ToInt32(numUrunAdedi.Value);
                urunEkle.Agirlik = txtUrunAgirligi.Text;
                urunEkle.Fiyat = Convert.ToDecimal(txtUrunFiyati.Text);
                urunEkle.AlisTarihi = Convert.ToDateTime(dtpUrunAlisTarihi.Value.ToShortDateString());
                urunEkle.Tanim = txtUrunAciklamasi.Text;

                MessageBox.Show("Ürün başarıyla eklendi.");

                d.UrunEkle(urunEkle);

                txtUrunKodu.ResetText();
                cbUrunKataloguSecimi.ResetText();
                cbUrunAltKatalogu.ResetText();
                txtUrunKodu.ResetText();
                txtUrunAdi.ResetText();
                txtUrunTuru.ResetText();
                numUrunAdedi.ResetText();
                txtUrunAgirligi.ResetText();
                txtUrunFiyati.ResetText();
                dtpUrunAlisTarihi.ResetText();
                txtUrunAciklamasi.ResetText();

            }
        }
        
        int dongu_1 = -1, dongu_2 = -1, dongu_3 = -1, dongu_4 = -1, dongu_5 = -1, dongu_6 = -1, dongu_7 = -1, dongu_8 = -1, dongu_9 = -1;

        private void ts_cbKatalog_Click(object sender, EventArgs e)
        {
            if (ts_cbKatalog.SelectedIndex == dongu_1)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Bakliyat ve Makarna");
                ts_cbAltKatalog.Items.Add("Çorba ve Bulyon");
                ts_cbAltKatalog.Items.Add("Dondurulmuş Gıda");
                ts_cbAltKatalog.Items.Add("Hazır Yemek, Konserve ve Salça");
                ts_cbAltKatalog.Items.Add("Yağ, Tuz ve Baharat");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_2 + 1)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Yumurta");
                ts_cbAltKatalog.Items.Add("Zeytin");
                ts_cbAltKatalog.Items.Add("Kahvaltılık");
                ts_cbAltKatalog.Items.Add("Pastane Ürünleri");
                ts_cbAltKatalog.Items.Add("Krema ve Sos");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_3 + 2)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Kırmızı Et");
                ts_cbAltKatalog.Items.Add("Kümes Hayvanları");
                ts_cbAltKatalog.Items.Add("Balık");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_4 + 3)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Süt");
                ts_cbAltKatalog.Items.Add("Peynir");
                ts_cbAltKatalog.Items.Add("Yoğurt");
                ts_cbAltKatalog.Items.Add("Tereyağı ve Margarin");
                ts_cbAltKatalog.Items.Add("Dondurma ve Sütlü Tatlı");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_5 + 4)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Meyve");
                ts_cbAltKatalog.Items.Add("Sebze");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_6 + 5)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Gazlı İçecek");
                ts_cbAltKatalog.Items.Add("Çay ve Kahve");
                ts_cbAltKatalog.Items.Add("Günlük İçecek");
                ts_cbAltKatalog.Items.Add("Gazsız İçecek");
                ts_cbAltKatalog.Items.Add("Su ve Maden Suyu");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_7 + 6)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Çikolata ve Gofret");
                ts_cbAltKatalog.Items.Add("Bisküvi ve Çerez");
                ts_cbAltKatalog.Items.Add("Şekersiz Tatlandırıcı Ürünler");
                ts_cbAltKatalog.Items.Add("Sakız ve Şekerleme");
                ts_cbAltKatalog.Items.Add("Unlu Mamül ve Tatlı");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_8 + 7)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Çamaşır Yıkama");
                ts_cbAltKatalog.Items.Add("Bulaşık Yıkama");
                ts_cbAltKatalog.Items.Add("Banyo ve Çamaşır Gereçleri");
                ts_cbAltKatalog.Items.Add("Ev Temizleyiciler");
                ts_cbAltKatalog.Items.Add("Ev Temizlik Gereçleri");
            }
            else if (ts_cbKatalog.SelectedIndex == dongu_9 + 8)
            {
                ts_cbAltKatalog.Items.Clear();
                ts_cbAltKatalog.Text = "";
                ts_cbAltKatalog.Items.Add("Tümü");
                ts_cbAltKatalog.Items.Add("Kağıt Ürünleri");
                ts_cbAltKatalog.Items.Add("Ağız Bakım");
                ts_cbAltKatalog.Items.Add("Saç Bakım");
                ts_cbAltKatalog.Items.Add("Traş Malzemeleri");
                ts_cbAltKatalog.Items.Add("Duş ve Banyo");
                ts_cbAltKatalog.Items.Add("Yüz Bakım");
                ts_cbAltKatalog.Items.Add("Vücut ve El Bakım");
                ts_cbAltKatalog.Items.Add("Güneş Bakım");
                ts_cbAltKatalog.Items.Add("Makyaj Malzemeleri ve Aksesuar");
                ts_cbAltKatalog.Items.Add("Parfüm ve Deodorant");
                ts_cbAltKatalog.Items.Add("Ağda ve Tüy Dökücüler");
                ts_cbAltKatalog.Items.Add("Sağlık Ürünleri");
            }
            
            if (dongu_1 < 0) dongu_1++; if (dongu_2 < 0) dongu_2++; if (dongu_3 < 0) dongu_3++;
            if (dongu_4 < 0) dongu_4++; if (dongu_5 < 0) dongu_5++; if (dongu_6 < 0) dongu_6++;
            if (dongu_7 < 0) dongu_7++; if (dongu_8 < 0) dongu_8++; if (dongu_9 < 0) dongu_9++;
        }

        private void btnUrunKatalogu_Click(object sender, EventArgs e)
        {
            lvUrunKatalogu.Clear();
            lvUrunKatalogu.View = View.Details;
            lvUrunKatalogu.FullRowSelect = true;
            ListViewUrunler(lvUrunKatalogu);
            
            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                string[] row = { item.Kod.ToString(), item.Ad.ToString(), item.Tur.ToString(), item.Adet.ToString(), item.Agirlik.ToString(), item.Fiyat.ToString() + " TL", item.AlisTarihi.ToShortDateString(), item.Tanim.ToString() };

                if ((ts_cbKatalog.SelectedItem != null) && (ts_cbAltKatalog.SelectedItem.ToString() == "Tümü"))
                {
                    if (String.Equals(item.Katalog, ts_cbKatalog.SelectedItem.ToString()))
                    {
                        ListViewItem veriler = new ListViewItem(row);
                        lvUrunKatalogu.Items.Add(veriler);
                    }
                }

                else if ((ts_cbKatalog.SelectedItem != null) && (ts_cbAltKatalog.SelectedItem != null))
                {
                    if (String.Equals(item.Katalog, ts_cbKatalog.SelectedItem.ToString()))
                    {
                        if (String.Equals(item.AltKatalog, ts_cbAltKatalog.SelectedItem))
                        {
                            ListViewItem veriler = new ListViewItem(row);
                            lvUrunKatalogu.Items.Add(veriler);
                        }
                    }
                }
            }
        }
        
        string StokAzaltilacakUrun = "", StokAzaltilacakUrunTuru = "";
        string StokArtirilacakUrun = "", StokArtirilacakUrunTuru = "";

        /*private void lvSepettekiUrun_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }*/

        string SilinecekUrun = "", SilinecekUrunTuru = "";
        string SepeteEklenecekUrun = "", SepeteEklenecekUrunTuru = "";

        private void btnSorgulanacakUrun_Click(object sender, EventArgs e)
        {
            int sorgulanacakUrunDongu = -1;
            
            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                if (String.Equals(item.Ad, txtSorgulanacakUrunAdi.Text))
                {
                    StokAzaltilacakUrun = txtSorgulanacakUrunAdi.Text;
                    StokArtirilacakUrun = txtSorgulanacakUrunAdi.Text;
                    SilinecekUrun = txtSorgulanacakUrunAdi.Text;
                    SepeteEklenecekUrun = txtSorgulanacakUrunAdi.Text;
                    
                    if ((String.Equals(item.Tur, txtSorgulanacakUrunTuru.Text)) && (item.Adet != 0))
                    {
                        StokAzaltilacakUrunTuru = txtSorgulanacakUrunTuru.Text;
                        
                        StokArtirilacakUrunTuru = txtSorgulanacakUrunTuru.Text;
                        
                        SilinecekUrunTuru = txtSorgulanacakUrunTuru.Text;
                        
                        SepeteEklenecekUrunTuru = txtSorgulanacakUrunTuru.Text;
                        
                        if (String.Equals(item.Ad, StokAzaltilacakUrun))
                        {
                            if ((String.Equals(item.Tur, StokAzaltilacakUrunTuru)) && (sorgulanacakUrunDongu != d.Urun.UrunListe.Count))
                            {
                                lblSorgulananUrunBilgisi.Text = "Sorgulattığınız ürün stoklarda mevcuttur." + "\n\nİlgili Detaylar: \n\n" +
                                              "Ürün Kodu: " + item.Kod + Environment.NewLine +
                                              "Ürün Kataloğu: " + item.Katalog + Environment.NewLine +
                                              "Ürün Alt Kataloğu: " + item.AltKatalog + Environment.NewLine +
                                              "Ürün Adı: " + item.Ad + Environment.NewLine +
                                              "Ürün Türü: " + item.Tur + Environment.NewLine +
                                              "Ürün Adedi: " + item.Adet + Environment.NewLine +
                                              "Ürün Ağırlığı: " + item.Agirlik + Environment.NewLine +
                                              "Ürün Fiyatı: " + item.Fiyat + " TL";
                                
                                lblStokAzaltma.Visible = true;
                                numStokAzaltma.Visible = true;
                                btnStokAzaltma.Visible = true;
                                
                                lblStokArtirma.Visible = true;
                                numStokArtirma.Visible = true;
                                btnStokArtirma.Visible = true;
                                
                                lblUrunSilme.Visible = true;
                                btnUrunSilme.Visible = true;
                                
                                lblSepeteEklemekIsterMisiniz.Visible = true;
                                lblKacTaneUrun.Visible = true;
                                btnSepeteEkle.Visible = true;
                                numKacTane.Visible = true;
                                lblSepeteBasariylaEklenmisUrun.Visible = true;
                                
                                pbUrunSorgula.Visible = true;
                                
                                sorgulanacakUrunDongu++;
                                
                                break;
                            }
                            
                            else
                            {
                                lblSorgulananUrunBilgisi.Text = "Sorgulattığınız ürün stoklarda mevcut değildir.";
                                
                                lblStokAzaltma.Visible = false;
                                numStokAzaltma.Visible = false;
                                btnStokAzaltma.Visible = false;
                                
                                lblStokArtirma.Visible = false;
                                numStokArtirma.Visible = false;
                                btnStokArtirma.Visible = false;
                            }
                        }
                    }
                    
                    else
                    {
                        lblSorgulananUrunBilgisi.Text = "Sorgulattığınız ürün türü stoklarda mevcut değildir.";
                        
                        StokAzaltilacakUrunTuru = "";
                        
                        StokArtirilacakUrunTuru = "";
                        
                        SilinecekUrunTuru = "";
                        
                        SepeteEklenecekUrunTuru = "";
                    }
                }
                
                else
                {
                    lblSorgulananUrunBilgisi.Text = "Sorgulattığınız ürün stoklarda mevcut değildir.";
                    StokAzaltilacakUrun = "";
                    StokArtirilacakUrun = "";
                    SilinecekUrun = "";
                    SepeteEklenecekUrun = "";
                }
            }
            if (d.Urun.UrunListe.Count == 0)
                lblSorgulananUrunBilgisi.Text = "Sorgulattığınız ürün stoklarda mevcut değildir.";
        }

        private void btnStokAzaltma_Click(object sender, EventArgs e)
        {
            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                if (String.Equals(item.Ad, StokAzaltilacakUrun))
                {
                    if (String.Equals(item.Tur, StokAzaltilacakUrunTuru))
                    {
                        if (!(item.Adet >= numStokAzaltma.Value))
                            MessageBox.Show("Seçtiğiniz sayıda stok azaltma yapamazsınız!\nSebebi ürün adedinin seçtiğiniz stok azaltma değerinden küçük olmasıdır.");
                        else
                            item.Adet = item.Adet - Convert.ToInt32(numStokAzaltma.Value);
                    }
                }
                
                if (item.Adet == 0)
                {
                    d.UrunSil(item);
                    break;
                }
            }
            if (StokAzaltilacakUrun == "")
                MessageBox.Show("Stoğunu azaltmak istediğiniz ürün stoklarda bulunmamaktadır.");
            else if (StokAzaltilacakUrunTuru == "")
                MessageBox.Show("Stoğunu azaltmak istediğiniz ürünün bu türü stoklarda bulunmamaktadır.");
        }

        /*private void txtSorgulanacakUrunAdi_TextChanged(object sender, EventArgs e)
        {
        }*/

        private void btnStokArttirma_Click(object sender, EventArgs e)
        {
            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                if (String.Equals(item.Ad, StokArtirilacakUrun))
                {
                    if (String.Equals(item.Tur, StokArtirilacakUrunTuru))
                    {
                        if (numStokArtirma.Value >= 0)
                            item.Adet = item.Adet + Convert.ToInt32(numStokArtirma.Value);
                        else
                            MessageBox.Show("Seçtiğiniz sayıda stok artırım yapamazsınız!\nSebebi ürün adedinin seçtiğiniz stok arttırma değerinden küçük olmasıdır.");
                    }
                }
            }
            if (StokArtirilacakUrun == "")
                MessageBox.Show("Stoğunu artırmak istediğiniz ürün stoklarda bulunmamaktadır.");
            else if (StokArtirilacakUrunTuru == "")
                MessageBox.Show("Stoğunu artırmak istediğiniz ürünün bu türü stoklarda bulunmamaktadır.");
        }

        private void btnUrunSilme_Click(object sender, EventArgs e)
        {
            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                if (String.Equals(item.Ad, SilinecekUrun))
                {
                    if (String.Equals(item.Tur, SilinecekUrunTuru))
                    {
                        DialogResult secim = MessageBox.Show("Seçilen ürün silinecektir. Onaylıyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (secim == DialogResult.Yes)
                        {
                            d.UrunSil(item);
                            break;
                        }
                    }
                }
            }
            if (SilinecekUrun == "")
                MessageBox.Show("Silmek istediğiniz ürün stoklarda bulunmamaktadır.");
            else if (SilinecekUrunTuru == "")
                MessageBox.Show("Silmek istediğiniz ürünün bu türü stoklarda bulunmamaktadır.");
        }

        string sepeteEklenenUrun = "", sepeteEklenenUrunTuru = "";

        int sepeteEklenmisUrunAdedi = 0;
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            bool sepeteEklemekIcinDongu = false;

            UrunTanimi sepeteUrunEkle = new UrunTanimi();

            foreach (UrunTanimi item in d.Urun.UrunListe)
            {
                if (String.Equals(item.Ad, SepeteEklenecekUrun))
                {
                    if (String.Equals(item.Tur, SepeteEklenecekUrunTuru))
                    {
                        foreach (UrunTanimi item2 in sk.Urun.UrunSepetiListe)
                        {
                            if (String.Equals(item2.Ad, SepeteEklenecekUrun))
                            {
                                if (String.Equals(item2.Tur, SepeteEklenecekUrunTuru))
                                {
                                    sepeteEklenenUrun = item2.Ad;
                                    sepeteEklenenUrunTuru = item2.Tur;
                                    sepeteEklenmisUrunAdedi = item2.Adet;
                                    if (item.Adet < (item2.Adet + numKacTane.Value))
                                    {
                                        MessageBox.Show("Eklemek istediğiniz ürün adedi yetersizdir.");
                                        break;
                                    }
                                }
                            }
                        }

                        foreach (UrunTanimi item3 in sk.Urun.UrunSepetiListe)
                        {
                            if ((String.Equals(item.Ad, item3.Ad)) && (String.Equals(item.Tur, item3.Tur)))
                            {
                                sepeteEklemekIcinDongu = true;
                                int sepettekiUrunAdedi = item3.Adet;
                                if (item.Adet < (sepettekiUrunAdedi + Convert.ToInt32(numKacTane.Value)))
                                {
                                    break;
                                }
                                else
                                {
                                    sk.SepettenUrunCikar(item3);

                                    item3.Kod = item.Kod;
                                    item3.Katalog = item.Katalog;
                                    item3.AltKatalog = item.AltKatalog;
                                    item3.Ad = item.Ad;
                                    item3.Tur = item.Tur;
                                    item3.Adet = sepettekiUrunAdedi + Convert.ToInt32(numKacTane.Value);
                                    item3.Agirlik = item.Agirlik;
                                    item3.Fiyat = item.Fiyat;
                                    item3.Tanim = item.Tanim;
                                    sk.SepeteUrunEkle(item3);
                                    
                                    lblSepeteBasariylaEklenmisUrun.Text = "Ürün Adı: " + item3.Ad + Environment.NewLine +
                                                                          "Ürün Türü: " + item3.Tur + Environment.NewLine +
                                                                          "Ürün Adedi: " + item3.Adet + Environment.NewLine +
                                                                          "Ürün Fiyatı: " + item3.Fiyat + " TL";
                                    MessageBox.Show("Ürün sepete başarıyla eklendi.");
                                    break;
                                }
                            }
                        }

                        if (sepeteEklemekIcinDongu == false)
                        {
                            if (item.Adet < Convert.ToInt32(numKacTane.Value))
                            {
                                MessageBox.Show("Eklemek istediğiniz kadar stoklarda yeterli ürün yoktur.");
                                break;
                            }
                            else
                            {
                                sepeteUrunEkle.Kod = item.Kod;
                                sepeteUrunEkle.Katalog = item.Katalog;
                                sepeteUrunEkle.AltKatalog = item.AltKatalog;
                                sepeteUrunEkle.Ad = item.Ad;
                                sepeteUrunEkle.Tur = item.Tur;
                                sepeteUrunEkle.Adet = Convert.ToInt32(numKacTane.Value);
                                sepeteUrunEkle.Agirlik = item.Agirlik;
                                sepeteUrunEkle.Fiyat = item.Fiyat;
                                sepeteUrunEkle.Tanim = item.Tanim;
                                sk.SepeteUrunEkle(sepeteUrunEkle);
                                
                                lblSepeteBasariylaEklenmisUrun.Text = "Ürün Adı: " + sepeteUrunEkle.Ad + Environment.NewLine +
                                                                      "Ürün Türü: " + sepeteUrunEkle.Tur + Environment.NewLine +
                                                                      "Ürün Adedi: " + sepeteUrunEkle.Adet + Environment.NewLine +
                                                                      "Ürün Fiyatı: " + sepeteUrunEkle.Fiyat + " TL";
                                MessageBox.Show("Ürün sepete başarıyla eklendi.");
                                break;
                            }
                        }
                    }
                }
            }

            if (SepeteEklenecekUrun == "")
                MessageBox.Show("Sepete eklemek istediğiniz ürün stoklarda bulunmamaktadır.");
            else if (SepeteEklenecekUrunTuru == "")
                MessageBox.Show("Sepete eklemek istediğiniz ürünün bu türü stoklarda bulunmamaktadır.");
        }

        private void btnSepettekiUrunuGuncelle_Click(object sender, EventArgs e)
        {
            lvSepettekiUrun.Clear(); 
            lvSepettekiUrun.View = View.Details;
            lvSepettekiUrun.FullRowSelect = true; 
            ListViewSepet(lvSepettekiUrun); 
            foreach (UrunTanimi item in sk.Urun.UrunSepetiListe)
            {
                string[] row = { item.Ad.ToString(), item.Tur.ToString(), item.Adet.ToString() };
                
                ListViewItem veriler = new ListViewItem(row);
                lvSepettekiUrun.Items.Add(veriler);
            }
        }

        bool sepettekiUrunCikarildiMi = false;

        private void btnSepettekiUrunuSil_Click(object sender, EventArgs e)
        {
            string urunAdi = lvSepettekiUrun.SelectedItems[0].SubItems[0].Text;
            string urunTuru = lvSepettekiUrun.SelectedItems[0].SubItems[1].Text;
            int index = 0;
            foreach (UrunTanimi item in sk.Urun.UrunSepetiListe)
            {
                if (item.Ad == urunAdi)
                {
                    if (item.Tur == urunTuru)
                    {
                        sk.Urun.UrunSepetiListe.RemoveAt(index);
                        sepettekiUrunCikarildiMi = true;
                    }
                }

                index++;

                if(sepettekiUrunCikarildiMi == true)
                    break;
            }
        }

        decimal odenecekTutar = 0;
        int alinacakUrunAdedi = 0;

        private void btnTutarHesapla_Click(object sender, EventArgs e)
        {
            decimal kasayaGidecekTutar = 0;
            int kasayaGidecekUrunAdedi = sk.Urun.UrunSepetiListe.Count;

            foreach (UrunTanimi item in sk.Urun.UrunSepetiListe)
            {
                kasayaGidecekTutar += s.TutarHesapla(item.Adet, item.Fiyat);
            }

            MessageBox.Show("Sepetteki ürünlerin toplam tutarı " + kasayaGidecekTutar.ToString() + " TL'dir.");

            odenecekTutar = kasayaGidecekTutar;
            alinacakUrunAdedi = kasayaGidecekUrunAdedi;
        }

        int yapilanKacinciSatis = 0;

        private void btnSatinAlmaIsleminiGerceklestir_Click(object sender, EventArgs e)
        {
            sk.Urun.AnlikSatisListe.Clear();

            Musteri mu = new Musteri(yapilanKacinciSatis + 1, txtMusteriAd.Text, txtMusteriSoyad.Text, txtMusteriTCKimlikNo.Text, txtMusteriTelefon.Text, txtMusteriAdres.Text, alinacakUrunAdedi, odenecekTutar, odemeTuru);
            m.MusteriEkle(mu);

            hd.ToplamHasilatHesapla(odenecekTutar);

            s.Tarih = Convert.ToDateTime(dtpSatisTarihi.Value.ToShortDateString());

            DialogResult sonuc = MessageBox.Show("Sepetteki ürünler satın alınacaktır. Onaylıyor musunuz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (sonuc == DialogResult.Yes)
            {
                foreach (UrunTanimi item in d.Urun.UrunListe)
                {
                    foreach (UrunTanimi item2 in sk.Urun.UrunSepetiListe)
                    {
                        sk.AnlikSatisGoster(item2);
                        s.SatilanUrunuEkle(item2);
                        sk.SepettenUrunCikar(item2);
                        item.Adet -= item2.Adet;
                        break;
                    }
                    if (item.Adet == 0)
                        d.UrunSil(item);
                    if (sk.Urun.UrunSepetiListe.Count == 0)
                        break;
                }

                yapilanKacinciSatis++;
                t.SatisNo = yapilanKacinciSatis;

                if (girisyapanKasiyer == "Bahadır Karaağaç")
                    t.SeriNo = 1;
                else if (girisyapanKasiyer == "Aylin Sarpkaya")
                    t.SeriNo = 2;
                else if (girisyapanKasiyer == "Mete Işıkara")
                    t.SeriNo = 3;
                else if (girisyapanKasiyer == "Dolunay Tellioğlu")
                    t.SeriNo = 4;

                d.TerminalBilgiEkle(t);

                lblSatisBilgisi.Text = "Satış Yapılan Kasa: " + t.SeriNo + Environment.NewLine +
                                       "Kasada Yapılan Kaçıncı Satış: " + t.SatisNo + Environment.NewLine +
                                       "Satış Yapılan Tarih: " + s.Tarih.ToShortDateString();
            }
        }

        private void btnSatinAlinanlariGoruntule_Click(object sender, EventArgs e)
        {
            lvSatilanUrun.Clear();
            lvSatilanUrun.View = View.Details;
            lvSatilanUrun.FullRowSelect = true;
            ListViewSatilan(lvSatilanUrun);
            foreach (UrunTanimi item in sk.Urun.AnlikSatisListe)
            {
                string[] row = { item.Ad.ToString(), item.Tur.ToString(), item.Adet.ToString() };
                
                ListViewItem veriler = new ListViewItem(row);
                lvSatilanUrun.Items.Add(veriler);
            }
        }

        private void btnAlisverisYapanMusterilerinListesi_Click(object sender, EventArgs e)
        {

            lvAlisverisYapanMusterilerinBilgileri.Clear();
            lvAlisverisYapanMusterilerinBilgileri.View = View.Details; 
            lvAlisverisYapanMusterilerinBilgileri.FullRowSelect = true;
            ListViewMusteri(lvAlisverisYapanMusterilerinBilgileri);
            foreach (Musteri item in m.MusteriListe)
            {
                string[] row = { item.KacinciMusteri.ToString(), item.Ad.ToString(), item.Soyad.ToString(), item.AldigiUrunMiktari.ToString(), item.OdedigiUcret.ToString() + " TL", item.OdemeTuru.ToString() };
                
                ListViewItem veriler = new ListViewItem(row);
                lvAlisverisYapanMusterilerinBilgileri.Items.Add(veriler);
            }
        }

        private void btnToplamHasilat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İşletmenin toplam hasılatı " + hd.ToplamHasilat.ToString() + " TL'dir.");
        }

        /*private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {

        }*/

        string odemeTuru = "";

        private void btnOdemeBilgisi_Click(object sender, EventArgs e)
        {
            Nakit n = new Nakit();
            KrediKarti kr = new KrediKarti();
            MarketKarti mar = new MarketKarti();

            n.ToplamTutar = kr.ToplamTutar = mar.ToplamTutar = odenecekTutar;

            if (rbNakit.Checked == true)
            {
                odemeTuru = "Nakit";
                n.Ode();
                MessageBox.Show("Nakit olarak ödeyeceğiniz tutar " + n.OdemeTutari.ToString() + " TL olacaktır.");
            }
            else if (rbKrediKarti.Checked == true)
            {
                odemeTuru = "Kredi Kartı";
                if (odenecekTutar >= 100 && odenecekTutar < 200)
                {
                    if (cbKrediKarti.SelectedIndex == 0)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 1)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 2)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 3)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                }

                else if (odenecekTutar >= 200 & odenecekTutar < 300)
                {
                    if (cbKrediKarti.SelectedIndex == 0)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 1)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 2)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 3)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                }

                else if (odenecekTutar >= 300)
                {
                    if (cbKrediKarti.SelectedIndex == 0)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 2)
                        {
                            kr.TaksitSayisi = 9;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 1)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 2)
                        {
                            kr.TaksitSayisi = 9;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 2)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 2)
                        {
                            kr.TaksitSayisi = 9;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                    else if (cbKrediKarti.SelectedIndex == 3)
                    {
                        if (cbTaksitSayisi.SelectedIndex == 0)
                        {
                            kr.TaksitSayisi = 3;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 1)
                        {
                            kr.TaksitSayisi = 6;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                        else if (cbTaksitSayisi.SelectedIndex == 2)
                        {
                            kr.TaksitSayisi = 9;
                            kr.Ode();
                            MessageBox.Show("Aylık ödenecek olan tutar " + kr.OdemeTutari.ToString() + " TL olacaktır.\nTaksit sayısı: " + kr.TaksitSayisi.ToString());
                        }
                    }
                }
                
                else
                {
                    MessageBox.Show("100 TL altı alışverişlerde taksit ödemesi sağlanmamaktadır.");
                }
            }
            else if (rbMarketKarti.Checked == true)
            {
                odemeTuru = "Market Kartı";
                mar.Ode();
                if (mar.ToplamTutar >= 10)
                {
                    MessageBox.Show("Nakit olarak ödeyeceğiniz tutar " + mar.ToplamTutar.ToString() + " TL olacaktır." +
                                    Environment.NewLine + "Yaptığınız market kartı alışverişinden dolayı " + Convert.ToInt32(mar.BonusPuan).ToString() + " TL puan kazandınız.");
                }
            }
        }

        private void cbKrediKarti_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbTaksitSayisi.ResetText();
            cbTaksitSayisi.Items.Clear();
            if (cbKrediKarti.SelectedIndex == 0)
            {
                cbTaksitSayisi.Items.Add("3 Taksit");
            }
            else if (cbKrediKarti.SelectedIndex == 1)
            {
                cbTaksitSayisi.Items.Add("3 Taksit");
                cbTaksitSayisi.Items.Add("6 Taksit");
            }
            else if (cbKrediKarti.SelectedIndex == 2)
            {
                cbTaksitSayisi.Items.Add("3 Taksit");
                cbTaksitSayisi.Items.Add("6 Taksit");
            }
            else if (cbKrediKarti.SelectedIndex == 3)
            {
                cbTaksitSayisi.Items.Add("3 Taksit");
                cbTaksitSayisi.Items.Add("6 Taksit");
                cbTaksitSayisi.Items.Add("9 Taksit");
            }
        }

        private void rbNakit_CheckedChanged(object sender, EventArgs e)
        {
            cbKrediKarti.Visible = false;
            cbTaksitSayisi.Visible = false;
        }

        private void rbKrediKarti_CheckedChanged(object sender, EventArgs e)
        {
            cbKrediKarti.Visible = true;
            cbTaksitSayisi.Visible = true;
        }

        private void rbMarketKarti_CheckedChanged(object sender, EventArgs e)
        {
            cbKrediKarti.Visible = false;
            cbTaksitSayisi.Visible = false;
        }
    }
}
