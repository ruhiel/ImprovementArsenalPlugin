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
                var today = DateTime.Now;
                // 装備毎にその日の曜日に対応する改修対象リストを検索
                var seq = IATable.List.Where(x => Array.IndexOf(x.Days, days[today.DayOfWeek]) >= 0).GroupBy(x => x.Equip);
                List<ImprovementArsenalSummaryInfo> list = new List<ImprovementArsenalSummaryInfo>();
                var mainGunListLarge = new ImprovementArsenalSummaryInfo("大口径主砲");
                var mainGunListMedium = new ImprovementArsenalSummaryInfo("中口径主砲");
                var mainGunListSmall = new ImprovementArsenalSummaryInfo("小口径主砲");
                var subGunList = new ImprovementArsenalSummaryInfo("副砲・魚雷");
                var fighterList = new ImprovementArsenalSummaryInfo("艦戦");
				var attackerBomberList = new ImprovementArsenalSummaryInfo("艦攻・艦爆");
				var raderList = new ImprovementArsenalSummaryInfo("電探");
                var aswList = new ImprovementArsenalSummaryInfo("ソナー・爆雷");
                var aaList = new ImprovementArsenalSummaryInfo("機銃・高射装置");
                var etcList = new ImprovementArsenalSummaryInfo("その他");
                foreach (var elem in seq)
                {
                    
                    // 装備名からSlotItemInfo逆引き
                    var item = slotItems.Values.Where(x => elem.Key.Equals(x.Name));
                    if (item.Count() != 0)
                    {
                        // 装備種別
                        var slotiteminfo = item.First();
                        var type = slotiteminfo.Type;
                        var elemchunked = elem.Select(x => x.ShipName).Chunk(3);
                        var ships = new List<String>();
                        foreach (var e in elemchunked)
                        {
                            ships.Add(string.Join(",", e));
                        }
                        var infoList = new ImprovementArsenalInfo { SlotItemInfo = slotiteminfo, ShipName = string.Join(Environment.NewLine, ships) };
                        switch(type)
                        {
                            case SlotItemType.大口径主砲:
                            case SlotItemType.大口径主砲_II:
                                mainGunListLarge.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.中口径主砲:
                                mainGunListMedium.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.小口径主砲:
                                mainGunListSmall.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.副砲:
                            case SlotItemType.魚雷:
                                subGunList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.大型電探:
                            case SlotItemType.大型電探_II:
                            case SlotItemType.小型電探:
                                raderList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.大型ソナー:
                            case SlotItemType.ソナー:
                            case SlotItemType.爆雷:
                                aswList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.対空機銃:
                            case SlotItemType.高射装置:
                                aaList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.艦上戦闘機:
                                fighterList.IAInfoList.Add(infoList);
                                break;
							case SlotItemType.艦上攻撃機:
							case SlotItemType.艦上爆撃機:
								attackerBomberList.IAInfoList.Add(infoList);
								break;
                            default:
                                etcList.IAInfoList.Add(infoList);
                                break;
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
                list.Add(fighterList);
				list.Add(attackerBomberList);
				list.Add(raderList);
                list.Add(aswList);
                list.Add(aaList);
                list.Add(etcList);

                return list;
            }
        }

        #endregion
    }
    public static class Extentions
    {
        /// <summary>
        /// シーケンスを指定されたサイズのチャンクに分割します.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> self, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new ArgumentException("Chunk size must be greater than 0.", "chunkSize");
            }

            while (self.Any())
            {
                yield return self.Take(chunkSize);
                self = self.Skip(chunkSize);
            }
        }
    }
}
