namespace Malabarista.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGrainRepository GrainRepository { get; }
        ITasteRepository TasteRepository { get; }

        void Commit();
    }
}
