using DataLayer;

public class ProductRepository : IProductRepository
{
    private readonly string _connStr;

    public ProductRepository(string connStr)
    {
        _connStr = connStr;
    }

    public List<Product> GetAll()
    {
        using var context = new DataClassesSQLDataContext(_connStr);
        return context.Products.ToList();
    }

    public void Add(Product p)
    {
        using var context = new DataClassesSQLDataContext(_connStr);
        context.Products.InsertOnSubmit(p);
        context.SubmitChanges();
    }

    public void Update(Product p)
    {
        using var context = new DataClassesSQLDataContext(_connStr);
        var item = context.Products.FirstOrDefault(x => x.Id == p.Id);
        if (item != null)
        {
            item.Name = p.Name;
            item.Price = p.Price;
            item.Quantity = p.Quantity;
            context.SubmitChanges();
        }
    }

    public void Delete(int id)
    {
        using var context = new DataClassesSQLDataContext(_connStr);
        var item = context.Products.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            context.Products.DeleteOnSubmit(item);
            context.SubmitChanges();
        }
    }
}
