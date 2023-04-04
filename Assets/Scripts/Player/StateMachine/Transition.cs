using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _state;

    public bool NeedTransit { get; protected set; } = false;
    public State State => _state;

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
