using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using System.ComponentModel.Composition;

namespace ImprovementArsenalPlugin
{
    // 概要:
    //     改修工廠プラグイン
    [Export(typeof(IPlugin))]
    [ExportMetadata("Title", "改修工廠プラグイン")]
    [ExportMetadata("Description", "改修対象の装備一覧を表示します。")]
    [ExportMetadata("Version", "1.0.5")]
    [ExportMetadata("Author", "@ruhiel_murrue")]
    [ExportMetadata("Guid", "C15A5E17-CE79-4E74-9FBA-B5EC3F019866")]
    [Export(typeof(ITool))]
    public class ImprovementArsenalPlugin : IPlugin, ITool
    {
        // 概要:
        //     [ツール] タブ内に表示される UI のルート要素を取得します。
        public object View => new UserControl1 { DataContext = new ImprovementArsenalInfoViewModel(KanColleClient.Current.Master.SlotItems), };
        // 概要:
        //     [ツール] タブのツール一覧に表示される名前を取得します。
        //
        public string Name => "Akashi's Arsenal";
        //
        // 概要:
        //     プラグインの初期化処理を実行します。
        public void Initialize()
        {
            
        }
    }
}
