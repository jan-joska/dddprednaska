namespace CatShelter.Domain.CatEvidence
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}