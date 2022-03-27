using System.ComponentModel.DataAnnotations;

namespace RecruitmentTask.Domain.Entities
{
    public class Todo : EntityId
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime DeadlineDate { get; set; }

    }
}
