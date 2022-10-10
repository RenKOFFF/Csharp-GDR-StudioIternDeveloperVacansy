using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public static UnityEvent OnPlayerTookTheCoinEvent = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        var collider = other.GetComponent<Player>();

        if (collider != null)
        {
            OnPlayerTookTheCoinEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
