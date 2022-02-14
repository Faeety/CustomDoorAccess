# CustomDoorAccess 1.4.1

Config Setting | Value Type | Default Value | Description
--- | --- | --- | ---
is_enabled | Bool | true | Enable or disable CustomDoorAccess.
revoke_all | Bool | false | Allow or disallow revocation of the access to all the other keycards.
scp_access | Bool | false | Allow or disallow SCPs to open doors that you set with scp_access_doors.
access_set | Dictionary | 012: 0 / INTERCOM: 5&7 | Gives access to the door with the item(s) that you set.
scp_access_doors | List | CHECKPOINT_ENT / CHECKPOINT_LCZ_A / CHECKPOINT_LCZ_B | List of the doors that SCPs can open. Only works if door is edited on the access_set config.
scp079_bypass | Bool | false | Allow or disallow SCP-079 bypass.
generator_access | List | Empty | List of item(s) that are allowed to open the generator doors. (If empty the default keycards will be used).
work_station_access | List | Empty | List of item(s) that are allowed to activate the workstation. (If empty no access will be set).
elevator_access | Dictionary | Empty | Dictionary of elevators and item(s). (If empty no access will be set).
lockers_access | Dictionary | Empty | Dictionary of locker type and item(s). (If empty the default keycards will be used or no access will be set).

```
Example:
You want the SURFACE_NUKE door to only be opened with a O5 Keycard and a Chaos Card => set revoke_all to true and add SURFACE_NUKE to access_set with the following ids 10&11 (USE & separator to add multiple items)

revoke_all: true
access_set: 
    SURFACE_NUKE: 10&11

It’s worth noting that revoke_all only revokes access to the default cards to the doors which you added with access_set.
```

**Some doors need revoke_all to work because they don’t need keycards by default!**
```
173_ARMORY,173_CONNECTOR,ESCAPE_PRIMARY,ESCAPE_SECONDARY,GR18,HID_LEFT,HID_RIGHT,LCZ_WC,SERVERS_BOTTOM,SURFACE_GATE
```

If generator_access and elevator_access are let empty, the default parameters will be used.

#### New features
```
Example:
Change generator access keycards to only guard and O5.

generator_access:
- 4&11

Example:
Change SCP locker access keycards to only scientist.

lockers_access:
  ScpPedestal: 1

Example:
Change Lift A elevator access to Scientist, Maj Scientist, Zone Manager.

elevator_access:
  SystemA: 1&2&3

Example:
Change workstation access to only guard.

work_station_access:
- 4

At the moment SCPs can bypass elevator accesses.
```
### Doors List

Doors ID | Room/Door
--- | ---
049_ARMORY | SCP-049 ARMORY DOOR
079_FIRST | SCP-079 FIRST GATE
079_SECOND | SCP-079 SECOND GATE
096 | SCP-096 CONTAINEMENT DOOR
106_BOTTOM | SCP-106 BOTTOM DOOR
106_PRIMARY | SCP-106 LEFT DOOR
106_SECONDARY | SCP-106 RIGHT DOOR
173_ARMORY | SCP-173 ARMORY DOOR
173_BOTTOM | SCP-173 FIRST DOOR (like me)
173_CONNECTOR | SCP-173 SECOND DOOR
173_GATE | SCP-173 CONTAINEMENT GATE
914 | SCP-914 CONTAINEMENT GATE
CHECKPOINT_EZ_HCZ | ENTRANCE CHECKPOINT
CHECKPOINT_LCZ_A | LCZ A CHECKPOINT
CHECKPOINT_LCZ_B | LCZ B CHECKPOINT
ESCAPE_PRIMARY | FIRST DOOR NEAR THE MTF SPAWN
ESCAPE_SECONDARY | SECOND DOOR NEAR THE SPAWN
GATE_A | GATE A
GATE_B | GATE B
GR18 | DOOR FROM EMPTY CONTAINEMENT ROOM IN LCZ
HCZ_ARMORY | HCZ ARMORY DOOR
HID | HID DOOR
HID_LEFT | HID LEFT DOOR
HID_RIGHT | HID RIGHT DOOR
INTERCOM | INTERCOM DOOR
LCZ_ARMORY | LCZ ARMORY DOOR
LCZ_CAFE | DOOR FROM THE TABLES ROOMS IN LCZ
LCZ_WC | TOILETS DOOR OR FOR AMERICANS WC
NUKE_ARMORY | NUKE ARMORY DOOR
SERVERS_BOTTOM | DOOR FROM THE SERVERS ROOM (like me)
SURFACE_GATE | DOOR BETWEEN MTF/CHAOS
SURFACE_NUKE | DOOR FROM THE NUKE AT THE SURFACE

### Items List

Description | Items ID
--- | ---
None | -1
KeycardJanitor | 0
KeycardScientist | 1
KeycardResearchCoordinator | 2
KeycardZoneManager | 3
KeycardGuard | 4
KeycardNTFOfficer | 5
KeycardContainmentEngineer | 6
KeycardNTFLieutenant | 7
KeycardNTFCommander | 8
KeycardFacilityManager | 9
KeycardChaosInsurgency | 10
KeycardO5 | 11
Radio | 12
GunCOM15 | 13
Medkit | 14
Flashlight | 15
MicroHID | 16
SCP500 | 17
SCP207 | 18
Ammo12gauge | 19
GunE11SR | 20
GunCrossvec | 21
Ammo556x45 | 22
GunFSP9 | 23
GunLogicer | 24
GrenadeHE | 25
GrenadeFlash | 26
Ammo44cal  | 27
Ammo762x39 | 28
Ammo9x19 | 29
GunCOM18 | 30
SCP018 | 31
SCP268 | 32
Adrenaline | 33
Painkillers | 34
Coin | 35
ArmorLight | 36
ArmorCombat | 37
ArmorHeavy | 38
GunRevolver | 39
GunAK | 40
GunShotgun | 41
SCP330 | 42
SCP2176 | 43
### Elevators List

Elevators ID | Description
--- | ---
GateA | Gate A Elevator
GateB | Gate B Elevator
Scp049 | SCP-049 Elevator
SystemA | Lift A Elevator
SystemB | Lift B Elevator
Nuke | Warhead Elevator

### Locker Types List

Locker Type ID | Description
--- | ---
StandardLocker | Lockers located throughout the Light and Entrance Zone
SmallWallCabinet | Locker with medkits or adrenaline
ScpPedestal | Locker with SCP subject
LargeGunLocker | Locker in Nuke and SCP-049 Armory room
