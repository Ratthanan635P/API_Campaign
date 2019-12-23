using Api_Campaign.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.Entity
{
	public class CampaignDetailByProduct:Base
	{
		public int CampaignsId { get; set; }
		public Campaign Campaigns { get; set; }

		public int? ProductId { get; set; }
	}
}
