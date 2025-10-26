namespace api.Interfaces;

public interface IMemberRepository
{
    public Task<IEnumerable<AppUser>> GetAllAsync(CancellationToken cancellationToken);
    public Task<MemberDto?> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
}
