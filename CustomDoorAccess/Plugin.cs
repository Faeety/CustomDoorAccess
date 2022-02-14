using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Log = Exiled.API.Features.Log;

namespace CustomDoorAccess
{
    public class CdaPlugin : Plugin<Configs, Trasnlation>
    {
        public EventHandlers _eventHandlers;
        public override string Author { get; } = "Faety";
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 3);
        public override string Prefix { get; } = "cda";
        public override string Name { get; } = "CustomDoorAccess";
        public override Version Version { get; } = new Version(1, 4, 1);
        public override void OnEnabled()
        {
            if (!Config.IsEnabled)
            {
                Log.Info("CustomDoorAccess is disabled via configs. It will not be loaded.");
                return;
            }
            _eventHandlers = new EventHandlers(this);
            Player.InteractingDoor += _eventHandlers.OnDoorInteract;
            Player.UnlockingGenerator += _eventHandlers.OnGeneratorUnlock;
            Player.InteractingElevator += _eventHandlers.OnElevatorInteraction;
            Player.InteractingLocker += _eventHandlers.OnLockerUse;
            Player.ActivatingWorkstation += _eventHandlers.OnWorkstationUse;
        }
        public override void OnDisabled()
        {
            Player.InteractingDoor -= _eventHandlers.OnDoorInteract;
            Player.UnlockingGenerator -= _eventHandlers.OnGeneratorUnlock;
            Player.InteractingElevator -= _eventHandlers.OnElevatorInteraction;
            Player.InteractingLocker -= _eventHandlers.OnLockerUse;
            Player.ActivatingWorkstation -= _eventHandlers.OnWorkstationUse;
            _eventHandlers = null;
        }
    }
}