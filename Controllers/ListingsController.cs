using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Auctions.Dtos.Web;
using Auctions.Services.Bids;
using Auctions.Services.Comments;
using Auctions.Services.Listings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Auctions.Controllers
{
    [Route("[controller]")]
    public class ListingsController : Controller
    {
        private readonly ILogger<ListingsController> logger;
        private readonly IListingsService listingsService;
        private readonly IBidsService bidsService;
        private readonly ICommentsService commentsService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ListingsController(
            IListingsService listingsService, 
            IWebHostEnvironment webHostEnvironment, 
            IBidsService bidsService, 
            ICommentsService commentsService,
            ILogger<ListingsController> logger)
        {
            this.logger = logger;
            this.listingsService = listingsService;
            this.webHostEnvironment = webHostEnvironment;  
            this.bidsService = bidsService;
            this.commentsService = commentsService;
        }

        public async Task<IActionResult> Index(int pageNumber,int pageSize, string searchString)
        {
            Paging paging = new Paging(pageNumber,pageSize);
            var listinings = await listingsService.FindIndexPageListings(paging,searchString);
            return View(listinings);
        }

        public async Task<IActionResult> MyListings(int pageNumber,int pageSize)
        {
            Paging paging = new Paging(pageNumber,pageSize);
            var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var listinings = await listingsService.FindMyListings(paging,userId);
            return View("Index",listinings);
        }

        public async Task<IActionResult> MyBids(int pageNumber,int pageSize)
        {
            Paging paging = new Paging(pageNumber,pageSize);
            var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myBids = await bidsService.FindMyBids(paging,userId);
            return View(myBids);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var listing = await listingsService.FindById(id.Value);

            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}