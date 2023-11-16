using Microsoft.EntityFrameworkCore;

public class EntityFrameworkGamesRepository : IGameRepository
{
    private readonly GameStoreContext dbContext;
    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<Game>> getAllGamesAsync()
    {
        return await dbContext.Games.AsNoTracking().ToListAsync();
    }
    public async Task<Game?> getGameAsync(int idGame)
    {
        return await dbContext.Games.FindAsync(idGame);
    }
    public async Task createGameAsync(Game game)
    {
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();

    }
    public async Task updateGameAsync(Game updatedGame)
    {
        dbContext.Games.Update(updatedGame);
        await dbContext.SaveChangesAsync();
    }

    public async Task deleteGameAsync(int idGame)
    {
        await dbContext.Games.Where(game => game.idGame == idGame).ExecuteDeleteAsync();
    }



}
