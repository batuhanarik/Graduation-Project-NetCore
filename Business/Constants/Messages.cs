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
        public static string WeddingPlaceAdded = "Wedding Place Added";
        public static string WeddingPlaceInvalid = "Wedding Place Invalid";
        public static string WeddingPlaceCapacityLess300 = "The wedding venue capacity should not be less than 300.";

        public static string WeddingPlacesListed = "Wedding places listed.";

        public static string GetAllWeddingPlacesByCategory = "Get All Wedding Places By Category.";
        public static string CategoryAdded="Category Added";
        public static string CategoriesListed="All categories listed";
        public static string UserAdded="User Added";
        public static string UsersListed="All users Listed";
        public static string WeddingPlaceNameAlreadyExists="Wedding Place Name Already Exists";

        public static string AuthorizationDenied = "Authorization Denied.";
        public static string UserRegistered="Kayıt Olundu!";
        public static string UserNotFound ="User Not Found";
        public static string PasswordError="Şifre Hatalı";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists="User Already Exists!";
        public static string AccessTokenCreated="Access Token Created";
        public static string CarImageLimitExceeded = "Car Image Limit Exceeded";
        public static string WeddingPlaceImageAdded="Wedding Place Image Added";
        internal static string CarImageUpdated;
    }
}
