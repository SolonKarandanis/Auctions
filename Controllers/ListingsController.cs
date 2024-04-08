using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            var listinings = await listingsService.FindIndexPageListings(pageNumber,pageSize,searchString);
            return View(listinings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}