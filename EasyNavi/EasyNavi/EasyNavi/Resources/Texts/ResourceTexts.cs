using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.Resources.Texts
{
    public static class ResourceTexts
    {
        public static string FromName(string name)
        {
            var pi = typeof(ResourceTexts).GetProperty(name);
            if (pi == null) return "no text.";
            return (string)pi.GetValue(null);
        }

        public static string Contents => "コンテンツ";
        public static string WebSites => "オフィシャルサイト";
        public static string WebSites2 => "オフィシャルサイト";
        public static string WebSites3 => "オフィシャルサイト";
        public static string Category => "カテゴリー";
        public static string CategoryGourmet => "グルメ";
        public static string CategoryLocalGourmet => "ご当地グルメ";
        public static string CategoryPresent => "おみやげ";
        public static string CategorySpecial => "みどころ";
        public static string CategoryStaySpring => "宿泊・温泉";
        public static string CategoryToiletParking => "トイレ・駐車場";
        public static string CategoryTransferLife => "交通・生活";
        public static string SearchResult => "検索結果";
        public static string Detail => "詳細";
        public static string ZipCode => "郵便番号";
        public static string Address => "所在地";
        public static string ContactName => "連絡先名";
        public static string TelNo => "電話番号";
        public static string Traffic => "交通";
        public static string Parking => "駐車場";
        public static string Money => "料金";
        public static string OpenHour => "営業時間";
        public static string HoliDay => "休日";
        public static string URL => "URL";
        public static string YouTube => "YouTube";
    }
}
