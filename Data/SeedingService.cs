using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeachSys.Models;

namespace BeachSys.Data
{
    public class SeedingService
    {
        private BeachSysContext _context;

        public SeedingService(BeachSysContext context) {

            _context = context;
        }

        public void Seed() {

            if (_context.Usuario.Any() || _context.Armario.Any()) {
                return;
            }

            Usuario root = new Usuario(1, "root", "11111111111", "franklinmacedo5115@gmail.com", "Root.232");
            root.IsRoot = true;
            Armario a1 = new Armario(1, "Piatã", -13.1522, -41.7683);

            _context.Usuario.Add(root);

            _context.Armario.Add(a1);
            _context.SaveChanges();
        
        }
    }
}