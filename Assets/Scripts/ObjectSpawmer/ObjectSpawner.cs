using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private int _count;

    public static UnityEvent<ObjectSpawner, int> OnObjectIsSwawnedEvent = new UnityEvent<ObjectSpawner, int>();

    private void Start() 
    {
        _count = Random.Range(1, 5);
        SpawnOnRandomPoint();
        OnObjectIsSwawnedEvent.Invoke(this, _count);
    }

    private void SpawnOnRandomPoint()
    {
        var cam = Camera.main;

        for (int i = 0; i < _count; i++)
        {
            var positionX = Random.Range(0, cam.pixelWidth);   
            var positionY = Random.Range(0, cam.pixelHeight);   

            var position = cam.ScreenToWorldPoint(new Vector2(positionX, positionY));
            position.z = 0;

            Instantiate(_prefab, position, Quaternion.identity, this.transform);
        }
    }

}
