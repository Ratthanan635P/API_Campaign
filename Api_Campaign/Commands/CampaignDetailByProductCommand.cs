using Api_Campaign.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.Entity
{
	public class CampaignDetailByProductCommand
	{
		public int Id { get; set; }
		public int CampaignId { get; set; }
		public int? ProductId { get; set; }
		public bool IsDelete { get; set; }

	}
}
