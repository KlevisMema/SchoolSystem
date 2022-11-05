namespace SchoolSystem.DTO.ViewModels.Clasroom
{
    public class CreateUpdateClasroomViewModel
    {
        public int Grade { get; set; }
        public Guid TeacherId { get; set; }
        public Guid TimeTableId { get; set; }
    }
}
