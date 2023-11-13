using assignment_db.Services;
public class Program
{
   public static async Task Main(string[] args)
    {
        await MenuService.ShowAsync();
    }
}

