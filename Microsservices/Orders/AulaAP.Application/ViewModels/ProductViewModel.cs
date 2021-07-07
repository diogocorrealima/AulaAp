using System;
using System.ComponentModel.DataAnnotations;

namespace AulaAP.Application.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [MinLength(5,ErrorMessage = "Nome do produto deve ter ao menos 5 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [Range(1, 999999, ErrorMessage = "O campo valor tem que ser maior que {0} e menor que {1}.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatório")]
        [Range(1, 99999, ErrorMessage = "O campo quantidade tem que ser maior que {0} e menor que {1}.")]
        public int Quantity { get; set; }
    }
}