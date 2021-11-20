using MvcGuestBook.Dto;

namespace MvcGuestBook.Models;

public class GuestbookModel
{
    public List<PostDto> Posts { get; set; } = new List<PostDto>();
}