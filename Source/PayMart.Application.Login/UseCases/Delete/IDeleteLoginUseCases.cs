namespace PayMart.Application.Login.UseCases.Delete;

public interface IDeleteLoginUseCases
{
    Task<string?> Execute(int id);

}
