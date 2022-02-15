using AutoMapper;

namespace QLESS.Domain.Mapper
{
    public class CardMapper : Profile
    {
        public CardMapper()
        {
            CreateMap<Model.Card, Contract.Model.Card>();
        }
    }
}
