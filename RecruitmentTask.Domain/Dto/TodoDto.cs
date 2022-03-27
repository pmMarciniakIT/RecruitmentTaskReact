namespace RecruitmentTask.Domain.Dto
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadlineDate { get; set; }
    }
}
