using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.Entity
{
	public class Base
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public bool IsDelete { get; set; }
	}
}
