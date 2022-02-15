using AutoMapper;

namespace QLESS.Domain.Mapper
{
    public class CardLoadHistMapper : Profile
    {
        public CardLoadHistMapper()
        {
            CreateMap<Model.CardLoadHist, Contract.Model.CardLoadHist>();
        }
    }
}
