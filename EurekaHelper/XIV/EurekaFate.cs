﻿using System.Numerics;
using System;

namespace EurekaHelper.XIV
{
    public class EurekaFate
    {
        public ushort FateId { get; private set; }
        public ushort? TrackerId { get; private set; }
        public ushort TerritoryId { get; private set; }
        public ushort MapId { get; private set; }
        public string FateName { get; private set; }
        public string BossName { get; private set; }
        public Vector2 FatePosition { get; private set; }
        public string SpawnedBy { get; private set; }
        public EurekaWeather SpawnRequiredWeather { get; private set; }
        public EurekaWeather SpawnByRequiredWeather { get; private set; }
        public EurekaElement BossElement { get; private set; }
        public EurekaElement SpawnByElement { get; private set; }
        public bool SpawnByRequiredNight { get; private set; }
        private long KilledAt { get; set; }
        public byte FateProgress { get; set; }
        public bool IncludeInTracker { get; private set; }
        public bool IsBunnyFate { get; private set; }

        public EurekaFate(ushort fateId, ushort? trackerId, ushort territoryId, ushort mapId, string fateName, string bossName, Vector2 fatePosition, string spawnedBy, EurekaWeather spawnRequiredWeather, EurekaWeather spawnByRequiredWeather, EurekaElement bossElement, EurekaElement spawnByElement, bool spawnByRequiredNight, bool includeInTracker = true, bool isBunnyFate = false)
        {
            FateId = fateId;
            TrackerId = trackerId;
            TerritoryId = territoryId;
            MapId = mapId;
            FateName = fateName;
            BossName = bossName;
            FatePosition = fatePosition;
            SpawnedBy = spawnedBy;
            SpawnRequiredWeather = spawnRequiredWeather;
            SpawnByRequiredWeather = spawnByRequiredWeather;
            BossElement = bossElement;
            SpawnByElement = spawnByElement;
            SpawnByRequiredNight = spawnByRequiredNight;
            KilledAt = -1;
            IncludeInTracker = includeInTracker;
            IsBunnyFate = isBunnyFate;
        }

        public bool IsPopped() => KilledAt != -1 && (KilledAt + 7200000) > DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public DateTime GetPoppedTime() => EorzeaTime.Zero.AddMilliseconds(KilledAt).ToLocalTime();

        public TimeSpan GetRespawnTimeleft() => TimeSpan.FromMilliseconds(KilledAt + 7200000 - DateTimeOffset.Now.ToUnixTimeMilliseconds());

        public void ResetKill() => KilledAt = -1;

        public void SetKill(long time) => KilledAt = time;
    }
}
