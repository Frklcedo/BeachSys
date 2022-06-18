using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models.ViewModels
{
    public class UsuarioCompartimentoViewModel
    {
        
        public Usuario Usuario { get; set; }
        public ICollection<Compartimento> Compartimentos { get; set; }
    }
}