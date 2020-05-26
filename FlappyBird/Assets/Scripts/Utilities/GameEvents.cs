using System;
public static class GameEvents 
{
    public static event Action OnGameStartButtonPressed;
    public static event Action OnGameOvered;

    public static void OnGameStartButtonPressedFunction()
    {
        OnGameStartButtonPressed?.Invoke();
    }

    public static void OnGameOveredFunction()
    {
        OnGameOvered?.Invoke();
    }
}
