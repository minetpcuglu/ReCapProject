using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants  //sabitler
{ 

    //Temel Mesajlar 
   public static class Messages  //Sürekli newlememek için static verdik 
    {
        public static string BrandAdded = "Marka eklendi";
        public static string CarAdded = "Araba eklendi";
        public static string CarImagesAdded = "Araba Resimleri eklendi";
        public static string ColorAdded = "Renk eklendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string RentalAdded = "Yeni Kiralama detayı eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string CarDeleted = "Araba silindi";
        public static string CarImagesDeleted = "Araba Resimleri silindi";
        public static string ColorDeleted = "Renk silindi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string RentalDeleted = "Araç kiralama detayı silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarIamgesUpdated = "Araba resimleri güncellendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string RentalUpdated = "Araç Kiralama Detayı güncellendi";
        public static string BrandsListed = "Markalar Listelendi";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarsImagesListed = "Arabalar resimleri Listelendi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string RentalsListed = "Araç kiralama detayları Listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string BrandNameInValid = "Marka ismi geçersiz";
        public static string ColorNameInValid = "Renk ismi geçersiz";
        public static string CarNameInValid = "Araba ismi geçersiz ve şartlar sağlanamamaktadır";
        public static string CustomerNameInValid = "Müşteri ismi geçersiz ve şartlar sağlanamamaktadır";
        public static string UserNameInValid = "Kullanıcı ismi geçersiz ve şartlar sağlanamamaktadır";
        public static string RentalNameInValid = "Araç detayları geçersiz";
        public static string FilterId = "Filtreleme Başarılı";
        public static string CarMaxImageLimit ="Bir arabanın maksimum 5 fotografı olmalıdır ";
        public static string ListMail="Mail göre filtreleme başarılı";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token  oluşturuldu";
    }

}
