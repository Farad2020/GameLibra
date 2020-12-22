using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameLibra.Models
{
    public class ApiObject
    {
        public string GameName { get; set; }
        /*
        public float price_new { get; set; }
        public float price_old { get; set; }
        public float price_cut { get; set; }
        public string url { get; set; }
        public string shopName { get; set; }
        */
        public List<Newtonsoft.Json.Linq.JToken> shops_tokenized { get; set; }
        

        public List<ShopInfo> shop_infos { get; set; }


        public ApiObject() {

        }

        public ApiObject(Newtonsoft.Json.Linq.JObject o, string gameName) {
            GameName = gameName;

            shops_tokenized = o["data"][gameName]["list"].ToList();
            shop_infos = new List<ShopInfo>();
            for (int i = 0; i < shops_tokenized.Count; i++) {
                shop_infos.Add(new ShopInfo(o, i, gameName));
            }

            shop_infos.OrderBy(x => x.price_new).ThenBy(x => x.shopName);
            /*
            price_new = (float)o["data"][GameName]["list"][0]["price_new"];
            price_old = (float)o["data"][GameName]["list"][0]["price_old"];
            price_cut = (float)o["data"][GameName]["list"][0]["price_old"];
            url = (string)o["data"][GameName]["list"][0]["url"];
            shopName = (string)o["data"][GameName]["list"][0]["shop"]["name"];
            var ste = o["data"][gameName]["list"];
            */



        }

        public List<ShopInfo> GetTop4Offers() {
            if(shop_infos.Count() > 4)
                return shop_infos.GetRange(0, 4);
            return shop_infos;
        } 
    }

    public class ShopInfo{
        public string Currency { get; set; }

        public string GameName { get; set; }
        public float price_new { get; set; }
        public float price_old { get; set; }
        public float price_cut { get; set; }
        public string url { get; set; }
        public string shopName { get; set; }


        public ShopInfo()
        {

        }

        public ShopInfo(Newtonsoft.Json.Linq.JObject o, string gameName)
        {
            GameName = gameName;

            price_new = (float)o["data"][GameName]["list"][0]["price_new"];
            price_old = (float)o["data"][GameName]["list"][0]["price_old"];
            price_cut = (float)o["data"][GameName]["list"][0]["price_old"];
            url = (string)o["data"][GameName]["list"][0]["url"];
            shopName = (string)o["data"][GameName]["list"][0]["shop"]["name"];


        }

        public ShopInfo(Newtonsoft.Json.Linq.JObject o, int i, string gameName)
        {
            Currency = (string)o[".meta"]["currency"];
            GameName = gameName;
            price_new = (float)o["data"][GameName]["list"][i]["price_new"];
            price_old = (float)o["data"][GameName]["list"][i]["price_old"];
            price_cut = (float)o["data"][GameName]["list"][i]["price_old"];
            url = (string)o["data"][GameName]["list"][i]["url"];
            shopName = (string)o["data"][GameName]["list"][i]["shop"]["name"];
        }
    }
}