using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace URLShort.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [NotNull]
        public string Login {  get; set; }

        [Required]
        [NotNull]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public bool isAdmin { get; set; }

    }
}
