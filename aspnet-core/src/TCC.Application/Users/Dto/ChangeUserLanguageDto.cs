using System.ComponentModel.DataAnnotations;

namespace TCC.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}