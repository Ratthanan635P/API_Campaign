using Api_Campaign.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.OnConfiguration
{
	public class CampaignConfig : IEntityTypeConfiguration<Campaign>
	{
		public void Configure(EntityTypeBuilder<Campaign> builder)
		{
			builder.Property(x => x.PromotionName).HasMaxLength(100);
			builder.Property(x => x.PromotionDetail).HasMaxLength(500);

		}
	}
}
