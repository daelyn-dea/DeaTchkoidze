using Forum.Domain.Comments;
using Forum.Domain.Users;
using static Forum.Domain.Topics.TopicStateEnum;
using static Forum.Domain.Topics.TopicStatusEnum;

namespace Forum.Domain.Topics
{
	public class Topic : IBaseEntity
    {
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public string Title { get; set; } = default!;
        public DbTopicState State { get; set; } = DbTopicState.Pending;
        public TopicStatus Status { get; set; } = TopicStatus.Active;
		public string UserId { get; set; } = default!;
        public string? ImageUrl { get; set; }

        //navigation property
        public virtual ICollection<Comment>? Comments { get; set; }
		public virtual User User { get; set; } = default!;
	}
}
