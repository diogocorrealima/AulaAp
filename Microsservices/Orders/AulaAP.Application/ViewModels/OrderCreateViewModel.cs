using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AulaAP.Application.ViewModels
{
    public class OrderCreateViewModel
    {
        
        [MustHaveOneElementAttribute(ErrorMessage = "O pedido deve conter ao menos 1 produto")]
        public List<ProductViewModel> Products { get; set; }
    }
    public class MustHaveOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}