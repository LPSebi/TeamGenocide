﻿using Exiled.API.Features;
using System;
using TeamGenocide.Events;

namespace TeamGenocide
{
    public class Plugin : Plugin<Config>
    {
        private PlayerEvents _playerEvents;

        public override string Name { get; } = "TeamGenocide";
        public override string Author { get; } = "Heisenberg3666 / Recompiled by fl0w#1957";
        public override Version Version { get; } = new Version(2, 2, 2, 0);
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);

        public override void OnEnabled()
        {
            _playerEvents = new PlayerEvents(Config);

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _playerEvents = null;

            base.OnDisabled();
        }
    }
}
