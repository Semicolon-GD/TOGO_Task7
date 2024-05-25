using System;
using System.Collections.Generic;


public enum EventList
{
    GameStarted,
    GameFailed,
    GameWon,
    GameStateChange,
    UpdateScoreText,
    OnCollectiblePickup,
    OnObstacleHit,
    OnGateCrossed,
    OnHorizontalDrag,
    OnFinishLineCrossed,
}