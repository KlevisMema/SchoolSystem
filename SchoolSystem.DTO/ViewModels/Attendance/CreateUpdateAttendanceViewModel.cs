using SchoolSystem.DAL.Enums;

namespace SchoolSystem.DTO.ViewModels.Attendance
{
    public class CreateUpdateAttendanceViewModel
    {
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public Status Status { get; set; }
    }
}