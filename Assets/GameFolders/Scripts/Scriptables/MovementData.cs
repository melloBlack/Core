using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement Variables", menuName = "Data/Movement Data")]
public class MovementData : ScriptableObject
{
    [Header("Movement Config")]
    [SerializeField] float _forwardSpeed = 10f;
    [SerializeField] float _horizontalSpeed = 5f;
    [SerializeField] Vector2 _horizontalBounds = Vector2.left + Vector2.up;

    public float ForwardSpeed => _forwardSpeed;
    public float HorizontalSpeed => _horizontalSpeed;
    public Vector2 HorizontalBounds => _horizontalBounds;
}