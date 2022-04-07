using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMoveDesafioProject.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "campo Estado é obrigatório.")]
        public string UF { get; set; }

        [Display(Name = "Nome fantasia")]
        [Required(ErrorMessage = "campo Nome fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "campo CNPJ é obrigatório.")]
        public string CNPJ { get; set; }


        //public Fornecedor Fornecedor { get; set; }
        //public int FornecedorId { get; set; }
    }
}
