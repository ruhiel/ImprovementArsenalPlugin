namespace ImprovementArsenalPlugin
{
    // 概要:
    //     改修工廠情報テーブル
    public partial class IATable
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
        
    }
}
