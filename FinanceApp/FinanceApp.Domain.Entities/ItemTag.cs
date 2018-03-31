namespace FinanceApp.Domain.Entity
{
    public class ItemTag : BaseModel
    {
        public string Value { get; set; }

        // Foreign Key
        public long TagTypeId { get; set; }
        // Navigation Property
        public virtual TagType TagType { get; set; }
    }
}
