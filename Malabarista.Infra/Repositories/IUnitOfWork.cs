namespace Malabarista.Infra.Repositories
{
    public interface IUnitOfWork
    {
        IGrainRepository GrainRepository { get; }
        void Commit();
    }
}
