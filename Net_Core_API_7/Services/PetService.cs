using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using Net_Core_API_7.Models;
using Net_Core_API_7.ViewModels;

namespace Net_Core_API_7.Services
{
    public class PetService : IPetService
    {
        private readonly PetDbContext _context;
        public PetService(PetDbContext context)
        {
            _context = context;
        }
        public async Task<List<PetVm>> GetAll()
        {
            var query = from p in _context.Pets
                        select new { p };
            var data = await query.Select(x => new PetVm()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                Description = x.p.Description,
            }).ToListAsync();
            return data;
        }

        public async Task<PetVm> GetById(int petId)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet == null) return null;

            var vm = new PetVm()
            {
                Id = pet.Id,
                Name = pet.Name,
                Description = pet.Description,
                Place = pet.Place,

            };
            return vm;
        }

        public async Task<int> PetCreat(PetCreatVm vm)
        {
            var pet = new Pet()
            {
                Name = vm.Name,
                Description = vm.Description,
                Place = vm.Place
            };
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet.Id;
        }

        public async Task<int> PetDelete(int petId)
        {
            var pet = await _context.Pets.FindAsync(petId);
            if (pet == null) throw new BackendException($"Cannot find a product with id: {petId}");
            _context.Pets.Remove(pet);
            return await _context.SaveChangesAsync();

        }

      

        public async Task<int> PetUpdate(PetUpdateVm vm)
        {
            var pet = await _context.Pets.FindAsync(vm.Id);
            if (pet == null) throw new BackendException($"Cannot find a product with id: {vm.Id}");
            pet.Name = vm.Name;
            pet.Description = vm.Description;
            pet.Place = vm.Place;
            return await _context.SaveChangesAsync();

        }
    }
}
