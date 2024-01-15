namespace Versta24.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(OrdersDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
