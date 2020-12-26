using Microsoft.EntityFrameworkCore;

namespace MoveMe.WebAPI.Database
{
    public class Data
    {
       public static void Seed(MoveMeContext context)
        {
            context.Database.Migrate();
        }
    }
}
