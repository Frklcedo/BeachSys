using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Compartimento
    {
        public int CompartimentoId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tamanho { get; set; }
        public bool IsDisponivel { get; set; }
        [Required]
        public int? ArmarioId { get; set; }
        [ForeignKey("ArmarioId")]
        public virtual Armario Armario { get; set; }
        public int? UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }
}