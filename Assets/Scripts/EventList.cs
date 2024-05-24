using System;
using System.Collections.Generic;


public enum EventList
{
    GameStarted,
    GameFailed,
    GameWon,
    GameStateChange,
    CalculateScore,
    OnCollectiblePickup,
    OnObstacleHit,
    OnGateCrossed,
    OnHorizontalDrag,
    OnFinishLineCrossed,
}