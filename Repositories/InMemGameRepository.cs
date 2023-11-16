public class InMemGameRepository : IGameRepository

{
    private readonly List<Game> games = new() {
     new Game() {
                idGame=1,
                nameGame="Gear of war",
                genre="shooter",
                price=25000,
                releasedDate=new DateTime(2006, 04, 15),
                imageUri="https://placehold.co/100"
                },
    new Game() {
                idGame=2,
                nameGame="Call of duty 4",
                genre="shooter",
                price=16000,
                releasedDate=new DateTime(2007, 06, 13),
                imageUri="https://placehold.co/100"
                },
    new Game() {
                idGame=3,
                nameGame="God of war",
                genre="Beat-them-all",
                price=19000,
                releasedDate=new DateTime(2007, 03, 09),
                imageUri="https://placehold.co/100"
                },
    new Game() {
                idGame=4,
                nameGame="Devil may cry 4",
                genre="Hack & Slash",
                price=21000,
                releasedDate=new DateTime(2008, 10, 05),
                imageUri="https://placehold.co/100"
                },
 new Game() {
                idGame=5,
                nameGame="PES 2012",
                genre="Sport",
                price=10000,
                releasedDate=new DateTime(2011, 10, 18),
                imageUri="https://placehold.co/100"
                },

};

    public async Task<IEnumerable<Game>> getAllGamesAsync()
    {
        return await Task.FromResult(games);
    }
    public async Task<Game?> getGameAsync(int idGame)
    {
        return await Task.FromResult(games.Find(game => game.idGame == idGame));
    }

    public async Task createGameAsync(Game game)
    {
        game.idGame = games.Max(game => game.idGame) + 1;
        games.Add(game);
        await Task.CompletedTask;
    }

    public async Task updateGameAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.idGame == updatedGame.idGame);
        games[index] = updatedGame;
        await Task.CompletedTask;
    }
    public async Task deleteGameAsync(int idGame)
    {
        var index = games.FindIndex(game => game.idGame == idGame);
        games.RemoveAt(index);
        await Task.CompletedTask;

    }
}
