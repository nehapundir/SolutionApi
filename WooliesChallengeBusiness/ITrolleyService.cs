using WooliesChallenge.Business.Models;

namespace WooliesChallenge.Business
{
    public interface ITrolleyService
    {
        decimal CalculatePrice(TrolleyDto trolley);
    }
}
