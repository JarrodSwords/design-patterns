namespace DesignPatterns.Sandbox;

public interface IInfoTurnUnitOfWorkFactory
{
    IDisposable StartUnitOfWork();
}
