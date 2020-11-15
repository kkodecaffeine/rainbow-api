using System;
using System.Threading.Tasks;

namespace RainbowApp.Application.Model
{
    public interface IRainbowContext
    {
        string GetDbConnection();
        Task<int> SaveChangesAsync();
    }
}
