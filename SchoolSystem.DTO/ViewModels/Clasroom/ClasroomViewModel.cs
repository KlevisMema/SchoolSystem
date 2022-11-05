namespace SchoolSystem.DTO.ViewModels.Clasroom
{
    public class ClasroomViewModel
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public Guid TeacherId { get; set; }
        public Guid TimeTableId { get; set; }
    }
}