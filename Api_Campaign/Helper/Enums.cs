
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Campaign.Helper
{
	public class Enums
	{
            public enum Role
            {
                Owner = 1,
                Manager = 2,
                AssistantManager = 3,
                Staff = 4
            }
            public enum OrderType
            {
                Wating = 1,
                Payment = 2,
                Reject = 3

            }
            public enum PromotionType
            {
                Baht = 1,
                Percent = 2
            }
    }
}
