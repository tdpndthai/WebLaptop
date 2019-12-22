using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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

        //phiên bản chung,tất cả các user đều có kết quả chung trả về thì nên đặt outputcache ở server,còn nếu trả riêng ví dụ đăng nhập
        // xin chào+tên người dùng thì sẽ đặt ở client
        // đối với partial view thì ko được set output cachelocation
        [OutputCache(Duration =60,Location =OutputCacheLocation.Server)]
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


        [OutputCache(Duration =3600)]
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            ViewBag.Time = DateTime.Now.ToString("T");
            return PartialView(footerViewModel);
        }
        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        [OutputCache(Duration = 3600)]
        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}