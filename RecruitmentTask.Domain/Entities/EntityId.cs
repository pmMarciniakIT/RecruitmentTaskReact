using System.ComponentModel.DataAnnotations;

namespace RecruitmentTask.Domain.Entities
{
    public abstract class EntityId
    {
        [Key]
        public Guid Id { get; set; }
    }
}
