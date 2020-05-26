using System;

public static class PlayerEvents
{
    public static event Action OnPlayerHitObstacle;

    public static void OnPlayerHitObstacleFunction()
    {
        OnPlayerHitObstacle?.Invoke();
    }
}
