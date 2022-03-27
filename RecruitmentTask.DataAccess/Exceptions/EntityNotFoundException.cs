using RecruitmentTask.Infrastructure.Exceptions;

namespace RecruitmentTask.DataAccess.Exceptions
{
    public class EntityNotFoundException : CustomExceptionBase
    {
        public EntityNotFoundException(Type entityType) : base($"Entity {entityType.Name} not found in database")
        {
        }
    }
}
