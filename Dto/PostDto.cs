namespace MvcGuestBook.Dto;

public class PostDto
{
    public Guid Id { get; set; }

    public string? PosterName { get; set; }

    public string? Text { get; set; }
}