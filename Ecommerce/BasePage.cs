using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Resources
{
    public abstract class BasePage<TModel> : RazorPage<TModel>
    {
        private Dictionary<string, string> LangTR = new Dictionary<string, string>
        {
            { "Users", "Kullanıcılar" },
            { "SignIn", "Giriş Yap"},
            { "SelectLanguage", "Dil Seçiniz"},
            { "Continuereading", "Okumaya Devam Et"},
            { "Category", "Kategori"},
            { "Pleasesignin", "Lütfen Giriş Yapın"},
            { "Password", "Şifre"},
            { "SignUp", "Kayıt Ol"},
            { "SignOut", "Çıkış Yap"},
            { "Electronic"," Elektronik"},
            { "Health","Sağlık" },
            { "Clothes","Giyim" },
            {"AddCompare" ,"Karşılaştır"},
            {"AddWishList", "Favorilere Ekle"},
            {"AddCart", "Sepete Ekle" },
            {"NewProducts","Yeni Ürünler" }

        };
        private Dictionary<string, string> LangEn = new Dictionary<string, string>
        {
            { "Users", "Users" },
            { "SignIn", "Sign In"},
            { "SelectLanguage", "Dil Seçiniz"},
            { "Continuereading", "Continue Reading"},
            { "Category", "Category"},
            { "Pleasesignin", "Please sign in"},
            { "Password", "Password"},
            { "SignUp", "Sign Up"},
            { "SignOut", "Sign Out"},
            { "Electronic"," Electronic"},
            { "Health" , "Health" },
            { "Clothes","Clothes" },
            {"AddCompare" ,"Add to Compare"},
            {"AddWishList","Add to Favorites" },
            {"AddCart","Add to Cart" },
            {"NewProducts","New Products" }
        };

        public string Lang(string Key)
        {
            IRequestCultureFeature requestCulture = Context.Request.HttpContext.Features.Get<IRequestCultureFeature>();
            string Lang = Context.Request.Cookies["Lang"];
            if (string.IsNullOrEmpty(Lang))
            {
                if (requestCulture.RequestCulture.Culture.Name == "tr-TR")
                    return LangTR[Key];
                else if (requestCulture.RequestCulture.Culture.Name == "en-US")
                    return LangEn[Key];
            }
            else
            {
                if (Lang == "TR")
                    return LangTR[Key];
                else if (Lang == "EN")
                    return LangEn[Key];
            }
            return Key;
        }

        protected BasePage()
        {
        }
    }
}
