using Livet;
using System.Collections.Generic;

namespace ImprovementArsenalPlugin
{
	// 概要:
	//     改修工廠ViewModel
	public class ImprovementArsenalInfoViewModel : ViewModel
	{
		// 概要:
		//     改修工廠情報モデル
		private ImprovementArsenalInfoModel model;

		// 概要:
		//     コンストラクタ
		public ImprovementArsenalInfoViewModel()
		{
			this.model = new ImprovementArsenalInfoModel();
		}

		#region InfoList 変更通知プロパティ
		// 概要:
		//     改修工廠の情報リスト
		public List<ImprovementArsenalSummaryInfo> InfoList => model.InfoList;
		#endregion
	}
}
