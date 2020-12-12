using System.Threading.Tasks;

namespace RainbowApp.Application.Model
{
    //scaffold-dbcontext "Server=rainbow-bridge.co3a9rtnyqgv.ap-northeast-2.rds.amazonaws.com,1433;Database=rainbow;Uid=rainbowsa;Pwd=anwlroakstp;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model

    public interface IRainbowContext
    {
        string GetDbConnection();
        Task<int> SaveChangesAsync();
    }

        // public string GetDbConnection()
        // {
        //     return base.Database.GetDbConnection().ConnectionString;
        // }

        // public async Task<int> SaveChangesAsync()
        // {
        //     return await base.SaveChangesAsync();
        // }
}
