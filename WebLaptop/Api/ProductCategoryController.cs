using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebLaptop.Infrastructure.Core;
using WebLaptop.Models;
using WebLaptop_Model.Models;
using WebLaptop_Service;

namespace WebLaptop.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            _productCategoryService = productCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage,int page,int pageSize=20)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>
                {
                    Items = responseData,
                    Page=page,
                    TotalCount=totalRow,
                    TotalPages=(int)Math.Ceiling((decimal)totalRow/pageSize)
                };

                var response = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}
