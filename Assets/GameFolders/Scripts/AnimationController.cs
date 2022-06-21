using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] int danceNumber;
    [SerializeField] bool onDance;
    [SerializeField] [Range(0f, 5f)] float animationSpeed = 1;

    bool onPlay;

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        onPlay = true;
        _animator.SetBool("Dance", onDance);
        _animator.SetInteger("DanceNumber", danceNumber);
        _animator.speed = animationSpeed;
    }

    private void OnValidate()
    {
        if (!onPlay) return;
        _animator.SetBool("Dance", onDance);
        _animator.SetInteger("DanceNumber", danceNumber);
        _animator.speed = animationSpeed;
    }
}
