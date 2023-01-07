using Net_Core_API_7.ViewModels;

namespace Net_Core_API_7.Services
{
    public interface IPetService
    {
        Task<List<PetVm>> GetAll();
        Task<PetVm> GetById(int petId);
        Task<int> PetCreat(PetCreatVm vm);
        Task<int> PetUpdate(PetUpdateVm vm);
        Task<int> PetDelete(int petId);

    }
}
