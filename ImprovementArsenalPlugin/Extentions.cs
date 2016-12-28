using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImprovementArsenalPlugin
{
	/// <summary>
	/// 拡張メソッドクラス
	/// </summary>
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
