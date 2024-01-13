namespace WebApplicationCSharp.Models
{
    public class Product: BaseModel 
    {
        public int Price {  get; set; }
        public int ProductGroupID { get; set; }
        public virtual ProductGroup? Group { get; set; }
        public virtual List<ProguctStorage>? Storage { get; set; }
    }
}
