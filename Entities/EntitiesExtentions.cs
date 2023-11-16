
namespace GameStore.Api.Entities
{
    public static class EntitiesExtentions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto(
            game.idGame,
            game.nameGame,
            game.genre,
            game.price,
            game.releasedDate,
            game.imageUri
            );
        }
    }
}