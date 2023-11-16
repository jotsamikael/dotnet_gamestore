using System.ComponentModel.DataAnnotations;

public record GameDto
(
int idGame,
string nameGame,
string genre,
int price,
DateTime releasedDate,
string imageUri
);

public record CreateGameDto
(

[Required][StringLength(50)] string nameGame,
[Required][StringLength(50)] string genre,
[Required] DateTime releasedDate,
[Range(0, 150000)] int price,
[Url][StringLength(1000)] string imageUri
);

public record updateGameDto
(

[Required][StringLength(50)] string nameGame,
[Required][StringLength(50)] string genre,
[Required] DateTime releasedDate,
[Range(0, 150000)] int price,
[Url][StringLength(1000)] string imageUri
);