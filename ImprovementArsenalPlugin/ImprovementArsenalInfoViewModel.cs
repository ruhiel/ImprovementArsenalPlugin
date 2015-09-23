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
        public List<ImprovementArsenalInfo> InfoList
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
                List<ImprovementArsenalInfo> list = new List<ImprovementArsenalInfo>();
                foreach (var elem in seq)
                {
                    // 装備名からSlotItemInfo逆引き
                    var item = slotItems.Values.Where(x => elem.Key.Equals(x.Name));
                    if (item.Count() != 0)
                    {
                        list.Add(new ImprovementArsenalInfo { SlotItemInfo = item.First(), Kanmusu = string.Join(",", elem.Select(x => x.Kanmusu)) });
                    }
                    else
                    {
                        throw new KeyNotFoundException("不明な装備" + elem.Key);
                    }
                    
                }
                return list;
            }
        }
        #endregion
    }
}
