﻿using System;
using EventReminder.Application.Abstractions.Messaging;
using EventReminder.Domain.Invitations.DomainEvents;
using Newtonsoft.Json;

namespace EventReminder.Application.Invitations.InvitationRejected
{
    /// <summary>
    /// Represents the integration event that is raised when an invitation is rejected.
    /// </summary>
    public sealed class InvitationRejectedIntegrationEvent : IIntegrationEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationRejectedIntegrationEvent"/> class.
        /// </summary>
        /// <param name="invitationRejectedDomainEvent">The invitation rejected domain event.</param>
        internal InvitationRejectedIntegrationEvent(InvitationRejectedDomainEvent invitationRejectedDomainEvent) =>
            InvitationId = invitationRejectedDomainEvent.Invitation.Id;

        [JsonConstructor]
        private InvitationRejectedIntegrationEvent(Guid invitationId) => InvitationId = invitationId;

        /// <summary>
        /// Gets the invitation identifier.
        /// </summary>
        public Guid InvitationId { get; }
    }
}
