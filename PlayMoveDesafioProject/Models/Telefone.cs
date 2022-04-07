using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMoveDesafioProject.Models
{
    public class Telefone
    {
        [Key]
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
    }
}
