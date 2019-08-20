using System.Collections.Generic;
using System.Linq;

namespace Spy.Library.Repository
{
    public class SpyRepository : ISpyRepository
    {
        public int[] GetCodeName(string spyName)
        {
            var result = GetSpies().Where(s => s.Name == spyName).Select(a => a.CodeName).FirstOrDefault();
            return result;
        }

        private static IEnumerable<Spy> GetSpies()
        {
            return new List<Spy>()
            {
                new Spy() {Name = "James Bond", CodeName = new[] {0, 0, 7}},
                new Spy() {Name = "Ethan Hunt", CodeName = new[] {3, 1, 4}}
            };
        }
    }
}