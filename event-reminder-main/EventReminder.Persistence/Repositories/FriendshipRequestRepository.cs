﻿using System.Threading.Tasks;
using EventReminder.Application.Abstractions.Data;
using EventReminder.Domain.Friendships;
using EventReminder.Domain.Users;
using EventReminder.Persistence.Specifications;

namespace EventReminder.Persistence.Repositories
{
    /// <summary>
    /// Represents the friendship request repository.
    /// </summary>
    internal sealed class FriendshipRequestRepository : GenericRepository<FriendshipRequest>, IFriendshipRequestRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FriendshipRequestRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public FriendshipRequestRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <inheritdoc />
        public async Task<bool> CheckForPendingFriendshipRequestAsync(User user, User friend) =>
            await AnyAsync(new PendingFriendshipRequestSpecification(user, friend));
    }
}
