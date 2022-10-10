using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Spike : MonoBehaviour
{
    public static UnityEvent OnPlayerTouchedTheSpikeEvent = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D other)
    {
        var collider = other.GetComponent<Player>();

        if (collider != null)
        {
            OnPlayerTouchedTheSpikeEvent.Invoke();
        }
    }
}
