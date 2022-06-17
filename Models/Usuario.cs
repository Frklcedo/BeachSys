using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeachSys.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; } 
        [Required]
        public string Nome { get; set; }
        [Required]
        [RegularExpression("^[0-9]{11}", ErrorMessage = "Escreva um cpf válido")]
        public string Cpf { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Insira um e-mail válido")]
        public string Senha { get; set; }
        public virtual Compartimento Compartimento { get; set; }
        public Usuario(int usuarioId,string nome, string cpf, string email, string senha){
            UsuarioId = usuarioId;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Senha = senha;
        }
    }
}