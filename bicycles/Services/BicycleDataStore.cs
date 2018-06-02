using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bicycles
{
    public class BicycleDataStore : IDataStore<Bicycle>
    {
        static List<Bicycle> bicycles = new List<Bicycle> {
            new Bicycle { Id = Guid.NewGuid().ToString(), Name = "Kross Hexagon 6.0", Price = 35, Picture = "https://www.kross.pl/sites/default/files/styles/bike_zoom/public/bikes/2018/mtb/hexagon_6_0_black_graphite_red_matte.png" },
                new Bicycle { Id = Guid.NewGuid().ToString(), Name = "Kross Lea 6.0", Price = 20, Picture = "https://www.kross.pl/sites/default/files/styles/bike_zoom/public/bikes/2018/mtb_woman/lea_6_0_black_pink_matte.png?itok=J0hqvmKn" },
            };

        private static BicycleDataStore Instance = null;

        private BicycleDataStore()
        {
        }

        public static BicycleDataStore getInstance() {
            if (Instance == null)
            {
                Instance = new BicycleDataStore();
            }
            return Instance;
        }

        public async Task<bool> AddAsync(Bicycle bicycle)
        {
            bicycle.Id = Guid.NewGuid().ToString();
            bicycles.Add(bicycle);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Bicycle bicycle)
        {
            var _bicycle = bicycles.Where((Bicycle arg) => arg.Id == bicycle.Id).FirstOrDefault();
            bicycles.Remove(_bicycle);
            bicycles.Add(bicycle);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var _bicycle = bicycles.Where((Bicycle arg) => arg.Id == id).FirstOrDefault();
            bicycles.Remove(_bicycle);

            return await Task.FromResult(true);
        }

        public async Task<Bicycle> GetAsync(string id)
        {
            return await Task.FromResult(bicycles.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Bicycle>> FindAllAsync(bool forceRefresh = true)
        {
            return await Task.FromResult(bicycles);
        }
    }
}
