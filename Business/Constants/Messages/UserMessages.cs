using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public class UserMessages
    {
        public static string ClaimsListed;
        public static string UserAdded = "Kullanıcı Eklendi...";
        public static string UserDeleted = "Kullanıcı Silindi...";
        public static string UserUpdated = "Kullanıcı Güncellendi...";
        public static string UserNameInValid = "Kullanıcı ismi geçersiz...";
        public static string UserListed = "Kullanıcılar Listelendi...";
        public static string EMailAdressAlreadyExists = "Bu mail adresi sistemde kayıtlıdır";
        public static string UserNotFound = "Kullanıcı bulunamadı...";
        public static string PasswordError = "Yanlış parola";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExist = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarılı ile kayıt edildi";
        public static string AccessTokenCreated = "Access Token başarı ile oluşturuldu";
        public static string AuthorizationDenied = "Yetkisiz kullanıcı";
    }
}