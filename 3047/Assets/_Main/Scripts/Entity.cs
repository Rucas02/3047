using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StatsSO Data => _stats;
    [SerializeField] private StatsSO _stats;
    private IMovable _movable;

    protected virtual void Awake()
    {
        _movable = GetComponent<IMovable>();
    }
    public virtual void Move(Vector3 direction)
    {
        if (_movable != null)
            _movable.Move(direction);
    }
    
}