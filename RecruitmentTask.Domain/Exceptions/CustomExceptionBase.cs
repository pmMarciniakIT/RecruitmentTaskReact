namespace RecruitmentTask.Infrastructure.Exceptions
{
    public abstract class CustomExceptionBase : Exception
    {
        protected CustomExceptionBase(string message) : base(message)
        {

        }
    }
}
