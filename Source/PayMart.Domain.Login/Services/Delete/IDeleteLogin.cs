namespace PayMart.Application.Login.UseCases.Delete;

public interface IDeleteLogin
{
    Task<string?> Execute(int id);

}
