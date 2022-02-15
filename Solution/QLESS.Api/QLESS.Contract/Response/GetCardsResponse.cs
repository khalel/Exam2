using QLESS.Contract.Model;
using System.Collections.Generic;

namespace QLESS.Contract.Response
{
    public class GetCardsResponse
    {
        public IEnumerable<Card> Cards { get; set; }
    }
}
