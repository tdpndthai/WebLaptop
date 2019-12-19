using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLaptop.Models;
using WebLaptop_Model.Models;

namespace WebLaptop.Infrastructure.Extensions
{
    //tạo phương thức mở rộng cho 1 đối tượng nào đấy static
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;
            postCategory.Description = postCategoryViewModel.Description;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.Image = postCategoryViewModel.Image;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;

            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.Status = postCategoryViewModel.Status;
        } 

        public static void Update(this Post post,PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Description = postViewModel.Description;
            post.Alias = postViewModel.Alias;
            post.CategoryID = postViewModel.CategoryID;
            post.Content = postViewModel.Content;
            post.Image = postViewModel.Image;
            post.HomeFlag = postViewModel.HomeFlag;
            post.ViewCount = postViewModel.ViewCount;

            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory,ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.Alias = productCategoryViewModel.Alias;
            productCategory.CreatedBy = productCategoryViewModel.CreatedBy;
            productCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategory.Description = productCategoryViewModel.Description;
            productCategory.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Image = productCategoryViewModel.Image;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.ParentID = productCategoryViewModel.ParentID;
            productCategory.Status = productCategoryViewModel.Status;
            productCategory.UpdatedBy = productCategoryViewModel.UpdatedBy;
            productCategory.UpdatedDate = productCategoryViewModel.UpdatedDate;
        }
        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.Description = productViewModel.Description;
            product.Alias = productViewModel.Alias;
            product.CategoryID = productViewModel.CategoryID;
            product.Content = productViewModel.Content;
            product.Image = productViewModel.Image;
            product.MoreImages = productViewModel.MoreImages;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;
            product.Tags = productViewModel.Tags;

            product.CreatedDate = productViewModel.CreatedDate;
            product.CreatedBy = productViewModel.CreatedBy;
            product.UpdatedDate = productViewModel.UpdatedDate;
            product.UpdatedBy = productViewModel.UpdatedBy;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.MetaDescription = productViewModel.MetaDescription;
            product.Status = productViewModel.Status;
        }
    }
}