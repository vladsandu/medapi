using BusinessEntities.Character;

namespace BusinessEntities.Staff {
    public class PhysicianEntity {
        public PersonEntity Person { get; set; }
        public MedicalCenterEntity MedicalCenter { get; set; }
    }
}