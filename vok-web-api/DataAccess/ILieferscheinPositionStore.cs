using System.Collections.Generic;
using System.Threading.Tasks;
using vok_web_api.Model;

namespace vok_web_api.DataAccess
{
    public interface ILieferscheinPositionStore
    {
        Task<IEnumerable<LieferscheinPosition>> GetByLieferscheinIDsAsync(IEnumerable<int> lieferscheinIDs);
    }
}
