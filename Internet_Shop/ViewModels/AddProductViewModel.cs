using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Layer.Dto;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Internet_Shop.ViewModels
{
    public class AddProductViewModel
    {
        public ProductsDto Product { get; set; }
        public string ProductType { get; set; }
        public List<SelectListItem> ListTypes { get; set; }
     
    }
}