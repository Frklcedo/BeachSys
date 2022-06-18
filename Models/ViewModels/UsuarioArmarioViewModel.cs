using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models.ViewModels
{
    public class UsuarioArmarioViewModel
    {
        public Usuario Usuario { get; set; }
        public ICollection<Armario> Armarios { get; set; }
    }
}