using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsToWeather.Common.Caching
{
    public interface IFilterCasheService
    {
        Task<Dictionary<string, int>> GetFilterDictionary(string type, string paramOne, string paramTwo, string paramThree);
    }
}
