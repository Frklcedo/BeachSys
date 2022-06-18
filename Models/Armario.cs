using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Armario
    {
        public int ArmarioId { get; set; }
        [Required(ErrorMessage = "Todo armário precisa de um nome")]
        public string Nome { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int compartimentosDisponíveis;
        public virtual ICollection<Compartimento> Compartimentos { get; set; }

        public Armario(){
            compartimentosDisponíveis = 0;
        }
        public Armario(int armarioId, string nome, double x, double y){
            ArmarioId = armarioId;
            Nome = nome;
            X = x;
            Y = y;
            compartimentosDisponíveis = 0;
        }

    }
}