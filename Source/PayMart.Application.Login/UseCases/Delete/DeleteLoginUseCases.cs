using AutoMapper;
using PayMart.Domain.Login.Interface.DataBase;
using PayMart.Domain.Login.Interface.Login.Delete;

namespace PayMart.Application.Login.UseCases.Delete;

public class DeleteLoginUseCases : IDeleteLoginUseCases
{
    private readonly IDelete _delete;
    private readonly ICommit _commit;
    private readonly IMapper _mapper;

    public DeleteLoginUseCases(IDelete delete,
        ICommit commit,
        IMapper mapper)
    {
        _delete = delete;
        _commit = commit;
        _mapper = mapper;
    }

    public async Task Execute(int id)
    {
        await _delete.Delete(id);

        await _commit.Commit();
    }
}
