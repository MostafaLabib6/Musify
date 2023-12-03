using System.ComponentModel.DataAnnotations;

namespace Musify.MVC.Models.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is Required")] //data annotation
        public string Name { get; set; }
    }
}
