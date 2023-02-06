using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Infrastructure.Repository.UserRepositories;

namespace InnoGotchi.API.Infrastructure.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IFarmRepository> _farmRepository;
        private readonly Lazy<IPetRepository> _petRepository;
        private readonly Lazy<ICollaborationRepository> _collaborationRepository;
        private readonly Lazy<IBodyPartRepository> _bodyPartRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(repositoryContext));
            _farmRepository = new Lazy<IFarmRepository>(() => new
            FarmRepository(repositoryContext));
            _petRepository = new Lazy<IPetRepository>(() => new 
            PetRepository(repositoryContext));
            _collaborationRepository = new Lazy<ICollaborationRepository>(() => new
            CollaborationRepository(repositoryContext));
            _bodyPartRepository = new Lazy<IBodyPartRepository>(() => new
            BodyPartRepository(repositoryContext));
        }

        public IUserRepository User => _userRepository.Value;
        public IFarmRepository Farm => _farmRepository.Value;
        public IPetRepository Pet => _petRepository.Value;
        public ICollaborationRepository Collaboration => _collaborationRepository.Value;
        public IBodyPartRepository BodyPart => _bodyPartRepository.Value;

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
