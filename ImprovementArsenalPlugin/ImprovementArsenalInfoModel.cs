using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImprovementArsenalPlugin
{
	// 概要:
	//     改修工廠Model
	public class ImprovementArsenalInfoModel
	{
		// 概要:
		//     改修工廠の情報リスト
		public List<ImprovementArsenalSummaryInfo> InfoList
		{
			get
			{
				var days = new Dictionary<DayOfWeek, string>
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
				var list = new List<ImprovementArsenalSummaryInfo>();
				var mainGunList = new ImprovementArsenalSummaryInfo("主砲・弾薬");
				var subGunList = new ImprovementArsenalSummaryInfo("副砲・魚雷");
				var aircraftList = new ImprovementArsenalSummaryInfo("航空機");
				var aquiferList = new ImprovementArsenalSummaryInfo("水上機");
				var raderList = new ImprovementArsenalSummaryInfo("電探・ソナー");
				var aaList = new ImprovementArsenalSummaryInfo("缶・バルジ");
				var airdefenseList = new ImprovementArsenalSummaryInfo("機銃・高射装置");
				var etcList = new ImprovementArsenalSummaryInfo("その他");
				foreach (var elem in seq)
				{

					// 装備名からSlotItemInfo逆引き
					var item = KanColleClient.Current.Master.SlotItems.Values.Where(x => elem.Key.Equals(x.Name));
					if (item.Any())
					{
						// 装備種別
						var slotiteminfo = item.First();
						var type = slotiteminfo.Type;
						var elemchunked = elem.Select(x => x.ShipName).Chunk(3);
                        var info = elem.Select(x => x.Info).First();
                        var ships = new List<string>();
						foreach (var e in elemchunked)
						{
							ships.Add(string.Join(",", e));
						}
						var infoList = new ImprovementArsenalInfo { SlotItemInfo = slotiteminfo, ShipName = string.Join(Environment.NewLine, ships), Info = info };
						switch (type)
						{
							case SlotItemType.大口径主砲:
							case SlotItemType.大口径主砲_II:
                            case SlotItemType.対艦強化弾:
                            case SlotItemType.対空強化弾:
                            case SlotItemType.中口径主砲:
                            case SlotItemType.小口径主砲:
                                mainGunList.IAInfoList.Add(infoList);
								break;
							case SlotItemType.副砲:
							case SlotItemType.魚雷:
                            case SlotItemType.潜水艦魚雷:
                            case SlotItemType.特殊潜航艇:
                                subGunList.IAInfoList.Add(infoList);
								break;
                            case SlotItemType.艦上戦闘機:
                            case SlotItemType.艦上攻撃機:
                            case SlotItemType.艦上爆撃機:
                            case SlotItemType.艦上偵察機:
                            case SlotItemType.艦上偵察機_II:
                            case SlotItemType.対潜哨戒機:
                            case SlotItemType.陸上攻撃機:
                            case SlotItemType.局地戦闘機:
                                aircraftList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.水上偵察機:
                            case SlotItemType.水上戦闘機:
                            case SlotItemType.水上爆撃機:
                            case SlotItemType.大型飛行艇:
                            case SlotItemType.オートジャイロ:
                            case SlotItemType.航空要員:
                                aquiferList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.大型電探:
							case SlotItemType.大型電探_II:
							case SlotItemType.小型電探:
                            case SlotItemType.大型ソナー:
                            case SlotItemType.ソナー:
                            case SlotItemType.爆雷:
                            case SlotItemType.水上艦要員:
                                raderList.IAInfoList.Add(infoList);
								break;
                            case SlotItemType.機関部強化:
                            case SlotItemType.追加装甲:
                            case SlotItemType.追加装甲_中型:
                            case SlotItemType.追加装甲_大型:
                                aaList.IAInfoList.Add(infoList);
                                break;
                            case SlotItemType.対空機銃:
							case SlotItemType.高射装置:
                                airdefenseList.IAInfoList.Add(infoList);
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

				list.Add(mainGunList);
				list.Add(subGunList);
				list.Add(aircraftList);
				list.Add(aquiferList);
				list.Add(raderList);
				list.Add(aaList);
                list.Add(airdefenseList);
                list.Add(etcList);

				return list;
			}
		}
	}
}