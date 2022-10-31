using SchoolSystem.DAL.Enums;

namespace SchoolSystem.DTO.ViewModels.Attendance
{
    public class AttendanceViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public Guid? StudentId { get; set; }
        public Guid? TeacherId { get; set; }
    }
}