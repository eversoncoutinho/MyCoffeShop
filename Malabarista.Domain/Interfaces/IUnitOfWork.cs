namespace Malabarista.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGrainRepository GrainRepository { get; }
        void Commit();
    }
}
