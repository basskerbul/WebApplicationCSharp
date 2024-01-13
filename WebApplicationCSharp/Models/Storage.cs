namespace WebApplicationCSharp.Models
{
    public class Storage : BaseModel
    {
        public virtual List<Product>? Products { get; set; }
        public int Count {  get; set; }
    }
}
