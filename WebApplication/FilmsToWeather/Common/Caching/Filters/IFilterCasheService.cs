using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsToWeather.Common.Caching
{
    public interface IFilterCasheService
    {
        // давай два отдельных метода заведем и избавимся от параметра типа
        // плюс удали лишние странные параметры
        Task<Dictionary<string, int>> GetFilterDictionary(string type, string paramOne, string paramTwo, string paramThree);
    }
}
