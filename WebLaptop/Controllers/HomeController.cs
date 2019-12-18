using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLaptop.Models;
using WebLaptop_Model.Models;
using WebLaptop_Service;

namespace WebLaptop.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService,IProductService productService,ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlide();
            var slideViewModel = Mapper.Map<IEnumerable<Slide>,IEnumerable<SlideViewModel>>(slideModel);
            var lastestProductModel = _productService.GetLastest(3);
            var lastestProVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSale = _productService.GetHotProduct(3);
            var topSaleProVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSale);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideViewModel;
            homeViewModel.LastestProducts = lastestProVM;
            homeViewModel.TopSaleProducts = topSaleProVM;
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}