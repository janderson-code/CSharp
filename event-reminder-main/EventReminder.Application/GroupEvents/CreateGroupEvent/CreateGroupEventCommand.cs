﻿using System;
using EventReminder.Application.Abstractions.Messaging;
using EventReminder.Domain.Core.Primitives.Result;

namespace EventReminder.Application.GroupEvents.CreateGroupEvent
{
    /// <summary>
    /// Represents the create group event command.
    /// </summary>
    public sealed class CreateGroupEventCommand : ICommand<Result>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGroupEventCommand"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="name">The event name.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="dateTime">The date and time.</param>
        public CreateGroupEventCommand(Guid userId, string name, int categoryId, DateTime dateTime)
        {
            UserId = userId;
            Name = name;
            CategoryId = categoryId;
            DateTimeUtc = dateTime.ToUniversalTime();
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the category identifier.
        /// </summary>
        public int CategoryId { get; }

        /// <summary>
        /// Gets the date and time in UTC format.
        /// </summary>
        public DateTime DateTimeUtc { get; }
    }
}
