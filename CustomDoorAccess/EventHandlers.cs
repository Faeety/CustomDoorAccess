using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using MapGeneration.Distributors;
using Log = Exiled.API.Features.Log;

namespace CustomDoorAccess
{
    public class EventHandlers
    {
        private readonly CdaPlugin _plugin;
        public EventHandlers(CdaPlugin plugin) => _plugin = plugin;
        public void OnDoorInteract(InteractingDoorEventArgs ev)
        {
            var ply = ev.Player;
            if (!ev.Door.Base.gameObject.TryGetComponent(out DoorNametagExtension _)) return;
            var doorName = ev.Door.Base.gameObject.GetComponent<DoorNametagExtension>().GetName;
            var accessSet = _plugin.Config.AccessSet;
            if (accessSet.TryGetValue(doorName, out var valueName))
            {
                    string trimmedValue = valueName.Trim();
                    string[] itemIDs = trimmedValue.Split('&');
                    foreach (string eachValue in itemIDs)
                    {
                        int currentItem = (int) ply.Inventory.CurItem.TypeId;
                        if (int.TryParse(eachValue, out int itemId))
                        {
                            if(ply.IsBypassModeEnabled)
                            {
                                ev.IsAllowed = true;
                                return;
                            }
                            if (_plugin.Config.Scp079Bypass && ply.Role.Equals(RoleType.Scp079))
                            {
                                ev.IsAllowed = true;
                                return;
                            }
                            if (currentItem.Equals(itemId) && !currentItem.Equals(-1))
                            {
                                ev.IsAllowed = true;
                                return;
                            }
                            if (_plugin.Config.ScpAccess)
                            {
                                foreach (string scpAccessDoor in _plugin.Config.ScpAccessDoors)
                                {
                                    if (doorName.Equals(scpAccessDoor))
                                    {
                                        if (ply.ReferenceHub.characterClassManager.IsAnyScp())
                                        {
                                            ev.IsAllowed = true;
                                            return;
                                        }
                                    }
                                }
                            }
                            if (_plugin.Config.RevokeAll && !itemIDs.Contains(currentItem.ToString()))
                            {
                                ev.IsAllowed = false;
                                return;
                            }
                        }
                        else
                        {
                            Log.Error(valueName + " is not a int.");
                        }
                    }
            }
        }
        public void OnGeneratorUnlock(UnlockingGeneratorEventArgs ev)
        {
            if (!_plugin.Config.GeneratorAccess.Any()) return;
            var currItem = (int) ev.Player.Inventory.CurItem.TypeId;
            var configItemList = _plugin.Config.GeneratorAccess;
            ev.IsAllowed = configItemList.Contains(currItem);
            if (ev.Player.IsBypassModeEnabled) ev.IsAllowed = true;
            if (!ev.IsAllowed) ev.Player.ShowHint($"{_plugin.Translation.GeneratorCantOpen}");
            else ev.Player.ShowHint($"{_plugin.Translation.GeneratorCanOpen}");
        }
        public void OnElevatorInteraction(InteractingElevatorEventArgs ev)
        {
            var ply = ev.Player;
            var elevatorAccess = _plugin.Config.ElevatorAccess;
            string elevatorName;
            switch (ev.Lift.elevatorName)
            {
                case "GateA":
                    elevatorName = "GateA";
                    break;
                case "GateB":
                    elevatorName = "GateB";
                    break;
                case "SCP-049":
                    elevatorName = "Scp049";
                    break;
                case "ElA":
                    elevatorName = "SystemA";
                    break;
                case "ElB":
                    elevatorName = "SystemB";
                    break;
                case "ElA2":
                    elevatorName = "SystemA";
                    break;
                case "ElB2":
                    elevatorName = "SystemB";
                    break;
                default:
                    elevatorName = "Nuke";
                    break;
            }
            if(elevatorAccess.Keys.Count == 0) return;
            if (elevatorAccess.TryGetValue(elevatorName, out var elevatorValue))
            {
                string trimmedValue = elevatorValue.Trim();
                string[] itemIDs = trimmedValue.Split('&');
                foreach (var eachValue in itemIDs)
                {
                    int currentItem = (int) ply.Inventory.CurItem.TypeId;
                    if (int.TryParse(eachValue, out int itemId))
                    {
                        if(ply.IsBypassModeEnabled)
                        {
                            ev.IsAllowed = true;
                            return;
                        }
                        if (ply.ReferenceHub.characterClassManager.IsAnyScp())
                        {
                            ev.IsAllowed = true;
                            return;
                        }
                        if (currentItem.Equals(itemId) && !currentItem.Equals(-1))
                        {
                            ply.ShowHint($"{_plugin.Translation.ElevatorCanUse}");
                            ev.IsAllowed = true;
                            return;
                        }
                        if (!itemIDs.Contains(currentItem.ToString()))
                        {
                            ply.ShowHint($"{_plugin.Translation.ElevatorCantUse}");
                            ev.IsAllowed = false;
                            return;
                        }
                    }
                    else
                    {
                        Log.Error(elevatorValue + " is not a int.");
                    }
                }
            }
        }
        internal void OnWorkstationUse(ActivatingWorkstationEventArgs ev)
        {
            if (!_plugin.Config.WorkStationAccess.Any()) return;
            var currItem = (int)ev.Player.Inventory.CurItem.TypeId;
            var configItemList = _plugin.Config.WorkStationAccess;
            ev.IsAllowed = configItemList.Contains(currItem);
            if (ev.Player.IsBypassModeEnabled) ev.IsAllowed = true;
            if (!ev.IsAllowed) ev.Player.ShowHint($"{_plugin.Translation.WorkstationCantActivate}");
            else ev.Player.ShowHint($"{_plugin.Translation.WorkstationCanActivate}");
        }
        internal void OnLockerUse(InteractingLockerEventArgs ev)
        {
            var ply = ev.Player;
            var lockerAccess = _plugin.Config.LockersAccess;
            string lockerType;
            switch (ev.Locker.StructureType.ToString())
            {
                case "LargeGunLocker":
                    lockerType = "LargeGunLocker";
                    break;
                case "ScpPedestal":
                    lockerType = "ScpPedestal";
                    break;
                case "SmallWallCabinet":
                    lockerType = "SmallWallCabinet";
                    break;
                default:
                    lockerType = "StandardLocker";
                    break;
            }
            if (lockerAccess.Keys.Count == 0) return;
            if (lockerAccess.TryGetValue(lockerType, out var lockersValue))
            {
                string trimmedValue = lockersValue.Trim();
                string[] itemIDs = trimmedValue.Split('&');
                foreach (var eachValue in itemIDs)
                {
                    int currentItem = (int)ply.Inventory.CurItem.TypeId;
                    if (int.TryParse(eachValue, out int itemId))
                    {
                        if (ply.IsBypassModeEnabled)
                        {
                            ev.IsAllowed = true;
                            return;
                        }
                        if (currentItem.Equals(itemId) && !currentItem.Equals(-1))
                        {
                            ply.ShowHint($"{_plugin.Translation.LockerCanOpen}");
                            ev.IsAllowed = true;
                            return;
                        }
                        if (!itemIDs.Contains(currentItem.ToString()))
                        {
                            ply.ShowHint($"{_plugin.Translation.LockerCantOpen}");
                            ev.IsAllowed = false;
                            return;
                        }
                    }
                    else Log.Error(lockersValue + " is not a int.");
                }
            }
        }
    }
}