namespace CatShelter.Application
{
    public interface IGetCatDetailQuery
    {
        CatDetailDto GetDetail(int id);
    }
}