using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CategoryAdded = "Kategori Eklendi.";
        public static string CategoryDeleted = "Kategori Silindi.";
        public static string CategoryUpdated = "Kategori Güncellendi.";
        public static string CategoriesListed = "Kategoriler Listelendi.";
        public static string CategoryGeted = "Kategori Getirildi";

        public static string CustomerAdded = "Müşteri Eklendi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";
        public static string CustomerGeted = "Müşteri Getirildi.";
        public static string CustomersListed = "Müşteriler Listelendi.";
        public static string CustomerDeleted = "Müşteri Silindi.";

        public static string OrderAdded = "Sipariş Eklendi."; 
        public static string OrderDeleted = "Sipariş Silindi.";
        public static string OrdersListed = "Siparişler Listelendi.";
        public static string OrderGeted = "Sipariş Getirildi.";
        public static string OrderUpdated = "Sipariş Güncellendi.";

        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductDeleted = "Ürün Silindi.";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductGeted = "Ürün Getirildi.";
        public static string ProductUpdated = "Ürün Güncellendi.";

        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UsersListed = "Kullanıcılar Listelendi.";
        public static string UserGeted = "Kullanıcı Getirildi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Eşleşmedi";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExist = "Kullanıcı zaten var";
        public static string SuccessfulRegister = "Kayıt başarılı";

        public static string AuthorityAdded = "Yetki Eklendi.";
        public static string AuthorityDeleted = "Yetki Silindi.";
        public static string AuthoritiesListed = "Yetkiler Listelendi.";
        public static string AuthorityGeted = "Yetki Getirildi.";
        public static string AuthorityUpdated = "Yetki Güncellendi.";

        public static string UserAuthorityAdded = "Kullanıcı Yetkisi Eklendi.";
        public static string UserAuthorityDeleted = "Kullanıcı Yetkisi Silindi.";
        public static string UserAuthoritiesListed = "Kullanıcı Yetkileri Listelendi.";
        public static string UserAuthorityGeted = "Kullanıcı Yetkisi Getirildi.";
        public static string UserAuthorityUpdated = "Kullanıcı Yetkisi Güncellendi.";

        public static string SecurityQuestionAnswerNotMatch = "Güvenlik Sorusu Cevabı Eşleşmedi.";
        public static string UserOrAuthortiesAreNull = "Kullanıcı bilgileri veya Yetkiler eksik";
        public static string ProductAlreadyExist = "Böyle bir ürün zaten var";

        public static string CartUpdated = "Sepet Güncellendi.";
        public static string CartGeted = "Sepetten Getirildi.";
        public static string CartListed = "Sepet Listelendi.";
        public static string CartDeleted = "Sepetten Silindi.";
        public static string CartAdded = "Sepete Eklendi.";
    }
}
