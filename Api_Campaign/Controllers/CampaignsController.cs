using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Campaign.Context;
using Api_Campaign.Entity;
using System.Net;
using Api_Campaign.Commands;

namespace Api_Campaign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]

    public class CampaignsController : ControllerBase
    {
        private readonly CampaignContext _context;
        public ErrorMessage ErrorMessage { get; set; }
        public SucessMeassage   SucessMeassage { get; set; }

        public CampaignsController(CampaignContext context)
        {
            _context = context;
            SucessMeassage = new SucessMeassage();
            ErrorMessage = new ErrorMessage();
        }

        // GET: api/Campaigns
        [ProducesResponseType(typeof(List<Campaign>), StatusCodes.Status200OK)]
        [HttpGet("GetPromotionByShop")]
        public IActionResult GetCampaigns(int shopId)
        {
            try
            {
                List<Campaign> item = _context.Campaigns.Where(x => x.ShopId == shopId && x.IsDelete == false).ToList();
                if (item.Count == 0)
                {
                    ErrorMessage.Message = "Not Found";
                    return BadRequest(ErrorMessage);
                }
                else
                {
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }


        }

        // GET: api/Campaigns/5
        [ProducesResponseType(typeof(Campaign), StatusCodes.Status200OK)]
        [HttpGet("getCampaignShopById")]
        public IActionResult GetCampaign(int id, int shopid)
        {
            try
            {
                Campaign item = _context.Campaigns.FirstOrDefault(x => x.Id == id && x.ShopId == shopid && x.IsDelete == false);
                if (item is null)
                {
                    ErrorMessage.Message = "Not Found";
                    return BadRequest(ErrorMessage);
                }
                else
                {
                    return Ok(item);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }
        }

        // PUT: api/Campaigns/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.


        // POST: api/Campaigns
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [ProducesResponseType(typeof(SucessMeassage), StatusCodes.Status200OK)]
        [HttpPost("createCampaignByCat")]
        public IActionResult PostCampaign(CampaignByCatCommand campaignCommand)
        {
            try
            {
                if (campaignCommand is null)
                {
                    ErrorMessage.Message = "Please input data";
                    return BadRequest(ErrorMessage);
                }
                else if (campaignCommand.ListCampaignCategory.Count == 0)
                {
                    ErrorMessage.Message = "Please input ProductList";
                    return BadRequest(ErrorMessage);
                }
                Campaign campaign = new Campaign();
                campaign.PromotionName = campaignCommand.PromotionName;
                campaign.PromotionDetail = campaignCommand.PromotionDetail;
                campaign.StartDate = campaignCommand.StartDate;
                campaign.EndDate = campaignCommand.EndDate;
                campaign.CreatedDate = DateTime.Now;
                campaign.PromotionType = campaignCommand.PromotionType;
                campaign.Discount = campaignCommand.Discount;
                campaign.ShopId = campaignCommand.ShopId;
                campaign.IsDelete = false;
                _context.Campaigns.Add(campaign);
                _context.SaveChangesAsync();
                List<CampaignDetailByCategory> campaignDetailByCategory = campaignCommand.ListCampaignCategory.Select(x => new CampaignDetailByCategory
                {
                    CategoryId = campaign.Id,
                    CreatedDate = DateTime.Now,
                    IsDelete = false,
                    CampaignsId = campaign.Id,
                }).ToList();
                foreach (var item in campaignDetailByCategory)
                {
                    _context.CampaignDetailByCategory.Add(item);
                }
                _context.SaveChangesAsync();
                SucessMeassage.Message = "Sucess";
                return Ok(SucessMeassage);
            }
            catch (Exception ex)
            {
                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }
           
        }
        [ProducesResponseType(typeof(SucessMeassage), StatusCodes.Status200OK)]
        [HttpPost("createCampaignByProduct")]
        public IActionResult PostCampaign(CampaignByProductCommand campaignCommand)
        {
            try
            {
                if (campaignCommand is null)
                {
                    ErrorMessage.Message = "Please input data";
                    return BadRequest(ErrorMessage);
                }
                else if (campaignCommand.ListCampaignProduct.Count == 0)
                {
                    ErrorMessage.Message = "Please input ProductList";
                    return BadRequest(ErrorMessage);
                }
                Campaign campaign = new Campaign();
                campaign.PromotionName = campaignCommand.PromotionName;
                campaign.PromotionDetail = campaignCommand.PromotionDetail;
                campaign.StartDate = campaignCommand.StartDate;
                campaign.EndDate = campaignCommand.EndDate;
                campaign.CreatedDate = DateTime.Now;
                campaign.PromotionType = campaignCommand.PromotionType;
                campaign.Discount = campaignCommand.Discount;
                campaign.ShopId = campaignCommand.ShopId;
                campaign.IsDelete = false;
                _context.Campaigns.Add(campaign);
                _context.SaveChangesAsync();
                List<CampaignDetailByProduct> campaignDetailByProduct = campaignCommand.ListCampaignProduct.Select(x => new CampaignDetailByProduct
                {
                    ProductId = campaign.Id,
                    CreatedDate = DateTime.Now,
                    IsDelete = false,
                    CampaignsId = campaign.Id,
                }).ToList();
                foreach (var item in campaignDetailByProduct)
                {
                    _context.CampaignDetailByProduct.Add(item);
                }
                _context.SaveChangesAsync();
                SucessMeassage.Message = "Sucess";
                return Ok(SucessMeassage);
            }
            catch (Exception ex)
            {
                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }

        }

        // DELETE: api/Campaigns/5
        

        private bool CampaignExists(int id)
        {
            return _context.Campaigns.Any(e => e.Id == id);
        }
        [ProducesResponseType(typeof(SucessMeassage), StatusCodes.Status200OK)]
        [HttpPut("updateDetailByCat")]
        public IActionResult UpdateCampaignByCat(CampaignByCatCommand campaignCommand)
        {
            try
            {
                var result = _context.Campaigns.FirstOrDefault(x => x.Id == campaignCommand.Id);
                if (result is null)
                {
                    ErrorMessage.Message = "Not Found Item";
                    return BadRequest(ErrorMessage);
                }
                else if (campaignCommand.ListCampaignCategory.Count == 0)
                {
                    ErrorMessage.Message = "Please input ProductList";
                    return BadRequest(ErrorMessage);
                }
                var campaign = result;
                campaign.Id = campaignCommand.Id;
                campaign.PromotionName = campaignCommand.PromotionName;
                campaign.PromotionDetail = campaignCommand.PromotionDetail;
                campaign.StartDate = campaignCommand.StartDate;
                campaign.EndDate = campaignCommand.EndDate;
                campaign.UpdateDate = DateTime.Now;
                campaign.PromotionType = campaignCommand.PromotionType;
                campaign.Discount = campaignCommand.Discount;
                campaign.ShopId = campaignCommand.ShopId;
                campaign.IsDelete = false;
                _context.Entry(campaign).State = EntityState.Modified;
                _context.SaveChangesAsync();

                List<CampaignDetailByCategory> campaignDetailByCat = campaignCommand.ListCampaignCategory.Select(x => new CampaignDetailByCategory
                {
                    CategoryId = x.CategoryId,
                    UpdateDate = DateTime.Now,
                    CampaignsId = campaign.Id,
                    IsDelete = x.IsDelete
                }).ToList();
                foreach (var item in campaignDetailByCat)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                _context.SaveChangesAsync();
                SucessMeassage.Message = "Sucess";
                return Ok(SucessMeassage);
            }
            catch (Exception ex)
            {

                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }

        }
        [ProducesResponseType(typeof(SucessMeassage), StatusCodes.Status200OK)]
        [HttpPut("updateDetailByProduct")]
        public IActionResult UpdateCampaignByProduct(CampaignByProductCommand campaignCommand)
        {
            try
            {
                var result = _context.Campaigns.FirstOrDefault(x => x.Id == campaignCommand.Id);
                if (result is null)
                {
                    ErrorMessage.Message = "Not Found Item";
                    return BadRequest(ErrorMessage);
                }
                else if (campaignCommand.ListCampaignProduct.Count == 0)
                {
                    ErrorMessage.Message = "Please input ProductList";
                    return BadRequest(ErrorMessage);
                }
                var campaign = result;
                campaign.Id = campaignCommand.Id;
                campaign.PromotionName = campaignCommand.PromotionName;
                campaign.PromotionDetail = campaignCommand.PromotionDetail;
                campaign.StartDate = campaignCommand.StartDate;
                campaign.EndDate = campaignCommand.EndDate;
                campaign.UpdateDate = DateTime.Now;
                campaign.PromotionType = campaignCommand.PromotionType;
                campaign.Discount = campaignCommand.Discount;
                campaign.ShopId = campaignCommand.ShopId;
                campaign.IsDelete = false;
                _context.Entry(campaign).State = EntityState.Modified;
                _context.SaveChangesAsync();

                List<CampaignDetailByProduct> campaignDetailByProduct = campaignCommand.ListCampaignProduct.Select(x => new CampaignDetailByProduct
                {
                    ProductId = x.ProductId,
                    UpdateDate = DateTime.Now,
                    CampaignsId = campaign.Id,
                    IsDelete = x.IsDelete
                }).ToList();
                foreach (var item in campaignDetailByProduct)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }
                _context.SaveChangesAsync();
                SucessMeassage.Message = "Sucess";
                return Ok(SucessMeassage);
            }
            catch (Exception ex)
            {

                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }

        }
        [ProducesResponseType(typeof(SucessMeassage), StatusCodes.Status200OK)]
        [HttpPut("DeleteCampaign")]
        public IActionResult DeleteCampaign(CampaignCommand campaignCommand)
        {
            try
            {
                var result = _context.Campaigns.FirstOrDefault(x => x.Id == campaignCommand.Id && x.ShopId == campaignCommand.ShopId);
                if (result is null)
                {
                    ErrorMessage.Message = "Not Found Item";
                    return BadRequest(ErrorMessage);
                }
                var campaign = result;

                campaign.UpdateDate = DateTime.Now;
                campaign.IsDelete = true;
                _context.Entry(campaign).State = EntityState.Modified;
                _context.SaveChangesAsync();

                SucessMeassage.Message = "Sucess";
                return Ok(SucessMeassage);
            }
            catch (Exception ex)
            {

                ErrorMessage.Message = ex.Message;
                return StatusCode((int)HttpStatusCode.InternalServerError, ErrorMessage);
            }

        }

    }

}
