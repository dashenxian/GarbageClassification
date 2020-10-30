using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageClassification.DataModels
{
    public class LabelMapping
    {
        private static Lazy<Dictionary<string, string>> labs = new Lazy<Dictionary<string, string>>(CreateLabels);

        /// <summary>
        /// 转换为中文名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MapLabel(string key)
        {
            var dic = labs.Value;
            var keyPad = key.PadLeft(2, '0');
            if (dic.ContainsKey(keyPad))
            {
                return dic[keyPad];
            }
            return key;
        }
        private static Dictionary<string, string> CreateLabels()
        {
            var dic = new Dictionary<string, string>()
            {
                {"00", "其他垃圾/一次性快餐盒"},
                {"01", "其他垃圾/污损塑料"},
                {"02", "其他垃圾/烟蒂"},
                {"03", "其他垃圾/牙签"},
                {"04", "其他垃圾/破碎花盆及碟碗"},
                {"05", "其他垃圾/竹筷"},
                {"06", "厨余垃圾/剩饭剩菜"},
                {"07", "厨余垃圾/大骨头"},
                {"08", "厨余垃圾/水果果皮"},
                {"09", "厨余垃圾/水果果肉"},
                {"10", "厨余垃圾/茶叶渣"},
                {"11", "厨余垃圾/菜叶菜根"},
                {"12", "厨余垃圾/蛋壳"},
                {"13", "厨余垃圾/鱼骨"},
                {"14", "可回收物/充电宝"},
                {"15", "可回收物/包"},
                {"16", "可回收物/化妆品瓶"},
                {"17", "可回收物/塑料玩具"},
                {"18", "可回收物/塑料碗盆"},
                {"19", "可回收物/塑料衣架"},
                {"20", "可回收物/快递纸袋"},
                {"21", "可回收物/插头电线"},
                {"22", "可回收物/旧衣服"},
                {"23", "可回收物/易拉罐"},
                {"24", "可回收物/枕头"},
                {"25", "可回收物/毛绒玩具"},
                {"26", "可回收物/洗发水瓶"},
                {"27", "可回收物/玻璃杯"},
                {"28", "可回收物/皮鞋"},
                {"29", "可回收物/砧板"},
                {"30", "可回收物/纸板箱"},
                {"31", "可回收物/调料瓶"},
                {"32", "可回收物/酒瓶"},
                {"33", "可回收物/金属食品罐"},
                {"34", "可回收物/锅"},
                {"35", "可回收物/食用油桶"},
                {"36", "可回收物/饮料瓶"},
                {"37", "有害垃圾/干电池"},
                {"38", "有害垃圾/软膏"},
                {"39", "有害垃圾/过期药物"},

            };
            return dic;
        }
    }
}
