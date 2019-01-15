using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PostaGonder();

            Console.ReadKey();
        }
        static void PostaGonder()
        {
            //değişkenler
            string userName = "demo";
            string password = "demo";

            string postaAciklama = "Örnek Posta Açklaması";
            string gonderimTarih = "";//yyyy-mm-dd örnek 2018-12-07

            List<Alici> alicilar = new List<Alici>();

            var alici1 = new Alici
            {
                KurumAdUnvan = "Belediye Başkanı",
                Hitap = "Sayın",
                AdSoyad = "Ali Örnek",
                AcikAdres = "Örnek Mahallesi Okul Sokak No:3/45 Çankaya Ankara TÜRKİYE",
                SiteBlokDaireNoAd = "",
                SokakAd = "Okul Sokak",
                MahalleAd = "Örnek Mahallesi",
                SemtAd = "",
                IlceAd = "ÇANKAYA",
                IlAd = "ANKARA",
                UlkeAd = "TÜRKİYE",
                PostaKod = "06999",
                Telefon = "",
            };

            alici1.degiskenler.Add(new Alici.Degisken() { DegiskenAd = "Borc", DegiskenDeger = "200 TL" });
            alici1.degiskenler.Add(new Alici.Degisken() { DegiskenAd = "Alacak", DegiskenDeger = "20 TL" });

            alicilar.Add(alici1);

            var alici2 = new Alici
            {
                KurumAdUnvan = "Muhtar",
                Hitap = "Sayın",
                AdSoyad = "Ayşe Örnek",
                AcikAdres = "Örnek Mahallesi Okul Sokak No:5/45 Çankaya Ankara TÜRKİYE",
                SiteBlokDaireNoAd = "",
                SokakAd = "Okul Sokak",
                MahalleAd = "Örnek Mahallesi",
                SemtAd = "",
                IlceAd = "ÇANKAYA",
                IlAd = "ANKARA",
                UlkeAd = "TÜRKİYE",
                PostaKod = "06999",
                Telefon = ""
            };

            alici2.degiskenler.Add(new Alici.Degisken() { DegiskenAd = "Borc", DegiskenDeger = "300 TL" });
            alici2.degiskenler.Add(new Alici.Degisken() { DegiskenAd = "Alacak", DegiskenDeger = "50 TL" });

            alicilar.Add(alici2);


            var tercihler = new Tercihler();
            var sablon = new Sablon();

            string html = "Örnek Posta İçeriği";
            string zarfBaski = "";


            string postData = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            postData += "<PostaSepeti>";
            postData += "   <Credential>";
            postData += "       <UserName>" + userName + "</UserName>";
            postData += "       <Password>" + password + "</Password>";
            postData += "   </Credential>";

            postData += "   <PostaAciklama><![CDATA[" + postaAciklama + "]]></PostaAciklama>";
            postData += "   <GonderimTarih>" + gonderimTarih + "</GonderimTarih>";

            postData += "   <Alicilar>";
            foreach (var alici in alicilar)
            {
                postData += "       <Alici>";
                postData += "           <KurumAdUnvan>" + alici.KurumAdUnvan + "</KurumAdUnvan>";
                postData += "           <Hitap>" + alici.Hitap + "</Hitap>";
                postData += "           <AdSoyad>" + alici.AdSoyad + "</AdSoyad>";
                postData += "           <AcikAdres><![CDATA[" + alici.AcikAdres + "]]></AcikAdres>";
                postData += "           <SiteBlokDaireNoAd>" + alici.SiteBlokDaireNoAd + "</SiteBlokDaireNoAd>";
                postData += "           <SokakAd>" + alici.SokakAd + "</SokakAd>";
                postData += "           <MahalleAd>" + alici.MahalleAd + "</MahalleAd>";
                postData += "           <SemtAd>" + alici.SemtAd + "</SemtAd>";
                postData += "           <IlceAd>" + alici.IlceAd + "</IlceAd>";
                postData += "           <IlAd>" + alici.IlAd + "</IlAd>";
                postData += "           <UlkeAd>" + alici.UlkeAd + "</UlkeAd>";
                postData += "           <PostaKod>" + alici.PostaKod + "</PostaKod>";
                postData += "           <Telefon>" + alici.Telefon + "</Telefon>";

                postData += "           <Degiskenler>";
                foreach (var degisken in alici.degiskenler)
                {
                    postData += "               <Degisken>";
                    postData += "                   <DegiskenAd>" + degisken.DegiskenAd + "</DegiskenAd>";
                    postData += "                   <DegiskenDeger>" + degisken.DegiskenDeger + "</DegiskenDeger>";
                    postData += "               </Degisken>";
                }//foreach degisken
                postData += "           </Degiskenler>";
                postData += "       </Alici>";
            }//foreach alici
            postData += "   </Alicilar>";
            postData += "   <Tercihler>";
            postData += "       <GonderiTipId>" + tercihler.GonderiTipId + "</GonderiTipId>";
            postData += "       <KagitTurId>" + tercihler.KagitTurId + "</KagitTurId>";
            postData += "       <KagitEbatId>" + tercihler.KagitEbatId + "</KagitEbatId>";
            postData += "       <KagitYonlendirmeId>" + tercihler.KagitYonlendirmeId + "</KagitYonlendirmeId>";
            postData += "       <KagitGramId>" + tercihler.KagitGramId + "</KagitGramId>";
            postData += "       <Renkli>" + tercihler.Renkli + "</Renkli>";
            postData += "       <Dublex>" + tercihler.Dublex + "</Dublex>";
            postData += "       <Penceresiz>" + tercihler.Penceresiz + "</Penceresiz>";
            postData += "       <Baskili>" + tercihler.Baskili + "</Baskili>";
            postData += "       <BaskiliZarfTip>" + tercihler.BaskiliZarfTip + "</BaskiliZarfTip>";
            postData += "       <Iadeli>" + tercihler.Iadeli + "</Iadeli>";
            postData += "       <Spiral>" + tercihler.Spiral + "</Spiral>";
            postData += "       <Delme>" + tercihler.Delme + "</Delme>";
            postData += "       <Zimba>" + tercihler.Zimba + "</Zimba>";
            postData += "       <Ciltleme>" + tercihler.Ciltleme + "</Ciltleme>";
            postData += "   </Tercihler>";
            postData += "   <Icerik>";
            postData += "       <Html><![CDATA[" + html + "]]></Html>";
            postData += "       <Sablon>";
            postData += "           <Id>" + sablon.Id + "</Id>";
            postData += "           <Ad>" + sablon.Ad + "</Ad>";
            postData += "           <kagitEbatId>" + sablon.kagitEbatId + "</kagitEbatId>";
            postData += "           <dosya>" + sablon.dosya + "</dosya>";
            postData += "           <yerlesimId>" + sablon.yerlesimId + "</yerlesimId>";
            postData += "           <yerlesimAd>" + sablon.yerlesimAd + "</yerlesimAd>";
            postData += "           <kucultmeId>" + sablon.kucultmeId + "</kucultmeId>";
            postData += "           <kucultmeAd>" + sablon.kucultmeAd + "</kucultmeAd>";
            postData += "           <sagBosluk>" + sablon.sagBosluk + "</sagBosluk>";
            postData += "           <solBosluk>" + sablon.solBosluk + "</solBosluk>";
            postData += "           <ustBosluk>" + sablon.ustBosluk + "</ustBosluk>";
            postData += "           <altBosluk>" + sablon.altBosluk + "</altBosluk>";
            postData += "       </Sablon>";
            postData += "   </Icerik>";
            postData += "   <ZarfBaski>" + zarfBaski + "</ZarfBaski>";
            postData += "</PostaSepeti>";

            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "text/xml; charset=UTF-8";
            string response = wc.UploadString("https://postasepeti.com/Services/PostaGonder", "POST", postData);
            Console.WriteLine(response);
        }




        public class Alici
        {
            public Alici()
            {
                degiskenler = new List<Degisken>();
            }

            public List<Degisken> degiskenler;
            public string KurumAdUnvan = "";
            public string Hitap = "";
            public string AdSoyad = "";
            public string AcikAdres = "";
            public string SiteBlokDaireNoAd = "";
            public string SokakAd = "";
            public string MahalleAd = "";
            public string SemtAd = "";
            public string IlceAd = "";
            public string IlAd = "";
            public string UlkeAd = "";
            public string PostaKod = "";
            public string Telefon = "";

            public class Degisken
            {
                public string DegiskenAd;
                public string DegiskenDeger;
            }

        }

        public class Sablon
        {
            public int Id;
            public string Ad;
            public int kagitEbatId = 2;
            public string dosya;
            public int yerlesimId = 0;
            public string yerlesimAd;
            public int kucultmeId = 0;
            public string kucultmeAd;
            public int sagBosluk = 50;
            public int solBosluk = 50;
            public int ustBosluk = 300;
            public int altBosluk = 50;
        }
        public class Tercihler
        {

            public int GonderiTipId = 1;
            public int KagitTurId = 1;
            public int KagitEbatId = 2;
            public int KagitYonlendirmeId = 1;
            public int KagitGramId = 3;
            public bool Renkli = true;
            public bool Dublex = false;
            public bool Penceresiz = false;
            public bool Baskili = false;
            public string BaskiliZarfTip = "Siyah Beyaz Baskılı Zarf";
            public bool Iadeli = false;
            public bool Spiral = false;
            public bool Delme = false;
            public bool Zimba = false;
            public bool Ciltleme = false;
        }
    }
}
