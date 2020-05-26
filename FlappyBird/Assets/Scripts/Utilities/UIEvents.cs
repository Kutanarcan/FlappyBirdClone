using System;

public static class UIEvents
{
    public static event Action OnScoreChanged;

    public static void OnScoreChangedFunction()
    {
        OnScoreChanged?.Invoke();
    }
}
