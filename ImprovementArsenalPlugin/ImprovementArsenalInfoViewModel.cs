using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;

namespace ImprovementArsenalPlugin
{
    // 概要:
    //     改修工廠ViewModel
    public class ImprovementArsenalInfoViewModel : ViewModel
    {
        // 概要:
        //     装備アイテムの種類に基づく情報のリスト
        private MasterTable<SlotItemInfo> slotItems;

        // 概要:
        //     コンストラクタ
        public ImprovementArsenalInfoViewModel(MasterTable<SlotItemInfo> slotItems)
        {
            this.slotItems = slotItems;
        }
        #region InfoList 変更通知プロパティ
        // 概要:
        //     改修工廠の情報リスト
        public List<ImprovementArsenalSummaryInfo> InfoList
        {
            get
            {
                Dictionary<DayOfWeek, string> days = new Dictionary<DayOfWeek, string>
                {
                    {DayOfWeek.Sunday, "日" },
                    {DayOfWeek.Monday, "月" },
                    {DayOfWeek.Tuesday, "火" },
                    {DayOfWeek.Wednesday, "水" },
                    {DayOfWeek.Thursday, "木" },
                    {DayOfWeek.Friday, "金" },
                    {DayOfWeek.Saturday, "土" }
                };
                // 装備毎にその日の曜日に対応する改修対象リストを検索
                var seq = IATable.List.Where(x => Array.IndexOf(x.Days, days[DateTime.Now.DayOfWeek]) >= 0).GroupBy(x => x.Equip);
                List<ImprovementArsenalSummaryInfo> list = new List<ImprovementArsenalSummaryInfo>();
                ImprovementArsenalSummaryInfo mainGunListLarge = new ImprovementArsenalSummaryInfo()
                {
                    EquipType = "大口径主砲",
                    IAInfoList = new List<ImprovementArsenalInfo>()
                };
                ImprovementArsenalSummaryInfo mainGunListMedium = new ImprovementArsenalSummaryInfo()
                {
                    EquipType = "中口径主砲",
                    IAInfoList = new List<ImprovementArsenalInfo>()
                };
                ImprovementArsenalSummaryInfo mainGunListSmall = new ImprovementArsenalSummaryInfo()
                {
                    EquipType = "小口径主砲",
                    IAInfoList = new List<ImprovementArsenalInfo>()
                };
                ImprovementArsenalSummaryInfo subGunList = new ImprovementArsenalSummaryInfo()
                {
                    EquipType = "副砲・魚雷", IAInfoList = new List<ImprovementArsenalInfo>()
                };
                ImprovementArsenalSummaryInfo raderList = new ImprovementArsenalSummaryInfo
                {
                    EquipType = "電探", IAInfoList = new List<ImprovementArsenalInfo>()
                };
                ImprovementArsenalSummaryInfo aswList = new ImprovementArsenalSummaryInfo()
                {
                    EquipType = "ソナー・爆雷",
                    IAInfoList = new List<ImprovementArsenalInfo>()
                };
                ImprovementArsenalSummaryInfo etcList = new ImprovementArsenalSummaryInfo()
                {
                    EquipType = "その他",
                    IAInfoList = new List<ImprovementArsenalInfo>()
                };
                foreach (var elem in seq)
                {
                    
                    // 装備名からSlotItemInfo逆引き
                    var item = slotItems.Values.Where(x => elem.Key.Equals(x.Name));
                    if (item.Count() != 0)
                    {
                        // 装備種別
                        var slotiteminfo = item.First();
                        var equiptype = slotiteminfo.EquipType.Id;
                        var infoList = new ImprovementArsenalInfo { SlotItemInfo = slotiteminfo, ShipName = string.Join(",", elem.Select(x => x.ShipName)) };
                        if (equiptype.Equals(3) || equiptype.Equals(38))
                        {
                            // 大口径主砲
                            mainGunListLarge.IAInfoList.Add(infoList);
                        }
                        else if (equiptype.Equals(2))
                        {
                            // 中口径主砲
                            mainGunListMedium.IAInfoList.Add(infoList);
                        }
                        else if (equiptype.Equals(1))
                        {
                            // 小口径主砲
                            mainGunListSmall.IAInfoList.Add(infoList);
                        }
                        else if (equiptype.Equals(4) || equiptype.Equals(5))
                        {
                            // 副砲・魚雷
                            subGunList.IAInfoList.Add(infoList);
                        }
                        else if (equiptype.Equals(12) || equiptype.Equals(13) || equiptype.Equals(93))
                        {
                            // 電探
                            raderList.IAInfoList.Add(infoList);
                        }
                        else if (equiptype.Equals(14) || equiptype.Equals(15))
                        {
                            // ソナー・爆雷
                            aswList.IAInfoList.Add(infoList);
                        }
                        else
                        {
                            // その他
                            etcList.IAInfoList.Add(infoList);
                        }
                    }
                    else
                    {
                        throw new KeyNotFoundException("不明な装備" + elem.Key);
                    }
                    
                }
                list.Add(mainGunListLarge);
                list.Add(mainGunListMedium);
                list.Add(mainGunListSmall);
                list.Add(subGunList);
                list.Add(raderList);
                list.Add(aswList);
                list.Add(etcList);

                return list;
            }
        }
        #endregion
    }
}
