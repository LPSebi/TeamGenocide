﻿using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Linq;
using TeamGenocide.API.Entities;

namespace TeamGenocide.Events
{
    internal class PlayerEvents
    {
        private readonly Config _config;

        public PlayerEvents(Config config)
        {
            _config = config;
            Exiled.Events.Handlers.Player.ChangingRole += OnChangingRole;
        }

        ~PlayerEvents()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= OnChangingRole;
        }

        private void OnChangingRole(ChangingRoleEventArgs e)
        {
            if (e.Player.Role.Team == Team.RIP)
                return;

            if (!_config.Announcements.TryGetValue(e.Player.Role.Team, out Announcement announcement))
                return;

            if (Player.List.Count(x => x.Role.Team == e.Player.Role.Team) <= 1)
                announcement.AnnounceDeath();
        }
    }
}
