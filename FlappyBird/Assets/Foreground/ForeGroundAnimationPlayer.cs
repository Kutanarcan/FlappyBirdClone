using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeGroundAnimationPlayer : MonoBehaviour
{
    Animator anim;

    int paramGameStart = Animator.StringToHash("GameStart");

    void Awake()
    {
        anim = GetComponent<Animator>();
        GameEvents.OnGameStartButtonPressed += GameEvents_OnGameStartButtonPressed;
        GameEvents.OnGameOvered += GameEvents_OnGameOvered;
    }

    private void GameEvents_OnGameOvered()
    {
        IsGameStarted = false;
    }

    private void GameEvents_OnGameStartButtonPressed()
    {
        IsGameStarted = true;
    }

    public bool IsGameStarted
    {
        get
        {
            return anim.GetBool(paramGameStart);
        }

        set
        {
            anim.SetBool(paramGameStart, value);
        }
    }

    void OnDestroy()
    {
        GameEvents.OnGameStartButtonPressed -= GameEvents_OnGameStartButtonPressed;
        GameEvents.OnGameOvered -= GameEvents_OnGameOvered;
    }
}
