using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMoveDesafioProject.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ ou CPF")]
        [Required(ErrorMessage = "campo CNPJ ou CPF é obrigatório")]
        public string CnpjCpf { get; set; }

        [Display(Name = "Cadastrado em")]
        public DateTime CadastradoEm { get; set; }
        public string Telefone { get; set; }
        public Empresa Empresa { get; set; }
        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }

    }
}
