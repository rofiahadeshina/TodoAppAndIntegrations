using System.ComponentModel.DataAnnotations;

namespace BinlistApiWrapper.models
{
    public class dtos
    {
        
    }

    public class CreateTaskDTO {
        [Required]
        public string Description { get; set; }
    }

    public class UpdateTaskDTO {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}