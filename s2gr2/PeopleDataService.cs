using System.Collections.Generic;
using System.Threading;

namespace s2gr2
{
	class PeopleDataService : IDataService<Person>
	{
		public IEnumerable<Person> GetData()
		{
			var lst = new List<Person>();

			for (int i = 0; i < 100;++i)
			{
				lst.Add(
					new Person()
						{
							Name = string.Format("name{0}", i),
							Surname = string.Format("surname{0}", i)
						}
					);
			}

			return lst;
		}
	}

	class PeopleDataService2 : IDataService<Person>
	{
		public IEnumerable<Person> GetData()
		{
			var lst = new List<Person>();

			for (int i = 100; i < 200; ++i)
			{
				lst.Add(
					new Person()
					{
						Name = string.Format("name{0}", i),
						Surname = string.Format("surname{0}", i)
					}
					);
			}

			return lst;
		}
	}
}