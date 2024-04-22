using Forum.Domain.Topics;
using Forum.Domain.Users;

namespace Forum.Domain.Comments
{
	public class Comment : IBaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Title { get; set; } = default!;
		public string UserId { get; set; } = default!;
		public int TopicId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual Topic Topic { get; set; } = default!;
	}
}
