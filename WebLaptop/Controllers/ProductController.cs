﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebLaptop.Infrastructure.Core;
using WebLaptop.Models;
using WebLaptop_Common;
using WebLaptop_Model.Models;
using WebLaptop_Service;

namespace WebLaptop.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }
        // GET: Product
        public ActionResult Detail(int productId)
        {
            var productModel = _productService.GetById(productId);
            _productService.IncreaseViewCount(productModel);
            var productVM = Mapper.Map<Product, ProductViewModel>(productModel);
            var relatedProduct = _productService.GetReatedProducts(productId, 3);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProduct);
            List<string> listImages = new JavaScriptSerializer().Deserialize <List<string>>(productModel.MoreImages);
            ViewBag.MoreImages = listImages;
            ViewBag.Tags =Mapper.Map<IEnumerable<Tag>,IEnumerable<TagViewModel>>(_productService.GetListTagsByProductId(productId));
            return View(productVM);
        }
        public ActionResult Category(int id, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, sort, out totalRow);
            var productVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            var category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize); //tổng số trang chia cho số trang,làm tròn số với math.ceiling và ép kiểu về int
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productVM,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.Search(keyword, page, pageSize, sort, out totalRow);
            var productVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            ViewBag.KeyWord = keyword;
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize); //tổng số trang chia cho số trang,làm tròn số với math.ceiling và ép kiểu về int
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productVM,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public ActionResult ListByTag(string tagid,int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var productModel = _productService.GetListProductByTag(tagid, page, pageSize, out totalRow);
            var productVM = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            ViewBag.Tag =Mapper.Map<Tag,TagViewModel>(_productService.GetTag(tagid));
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize); //tổng số trang chia cho số trang,làm tròn số với math.ceiling và ép kiểu về int
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productVM,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListProductByName(keyword);
            return Json(new
            {
                data = model
            },JsonRequestBehavior.AllowGet);
        }
    }
}