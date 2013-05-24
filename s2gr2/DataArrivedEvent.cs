using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;

namespace s2gr2
{
	public class DataArrivedEvent : CompositePresentationEvent<IEnumerable<Person>>
	{
	}
}