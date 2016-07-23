using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IATableGenerator
{
	class IAInfoMap : CsvClassMap<IAInfo>
	{
		public IAInfoMap()
		{
			Map(m => m.装備).Index(0);
			Map(m => m.艦娘).Index(1);
			Map(m => m.日).Index(2);
			Map(m => m.月).Index(3);
			Map(m => m.火).Index(4);
			Map(m => m.水).Index(5);
			Map(m => m.木).Index(6);
			Map(m => m.金).Index(7);
			Map(m => m.土).Index(8);
		}
	}
}
