public interface IGameRepository
{
    Task<IEnumerable<Game>> getAllGamesAsync();
    Task createGameAsync(Game game);
    Task<Game?> getGameAsync(int idGame);
    Task updateGameAsync(Game updatedGame);
    Task deleteGameAsync(int idGame);

}
