using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace meii.Api.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage ="O Campo {0} é obrigatório.")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage ="O campo {0} é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 4)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas informada não confere.")]
        public string ConfirmPassword { get; set; }

    }


    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório.")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 4)]
        public string Password { get; set; }

    }
}
