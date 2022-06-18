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
        [RegularExpression(@"^[0-9]{11}", ErrorMessage = "Escreva um cpf válido")]
        public string Cpf { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Insira um e-mail válido")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&.-_])?[A-Za-z\\d\\.\\-_@$!%*#?&]{6,12}$")]
        public string Senha { get; set; }
        public bool IsRoot { get; set; }
        public virtual Compartimento Compartimento { get; set; }
        public Usuario(){
            IsRoot = false;
        }
        public Usuario(int usuarioId,string nome, string cpf, string email, string senha){
            UsuarioId = usuarioId;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Senha = senha;
            IsRoot = false;
        }
    }
}