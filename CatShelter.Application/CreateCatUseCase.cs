using CatShelter.Domain.CatEvidence;

namespace CatShelter.Application
{

    public class GetListUseCase
    {
        
    }

    public class CreateCatUseCase
    {
        private readonly ICatRepository _catRepository;
        private readonly IUnitOfWorkFactory _uowFactory;

        public CreateCatUseCase(IUnitOfWorkFactory uowFactory, ICatRepository catRepository)
        {
            _uowFactory = uowFactory;
            _catRepository = catRepository;
        }

        public int CreateCat(CreateCatDto dto)
        {
            var c = new Cat(dto.Name);
            using (var uow = _uowFactory.Create())
            {
                _catRepository.Inject(uow);
                _catRepository.Save(c);
                uow.Flush();
            }
            return c.Id;
        }
    }
}