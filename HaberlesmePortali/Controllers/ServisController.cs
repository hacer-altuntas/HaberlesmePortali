using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HaberlesmePortali.Models;
using HaberlesmePortali.ViewModels;

namespace HaberlesmePortali.Controllers
{
    public class ServisController : ApiController
    {
        DBEntities db = new DBEntities();
        SonucModel sonuc = new SonucModel();

        #region Kullanici

        [HttpGet]
        [Route("api/KullaniciListe")]
        public List<KullaniciModel> KullaniciListe()
        {
            List<KullaniciModel> liste = db.Kullanici.Select(x => new KullaniciModel()
            {
                KullaniciId = x.KullaniciId,
                KullaniciAdi = x.KullaniciAdi,
                Resim = x.Resim,
                Numara = x.Numara,
                Durum = x.Durum,
                KayitTarihi = x.KayitTarihi
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/kullaniciById/{KullaniciId}")]
        public KullaniciModel KullaniciById(int KullaniciId)
        {
            KullaniciModel kayit = db.Kullanici.Where(s => s.KullaniciId == KullaniciId).Select(x => new KullaniciModel()
            {
                KullaniciId = x.KullaniciId,
                KullaniciAdi = x.KullaniciAdi,
                Resim = x.Resim,
                Numara = x.Numara,
                Durum = x.Durum,
                KayitTarihi = x.KayitTarihi,
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/KullaniciEkle")]
        public SonucModel KullaniciEkle(KullaniciModel model)
        {
            if (db.Kullanici.Count(s => s.Numara == model.Numara) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Numara Kayıtlıdır!";
                return sonuc;
            }
            Kullanici yeni = new Kullanici();
            yeni.KullaniciAdi = model.KullaniciAdi;
            yeni.Resim = model.Resim;
            yeni.Numara = model.Numara;
            yeni.Durum = model.Durum;
            yeni.KayitTarihi = model.KayitTarihi;
            db.Kullanici.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanici Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/KullaniciDuzenle")]
        public SonucModel KullaniciDuzenle(KullaniciModel model)
        {
            Kullanici kayit = db.Kullanici.Where(s => s.KullaniciId == model.KullaniciId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }
            kayit.KullaniciAdi = model.KullaniciAdi;
            kayit.Resim = model.Resim;
            kayit.Numara = model.Numara;
            kayit.Durum = model.Durum;
            kayit.KayitTarihi = model.KayitTarihi;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanici Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/KullaniciSil/{KullaniciId}")]
        public SonucModel KullaniciSil(int KullaniciId)
        {
            Kullanici kayit = db.Kullanici.Where(s => s.KullaniciId == KullaniciId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }
            db.Kullanici.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanici Silindi";
            return sonuc;
        }

        #endregion

        #region Mesaj

        [HttpGet]
        [Route("api/Mesajliste")]
        public List<MesajModel> MesajListe()
        {
            List<MesajModel> liste = db.Mesaj.Select(x => new MesajModel()
            {
                MesajId = x.MesajId,
                İcerik = x.İcerik,
                GonderenId = x.GonderenId,
                GrupId = x.GrupId,
                Tarih = x.Tarih,
                Okunma = x.Okunma

            }).ToList();
            foreach (var Mesaj in liste)
            {
                Mesaj.AliciBilgi = aliciBymesajId(Mesaj.MesajId);
            }
            return liste;
        }
        [HttpGet]
        [Route("api/MesajListeById/{mesajId}")]
        public List<MesajModel> MesajListeById(int MesajId)
        {
            List<MesajModel> liste = db.Mesaj.Where(s => s.MesajId == MesajId).Select(x =>
           new MesajModel()
           {
               MesajId = x.MesajId,
               İcerik = x.İcerik,
               GonderenId = x.GonderenId,
               GrupId = x.GrupId,
               Tarih = x.Tarih,
               Okunma = x.Okunma
           }).ToList();
            foreach (var Mesaj in liste)
            {
                Mesaj.AliciBilgi = aliciBymesajId(Mesaj.MesajId);
            }
            return liste;
        }
        [HttpGet]
        [Route("api/MesajListeByGonderenId/{GonderenId}")]
        public List<MesajModel> MesajListeByGonderenId(int GonderenId)
        {
            List<MesajModel> liste = db.Mesaj.Where(s => s.GonderenId == GonderenId).Select(x =>
           new MesajModel()
           {
               MesajId = x.MesajId,
               İcerik = x.İcerik,
               GonderenId = x.GonderenId,
               GrupId = x.GrupId,
               Tarih = x.Tarih,
               Okunma = x.Okunma
           }).ToList();
            foreach (var Mesaj in liste)
            {
                Mesaj.AliciBilgi = aliciBymesajId(Mesaj.MesajId);
            }
            return liste;
        }

        [HttpGet]
        [Route("api/MesajListeByGrupId/{grupId}")]
        public List<MesajModel> MesajListeByGrupId(int GrupId)
        {
            List<MesajModel> liste = db.Mesaj.Where(s => s.GrupId == GrupId).Select(x =>
           new MesajModel()
           {
               MesajId = x.MesajId,
               İcerik = x.İcerik,
               GonderenId = x.GonderenId,
               GrupId = x.GrupId,
               Tarih = x.Tarih,
               Okunma = x.Okunma
           }).ToList();
            return liste;
        }
        
        [HttpPost]
        [Route("api/MesajYaz")]
        public SonucModel MesajYaz(MesajModel model)
        {

            Mesaj yeni = new Mesaj();
            yeni.İcerik = model.İcerik;
            yeni.GonderenId = model.GonderenId;
            yeni.GrupId = model.GrupId;
            yeni.Tarih = model.Tarih;
            yeni.Okunma = model.Okunma;

            db.Mesaj.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Mesaj Gönderildi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/MesajDuzenle")]
        public SonucModel MesajDuzenle(MesajModel model)
        {
            Mesaj kayit = db.Mesaj.Where(s => s.MesajId == model.MesajId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.İcerik = model.İcerik;
            kayit.GonderenId = model.GonderenId;
            kayit.GrupId = model.GrupId;
            kayit.Tarih = model.Tarih;
            kayit.Okunma = model.Okunma;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Mesaj Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/MesajSil/{MesajId}")]
        public SonucModel MesajSil(int MesajId)
        {
            Mesaj kayit = db.Mesaj.Where(s => s.MesajId == MesajId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Mesaj.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Mesaj Silindi";
            return sonuc;
        }

        #endregion

        #region Alicilar

        [HttpGet]
        [Route("api/AliciListe")]
        public List<AlicilarModel> AliciListe()
        {
            List<AlicilarModel> liste = db.Alicilar.Select(x => new AlicilarModel()
            {
                AliciId = x.AliciId,
                KullaniciId = x.KullaniciId,
                MesajId = x.MesajId

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/AliciByAliciId/{AliciId}")]
        public List<AlicilarModel> AlicilarListeById(int AliciId)
        {
            List<AlicilarModel> liste = db.Alicilar.Where(s => s.AliciId == AliciId).Select(x =>
           new AlicilarModel()
           {
               AliciId = x.AliciId,
               KullaniciId = x.KullaniciId,
               MesajId = x.MesajId
           }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/AliciListeByKullaniciId/{KullaniciId}")]
        public List<AlicilarModel> AliciListeByKullaniciId(int KullaniciId)
        {
            List<AlicilarModel> liste = db.Alicilar.Where(s => s.KullaniciId == KullaniciId).Select(x =>
           new AlicilarModel()
           {
               AliciId = x.AliciId,
               KullaniciId = x.KullaniciId,
               MesajId = x.MesajId
           }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/AliciByMesajId/{MesajId}")]
        public List<AlicilarModel> aliciBymesajId(int MesajId)
        {
            List<AlicilarModel> kayit = db.Alicilar.Where(s => s.MesajId == MesajId).Select(x => new AlicilarModel()
            {
                AliciId = x.AliciId,
                KullaniciId = x.KullaniciId,
                MesajId = x.MesajId
            }).ToList();
            return kayit;
        }

        [HttpPost]
        [Route("api/AliciEkle")]
        public SonucModel AliciEkle(AlicilarModel model)
        {

            Alicilar yeni = new Alicilar();
            yeni.KullaniciId = model.KullaniciId;
            yeni.MesajId = model.MesajId;

            db.Alicilar.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Alıcı Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/AliciDuzenle")]
        public SonucModel AliciDuzenle(AlicilarModel model)
        {
            Alicilar kayit = db.Alicilar.Where(s => s.AliciId == model.AliciId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.KullaniciId = model.KullaniciId;
            kayit.MesajId = model.MesajId;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Alıcı Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/AliciSil/{AliciId}")]
        public SonucModel AliciSil(int AliciId)
        {
            Alicilar kayit = db.Alicilar.Where(s => s.AliciId == AliciId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            db.Alicilar.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Alıcı Silindi";
            return sonuc;
        }
       
        #endregion

        #region Grup

        [HttpGet]
        [Route("api/GrupListe")]
        public List<GrupModel> GrupListe()
        {
            List<GrupModel> liste = db.Grup.Select(x => new GrupModel()
            {
                GrupId = x.GrupId,
                GrupAdi = x.GrupAdi,
                Hakkinda = x.Hakkinda,
                GrupResim = x.GrupResim

            }).ToList();
            foreach (var Grup in liste)
            {
                Grup.UyeBilgi = uyeBygrupId(Grup.GrupId);
            }
            return liste;
        }
        [HttpGet]
        [Route("api/GrupById/{GrupId}")]
        public List<GrupModel> GrupByGrupId(int GrupId)
        {
            List<GrupModel> kayit = db.Grup.Where(s => s.GrupId == GrupId).Select(x => new GrupModel()
            {
                GrupId = x.GrupId,
                GrupAdi = x.GrupAdi,
                Hakkinda = x.Hakkinda,
                GrupResim = x.GrupResim
            }).ToList();
            foreach (var Grup in kayit)
            {
                Grup.UyeBilgi = uyeBygrupId(Grup.GrupId);
            }
            return kayit;
        }
        [HttpPost]
        [Route("api/GrupOlustur")]
        public SonucModel GrupOlustur(GrupModel model)
        {

            Grup yeni = new Grup();
            yeni.GrupAdi = model.GrupAdi;
            yeni.Hakkinda = model.Hakkinda;
            yeni.GrupResim = model.GrupResim;

            db.Grup.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Grup Oluşturuldu";
            return sonuc;
        }
        [HttpPut]
        [Route("api/GrupDuzenle")]
        public SonucModel GrupDuzenle(GrupModel model)
        {
            Grup kayit = db.Grup.Where(s => s.GrupId == model.GrupId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.GrupAdi = model.GrupAdi;
            kayit.Hakkinda = model.Hakkinda;
            kayit.GrupResim = model.GrupResim;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/GrupSil/{GrupId}")]
        public SonucModel GrupSil(int GrupId)
        {
            Grup kayit = db.Grup.Where(s => s.GrupId == GrupId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            if (db.GrupUye.Count(s => s.GrupId == GrupId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Kullanici Kaydı Olan Grup Silinemez!";
                return sonuc;
            }
            db.Grup.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Grup Silindi";
            return sonuc;
        }
        
        #endregion

        #region Uyeler
        [HttpGet]
        [Route("api/UyeListe")]
        public List<GrupUyeModel> UyeListe()
        {
            List<GrupUyeModel> liste = db.GrupUye.Select(x => new GrupUyeModel()
            {
                UyeId = x.UyeId,
                KullaniciId = x.KullaniciId,
                GrupId = x.GrupId,
                UyeYetki = x.UyeYetki
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/UyeById/{UyeId}")]
        public List<GrupUyeModel> uyeById(int UyeId)
        {
            List<GrupUyeModel> kayit = db.GrupUye.Where(s => s.UyeId == UyeId).Select(x => new GrupUyeModel()
            {
                UyeId = x.UyeId,
                KullaniciId = x.KullaniciId,
                GrupId = x.GrupId,
                UyeYetki = x.UyeYetki
            }).ToList();
            return kayit;
        }
        [HttpGet]
        [Route("api/UyeByGrupId/{GrupId}")]
        public List<GrupUyeModel> uyeBygrupId(int GrupId)
        {
            List<GrupUyeModel> kayit = db.GrupUye.Where(s => s.GrupId == GrupId).Select(x => new GrupUyeModel()
            {
                UyeId = x.UyeId,
                KullaniciId = x.KullaniciId,
                GrupId = x.GrupId,
                UyeYetki = x.UyeYetki
            }).ToList();
            return kayit;
        }
        [HttpPost]
        [Route("api/UyeEkle")]
        public SonucModel UyeEkle(GrupUyeModel model)
        {
            GrupUye yeni = new GrupUye();
            yeni.KullaniciId = model.KullaniciId;
            yeni.GrupId = model.GrupId;
            yeni.UyeYetki = model.UyeYetki;


            db.GrupUye.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/UyeDuzenle")]
        public SonucModel UyeDuzenle(GrupUyeModel model)
        {
            GrupUye kayit = db.GrupUye.Where(s => s.UyeId == model.UyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }
            kayit.KullaniciId = model.KullaniciId;
            kayit.GrupId = model.GrupId;
            kayit.UyeYetki = model.UyeYetki;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Uye Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/UyeSil/{uyeId}")]
        public SonucModel UyeSil(int UyeId)
        {
            GrupUye kayit = db.GrupUye.Where(s => s.UyeId == UyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }
            db.GrupUye.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Uye Silindi";
            return sonuc;
        }
        
        #endregion

    }
}
