using CsvHelper;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace IATableGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			var wc = new System.Net.WebClient();
			var path = Path.GetTempFileName();
			wc.DownloadFile("https://docs.google.com/spreadsheets/d/1mLbhSh-STB1OYTK0mmWJM2Wle_9zJemqV88EpnuOC3w/pub?output=csv", path);
			wc.Dispose();

			CsvParser parser = new CsvParser(new StreamReader(path, Encoding.UTF8));

			parser.Configuration.HasHeaderRecord = true;  // ヘッダ行は無い
			parser.Configuration.RegisterClassMap<IAInfoMap>();

			CsvReader reader = new CsvReader(parser);
			List<IAInfo> list = reader.GetRecords<IAInfo>().ToList();
			parser.Dispose();
			reader.Dispose();

			File.Delete(path);

			var filename = System.IO.Directory.GetCurrentDirectory() + "/IATableList.txt";

			//書き込むファイルが既に存在している場合は、上書きする
			var sw = new StreamWriter(
				filename,
				false,
				Encoding.UTF8);

			sw.WriteLine("namespace ImprovementArsenalPlugin");
			sw.WriteLine("{");
			sw.WriteLine("\tpublic partial class IATable");
			sw.WriteLine("\t{");
			sw.WriteLine("\t\tpublic static IATable[] List = new IATable[] {");

			foreach (IAInfo record in list)
			{
				string value = "\t\t\tnew IATable { Equip = \"" + record.装備 + "\", Days = new string[] {";
				var days = new[] {
					new { WeekDay = nameof(record.日), Enable = record.日 },
					new { WeekDay = nameof(record.月), Enable = record.月 },
					new { WeekDay = nameof(record.火), Enable = record.火 },
					new { WeekDay = nameof(record.水), Enable = record.水 },
					new { WeekDay = nameof(record.木), Enable = record.木 },
					new { WeekDay = nameof(record.金), Enable = record.金 },
					new { WeekDay = nameof(record.土), Enable = record.土 },
				};
				value += string.Join(",", days.Where(x => "○".Equals(x.Enable)).Select(x => '"' + x.WeekDay + '"'));

				value += "}, ShipName = \"" + record.艦娘 + "\"},";

				sw.WriteLine(value);
			}

			sw.WriteLine("\t\t};");
			sw.WriteLine("\t}");
			sw.WriteLine("}");

			//閉じる
			sw.Close();

			Process.Start(filename);
		}
	}
}
