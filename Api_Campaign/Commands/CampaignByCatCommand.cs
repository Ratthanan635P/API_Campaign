using Api_Campaign.Entity;
using Api_Campaign.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.Commands
{
	public class CampaignByCatCommand
	{
		public int Id { get; set; }
		public string PromotionName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string PromotionDetail { get; set; }
		public int ShopId { get; set; }
		public double Discount { get; set; }
		public Enums.PromotionType PromotionType { get; set; }
		public List<CampaignDetailByCategoryCommand> ListCampaignCategory { get; set; }
	}
}
