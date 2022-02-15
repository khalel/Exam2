using QLESS.Contract.Request;

namespace QLESS.Controller.Service
{
    public interface ICardService
    {
        object GetCards();
        object AddCard();
        object GetCardBySerialNumber(string serialNumber);
        object CardRegister(PostCardRegisterRequest request);
        object CardUse(string serialNumber);
        object CardReload(string serialNumber, int amount);
    }
}
