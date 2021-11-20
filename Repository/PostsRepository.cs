using MvcGuestBook.Dto;

namespace MvcGuestBook.Repository;

public class PostsRepository : BaseRepository<PostDto>
{
    private Dictionary<Guid, PostDto> _posts = new();

    public override void Insert(PostDto item)
    {
        _posts.Add(item.Id, item);
    }

    public override PostDto Get(Guid id)
    {
        if (!_posts.ContainsKey(id))
            return null;

        return _posts[id];
    }

    public override List<PostDto> GetAll()
    {
        var values = _posts.Values.ToList();

        return values;
    }
}