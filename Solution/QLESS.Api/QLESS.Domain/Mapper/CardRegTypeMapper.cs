using AutoMapper;

namespace QLESS.Domain.Mapper
{
    public class CardRegTypeMapper : Profile
    {
        public CardRegTypeMapper()
        {
            CreateMap<Model.CardRegType, Contract.Model.CardRegType>();
        }
    }
}
