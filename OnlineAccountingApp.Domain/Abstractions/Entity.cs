namespace OnlineAccountingApp.Domain.Abstractions
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? UpdateDate { get; set; }

        
    }
}
