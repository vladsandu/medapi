namespace BusinessEntities.Staff
{
    public class StaffEntity {
        public int StaffId { get; set; }
        public int ReferenceId { get; set; }
        public StaffTypeEntity StaffType { get; set; }
    }
}