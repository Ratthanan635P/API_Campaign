using Api_Campaign.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.Entity
{
	public class CampaignDetailByCategory:Base
	{
		public int CampaignsId { get; set; }
		public Campaign Campaigns { get; set; }

		public int? CategoryId { get; set; }
	}
}
