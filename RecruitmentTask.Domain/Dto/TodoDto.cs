namespace RecruitmentTask.Domain.Dto
{
    public record TodoDto(Guid Id, string Title, string Description, string CreatedDate, string DeadlineDate, bool IsExpired);
}
