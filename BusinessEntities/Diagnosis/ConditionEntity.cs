namespace BusinessEntities.Diagnosis {
    public class ConditionEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConditionCategoryEntity ConditionCategory { get; set; }
        public DiagnosisTypeEntity Type { get; set; }
    }
}