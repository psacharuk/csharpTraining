using System;
using System.Collections.Generic;

namespace s2gr2
{
	public class CompanyDataService : IDataService<Company>
	{
		public IEnumerable<Company> GetData()
		{
			var rand = new Random();
			int i = 0;
			while(true)
			{
				++i;
				yield return new Company()
					{
						Name = string.Format("company{0}", i),
						Nip = rand.Next(),
						Regon = rand.Next()
					};
			}
		}
	}
}