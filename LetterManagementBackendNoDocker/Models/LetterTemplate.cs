namespace LetterManagementBackendNoDocker.Models
{
    public class LetterTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FieldAndValue> FieldAndValues { get; set; }
    }

    public class FieldAndValue
    {
        public int Order { get; set; }

        public bool IsActive { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
