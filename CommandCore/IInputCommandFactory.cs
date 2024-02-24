using CommandCore;

namespace Employees.Starter;

public interface IInputCommandFactory
{
    List<IInputAction> GetAllActions();
}