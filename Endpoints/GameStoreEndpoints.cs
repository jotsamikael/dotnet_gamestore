
using GameStore.Api.Entities;

public static class GameStoreEndpoints
{
    const string GetGameEndpoint = "GetGame";

    public static RouteGroupBuilder MapGameStoreEndPoint(this IEndpointRouteBuilder routes)

    {

        var group = routes.MapGroup("/game-store").WithParameterValidation();

        group.MapGet("/all-games", async (IGameRepository repository) => (await repository.getAllGamesAsync()).Select(game => game.AsDto()));

        //Get game by id
        group.MapGet("/game-by-id/{idGame}", async (IGameRepository repository, int idGame) =>
        {
            Game? game = await repository.getGameAsync(idGame);
            if (game is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(game.AsDto());
        }).WithName(GetGameEndpoint);

        group.MapPost("/post-game", async (IGameRepository repository, CreateGameDto createGameDto) =>
            {
                Game game = new()
                {
                    nameGame = createGameDto.nameGame,
                    genre = createGameDto.genre,
                    price = createGameDto.price,
                    releasedDate = createGameDto.releasedDate,
                    imageUri = createGameDto.imageUri
                };

                await repository.createGameAsync(game);
                return Results.CreatedAtRoute(GetGameEndpoint, new { idGame = game.idGame }, game);

            });

        group.MapPut("update-game/{idGame}", async (IGameRepository repository, int idGame, updateGameDto updateGameDto) =>
        {
            Game? currentGame = await repository.getGameAsync(idGame);
            if (currentGame is null)
            {
                return Results.NotFound();
            }
            currentGame.nameGame = updateGameDto.nameGame;
            currentGame.price = updateGameDto.price;
            currentGame.releasedDate = updateGameDto.releasedDate;
            currentGame.genre = updateGameDto.genre;
            currentGame.imageUri = updateGameDto.imageUri;

            await repository.updateGameAsync(currentGame);
            return Results.Ok(updateGameDto);
        });

        group.MapDelete("/delete-game/{idGame}", async (IGameRepository repository, int idGame) =>
        {
            Game? game = await repository.getGameAsync(idGame);
            if (game is not null)
            {
                await repository.deleteGameAsync(idGame);
            }
            return Results.NoContent();
        });

        return group;
    }


}
