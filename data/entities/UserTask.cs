using System;
using System.ComponentModel.DataAnnotations;

namespace BinlistApiWrapper.data.entities
{
    public class UserTask
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}