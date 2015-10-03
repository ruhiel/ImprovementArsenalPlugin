using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovementArsenalPlugin
{
    // 概要:
    //     改修工廠情報テーブル
    public class IATable
    {
        // 概要:
        //     装備名
        public string Equip { get; set; }
        // 概要:
        //     対応曜日リスト
        public string[] Days { get; set; }
        // 概要:
        //     艦名
        public string ShipName { get; set; }

        public static IATable[] List = new IATable[] {
            new IATable { Equip = "12.7cm連装砲", Days = new string[] {"日","月","火","水","木","金","土"}, ShipName = ""},
            new IATable { Equip = "12.7cm連装砲B型改二", Days = new string[] {"月","火","水"}, ShipName = "夕立改二"},
            new IATable { Equip = "12.7cm連装砲B型改二", Days = new string[] {"月","火","水"}, ShipName = "綾波改二"},
            new IATable { Equip = "10cm連装高角砲+高射装置", Days = new string[] {"月","火","水","木"}, ShipName = "秋月"},
            new IATable { Equip = "10cm連装高角砲+高射装置", Days = new string[] {"日","木","金","土"}, ShipName = "照月"},
            new IATable { Equip = "14cm単装砲", Days = new string[] {"日","月","火","水","木","金","土"}, ShipName = ""},
            new IATable { Equip = "14cm連装砲", Days = new string[] {"月","木"}, ShipName = "夕張"},
            new IATable { Equip = "15.2cm連装砲", Days = new string[] {"木","金","土"}, ShipName = "阿賀野"},
            new IATable { Equip = "15.2cm連装砲", Days = new string[] {"日","月","金","土"}, ShipName = "能代"},
            new IATable { Equip = "15.2cm連装砲", Days = new string[] {"月","火","水","木"}, ShipName = "矢矧"},
            new IATable { Equip = "15.2cm連装砲改", Days = new string[] {"水","木","金","土"}, ShipName = "矢矧"},
            new IATable { Equip = "15.2cm連装砲改", Days = new string[] {"日","月","火","土"}, ShipName = "酒匂"},
            new IATable { Equip = "15.5cm三連装砲", Days = new string[] {"金","土"}, ShipName = "最上"},
            new IATable { Equip = "15.5cm三連装砲", Days = new string[] {"日","月"}, ShipName = "大淀"},
            new IATable { Equip = "20.3cm連装砲", Days = new string[] {"日","木","金","土"}, ShipName = "青葉"},
            new IATable { Equip = "20.3cm連装砲", Days = new string[] {"日","月","火","水","木","金","土"}, ShipName = "衣笠"},
            new IATable { Equip = "20.3cm(2号)連装砲", Days = new string[] {"日","月","火"}, ShipName = "妙高"},
            new IATable { Equip = "20.3cm(3号)連装砲", Days = new string[] {"火","水"}, ShipName = "三隈"},
            new IATable { Equip = "35.6cm連装砲", Days = new string[] {"日","金","土"}, ShipName = "扶桑"},
            new IATable { Equip = "38cm連装砲", Days = new string[] {"木","金","土"}, ShipName = "Bismarck"},
            new IATable { Equip = "38cm連装砲改", Days = new string[] {"日","月","火"}, ShipName = "Bismarck"},
            new IATable { Equip = "381mm/50 三連装砲", Days = new string[] {"火","水","木","金"}, ShipName = "Littorio"},
            new IATable { Equip = "381mm/50 三連装砲", Days = new string[] {"日","月","土"}, ShipName = "Roma"},
            new IATable { Equip = "381mm/50 三連装砲改", Days = new string[] {"日","月","土"}, ShipName = "Littorio"},
            new IATable { Equip = "381mm/50 三連装砲改", Days = new string[] {"火","水","木","金"}, ShipName = "Roma"},
            new IATable { Equip = "41cm連装砲", Days = new string[] {"火","金","土"}, ShipName = "長門"},
            new IATable { Equip = "41cm連装砲", Days = new string[] {"日","月","木"}, ShipName = "陸奥"},
            new IATable { Equip = "試製46cm連装砲", Days = new string[] {"日","月"}, ShipName = "大和"},
            new IATable { Equip = "試製46cm連装砲", Days = new string[] {"火","水"}, ShipName = "武蔵"},
            new IATable { Equip = "46cm三連装砲", Days = new string[] {"金","土"}, ShipName = "大和"},
            new IATable { Equip = "46cm三連装砲", Days = new string[] {"日","月"}, ShipName = "武蔵"},
            new IATable { Equip = "試製51cm連装砲", Days = new string[] {"月","火"}, ShipName = "大和改"},
            new IATable { Equip = "試製51cm連装砲", Days = new string[] {"月","水"}, ShipName = "武蔵改"},
            new IATable { Equip = "90mm単装高角砲", Days = new string[] {"月","火","水","木"}, ShipName = "Littorio"},
            new IATable { Equip = "90mm単装高角砲", Days = new string[] {"日","木","金","土"}, ShipName = "Roma"},
            new IATable { Equip = "15.2cm単装砲", Days = new string[] {"日","月","火"}, ShipName = "阿賀野"},
            new IATable { Equip = "15.2cm単装砲", Days = new string[] {"日","月","土"}, ShipName = "金剛"},
            new IATable { Equip = "15.2cm単装砲", Days = new string[] {"月","火","水"}, ShipName = "山城"},
            new IATable { Equip = "OTO 152mm三連装速射砲", Days = new string[] {"日","火","水","土"}, ShipName = "Littorio"},
            new IATable { Equip = "OTO 152mm三連装速射砲", Days = new string[] {"日","月","木","金"}, ShipName = "Roma"},
            new IATable { Equip = "61cm三連装魚雷", Days = new string[] {"木","金","土"}, ShipName = "吹雪/吹雪改"},
            new IATable { Equip = "61cm三連装魚雷", Days = new string[] {"日","月","火"}, ShipName = "叢雲"},
            new IATable { Equip = "61cm三連装(酸素)魚雷", Days = new string[] {"木","金","土"}, ShipName = "吹雪改二"},
            new IATable { Equip = "61cm四連装魚雷", Days = new string[] {"日","月","火","金","土"}, ShipName = ""},
            new IATable { Equip = "61cm四連装(酸素)魚雷", Days = new string[] {"日","月","火","水","木","金","土"}, ShipName = "大井, 北上"},
            new IATable { Equip = "61cm五連装(酸素)魚雷", Days = new string[] {"水","木"}, ShipName = "島風"},
            new IATable { Equip = "13号対空電探", Days = new string[] {"日","木","金","土"}, ShipName = "時雨改二"},
            new IATable { Equip = "13号対空電探", Days = new string[] {"日","月","金","土"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "13号対空電探", Days = new string[] {"火","水","木"}, ShipName = "秋月"},
            new IATable { Equip = "13号対空電探", Days = new string[] {"月","火","水"}, ShipName = "照月"},
            new IATable { Equip = "13号対空電探改", Days = new string[] {"木","金","土"}, ShipName = "磯風改"},
            new IATable { Equip = "13号対空電探改", Days = new string[] {"日","金","土"}, ShipName = "初霜改二"},
            new IATable { Equip = "13号対空電探改", Days = new string[] {"日","月","火","水"}, ShipName = "雪風"},
            new IATable { Equip = "22号対水上電探", Days = new string[] {"日","月","金","土"}, ShipName = "日向"},
            new IATable { Equip = "22号対水上電探", Days = new string[] {"月","火","金","土"}, ShipName = "夕雲"},
            new IATable { Equip = "22号対水上電探", Days = new string[] {"水","木","金","土"}, ShipName = "島風"},
            new IATable { Equip = "22号対水上電探改四", Days = new string[] {"日","木","金","土"}, ShipName = "妙高改二"},
            new IATable { Equip = "22号対水上電探改四", Days = new string[] {"日","月","金","土"}, ShipName = "羽黒改二"},
            new IATable { Equip = "22号対水上電探改四", Days = new string[] {"火","水","木","金"}, ShipName = "金剛改二"},
            new IATable { Equip = "21号対空電探", Days = new string[] {"日","月","金","土"}, ShipName = "伊勢"},
            new IATable { Equip = "21号対空電探", Days = new string[] {"水","木","金","土"}, ShipName = "日向"},
            new IATable { Equip = "21号対空電探改", Days = new string[] {"日","木","金","土"}, ShipName = "大和"},
            new IATable { Equip = "21号対空電探改", Days = new string[] {"火","水","木","金"}, ShipName = "武蔵"},
            new IATable { Equip = "32号対水上電探", Days = new string[] {"水","木","金","土"}, ShipName = "伊勢"},
            new IATable { Equip = "32号対水上電探", Days = new string[] {"日","月","火"}, ShipName = "日向"},
            new IATable { Equip = "32号対水上電探改", Days = new string[] {"日","月","火"}, ShipName = "伊勢"},
            new IATable { Equip = "32号対水上電探改", Days = new string[] {"水","木","金","土"}, ShipName = "日向"},
            new IATable { Equip = "九三式水中聴音機", Days = new string[] {"日","金","土"}, ShipName = "夕張"},
            new IATable { Equip = "九三式水中聴音機", Days = new string[] {"月","金","土"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "九三式水中聴音機", Days = new string[] {"日","金","土"}, ShipName = "香取改"},
            new IATable { Equip = "九三式水中聴音機", Days = new string[] {"日","木", "金","土"}, ShipName = "時雨改二"},
            new IATable { Equip = "三式水中探信儀", Days = new string[] {"火","水"}, ShipName = "夕張"},
            new IATable { Equip = "三式水中探信儀", Days = new string[] {"日","火","水"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "四式水中聴音機", Days = new string[] {"月","火"}, ShipName = "香取改"},
            new IATable { Equip = "四式水中聴音機", Days = new string[] {"木","金","土"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "四式水中聴音機", Days = new string[] {"日"}, ShipName = "秋月"},
            new IATable { Equip = "四式水中聴音機", Days = new string[] {"水"}, ShipName = "照月"},
            new IATable { Equip = "九四式爆雷投射機", Days = new string[] {"水","木"}, ShipName = ""},
            new IATable { Equip = "三式爆雷投射機", Days = new string[] {"水","木"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "九一式徹甲弾", Days = new string[] {"水","木","金","土"}, ShipName = "比叡"},
            new IATable { Equip = "九一式徹甲弾", Days = new string[] {"日","月","金","土"}, ShipName = "霧島"},
            new IATable { Equip = "一式徹甲弾", Days = new string[] {"日","金","土"}, ShipName = "金剛"},
            new IATable { Equip = "一式徹甲弾", Days = new string[] {"月","火","水"}, ShipName = "榛名"},
            new IATable { Equip = "25mm連装機銃", Days = new string[] {"日","土"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "25mm三連装機銃", Days = new string[] {"月","火","水"}, ShipName = "五十鈴改二"},
            new IATable { Equip = "25mm三連装機銃", Days = new string[] {"火","水","木"}, ShipName = "摩耶/摩耶改"},
            new IATable { Equip = "25mm三連装機銃", Days = new string[] {"日","月","金","土"}, ShipName = "摩耶改二"},
            new IATable { Equip = "91式高射装置", Days = new string[] {"日","月","金","土"}, ShipName = "摩耶"},
            new IATable { Equip = "91式高射装置", Days = new string[] {"日","月","金","土"}, ShipName = "秋月"},
            new IATable { Equip = "91式高射装置", Days = new string[] {"日","木","金","土"}, ShipName = "照月"},
            new IATable { Equip = "94式高射装置", Days = new string[] {"日","月","火","水","木","金","土"}, ShipName = "秋月"},
            new IATable { Equip = "94式高射装置", Days = new string[] {"日","月","火","水","木","金","土"}, ShipName = "照月"},
            new IATable { Equip = "94式高射装置", Days = new string[] {"日","木","金","土"}, ShipName = "吹雪改二"},
            new IATable { Equip = "94式高射装置", Days = new string[] {"日","木","金","土"}, ShipName = "摩耶改二"},
            new IATable { Equip = "探照灯", Days = new string[] {"木","金","土"}, ShipName = "暁"},
            new IATable { Equip = "探照灯", Days = new string[] {"日","金","土"}, ShipName = "神通"},
            new IATable { Equip = "探照灯", Days = new string[] {"月","火","水"}, ShipName = "青葉"},
            new IATable { Equip = "探照灯", Days = new string[] {"月","火","水"}, ShipName = "綾波"},
            new IATable { Equip = "96式150cm探照灯", Days = new string[] {"日","月","金","土"}, ShipName = "比叡"},
            new IATable { Equip = "96式150cm探照灯", Days = new string[] {"火","水","木","金"}, ShipName = "霧島"},

        };
    }
}
