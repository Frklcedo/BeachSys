using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Armario
    {
        public int ArmarioId { get; set; }
        public string Nome { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public virtual ICollection<Compartimento> Compartimentos { get; set; }

        public Armario(int armarioId, string nome, double x, double y){
            ArmarioId = armarioId;
            Nome = nome;
            X = x;
            Y = y;
        }

    }
}