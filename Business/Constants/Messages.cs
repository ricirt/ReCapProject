using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string İmageCountInvalid = "Arabaların resim sayısı 5 ten fazla olamaz.";
        public static string CarAdded = "Araba eklendi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string CarIsStillRented = "Araba sahibinden geri dönmedi";

        public static string CarUpdated = "Araba bilgileri Güncellendi";
        public static string CarDeleted = "Araba Silindi";
        public static string BrandUpdated = "Marka bilgileri güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandAdded = "Marka Eklendi";
        public static string ColorUpdated = "Renk bilgileri güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string CarInvalid = "Araba eklenemedi";
        public static string StartsWithF = "Araba isimleri F harfiyle başlamalı";
        public static string CarImageAdded="Araba resmi eklendi";
        public static string CarImageInvalid = "Araba  resmi eklenemedi";
        public static string CarImageCouldntDelete;
        public static string CarImageDeleted;
        public static string CarImagesCouldntListed;
        public static string CarImagesCouldntGet;
        public static string CarImageUpdated;
        public static string CarImageCouldntUpdated;
        public static string ImagesNotFound = "Resim bulunamadı";
    }
}
