using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLShort.Models
{
    public class URLModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public string UrlLong    { get; set; }
        public string UserId {  get; set; }
        public DateTime CreationDate {  get; set; }
        public ApplicationUser User { get; set; } = null!;
        public bool IsRemoved    { get; set; }
    }
}
