namespace api.Models;
public record Follower
(
    string FollowerId,
    string FolllowingId,
    DateTime CreatedAt
);
