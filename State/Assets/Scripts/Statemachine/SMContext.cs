using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SMContext : MonoBehaviour
{
    public State CurrentState { get; private set; }
    private bool _isTransitioning;

    public Stack<State> History = new();

    public void HandleInput() => CurrentState.HandleInput();
    public void CheckState() => CurrentState.CheckState();
    public void FixedUpdate() => CurrentState.FixedUpdate();

    public void ChangeStateTo(State newState) => StartCoroutine(TransitionTo(newState));

    private IEnumerator TransitionTo(State newState)
    {
        if (CurrentState == newState || _isTransitioning) yield break;

        _isTransitioning = true;

        if (!History.Contains(newState)) History.Push(newState);
        if (CurrentState != null) yield return StartCoroutine(CurrentState.Exit());

        CurrentState = newState;
        StartCoroutine(CurrentState.Enter());

        _isTransitioning = false;
    }
}
