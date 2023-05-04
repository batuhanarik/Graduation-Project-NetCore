using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string WeddingPlaceDeleted = "Wedding Place Deleted";
        public static string WeddingPlaceAdded = "Mekan başarıyla eklendi.";
        public static string WeddingPlaceInvalid = "Wedding Place Invalid";
        public static string WeddingPlaceCapacityLess300 = "The wedding venue capacity should not be less than 300.";

        public static string WeddingPlacesListed = "Wedding places listed.";
        public static string WeddingPlacesListedByCity = "Wedding places listed by city.";

        public static string GetAllWeddingPlacesByCategory = "Get All Wedding Places By Category.";
        public static string CategoryAdded="Category Added";
        public static string CategoriesListed="All categories listed";
        public static string UserAdded="Başarıyla kayıt oldunuz.";
        public static string UsersListed="All users Listed";
        public static string WeddingPlaceNameAlreadyExists="Wedding Place Name Already Exists";

        public static string AuthorizationDenied = "Authorization Denied.";
        public static string UserRegistered="Kayıt Olundu!";
        public static string UserNotFound ="Böyle bir kullanıcı bulunmuyor.";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="Kullınıcı zaten mevcut!";
        public static string AccessTokenCreated="Access Token Created";
        public static string CarImageLimitExceeded = "Resim yükleme limiti aşıldı";
        public static string WeddingPlaceImageAdded="Resimler Eklendi";
        public static string WeddingPlaceImageUpdated="Mekan resimleri başarıyla güncellendi.";
        public static string PasswordUpdated = "Şifreniz başarıyla güncellendi.";
        public static string CustomerAdded="Müşteri başarıyla eklendi.";
        public static string CustomerDeleted="Müşteri Silindi";
        public static string InformationUpdated="Bilgiler Güncellendi.";
        public static string UserDoesntExists;
        public static string WeddingPlaceImageDeleted="Resim Silindi.";
        public static string WeddingPlaceUpdate="Düğün Yeri Güncellendi.";
    }
}
