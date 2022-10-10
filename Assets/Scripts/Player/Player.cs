using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static UnityEvent OnPlayerDeathEvent = new UnityEvent();
    private void Awake()
    {
        Spike.OnPlayerTouchedTheSpikeEvent.AddListener(Death);
    }
    private void Death()
    {
        OnPlayerDeathEvent.Invoke();
    }
}
