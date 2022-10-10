using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByClickController : MonoBehaviour
{
    private Transform _player;
    private Camera _cam;
    private Vector2 _mousePos;
    private List<Vector3> _track;

    public List<Vector3> Track { get => _track; private set => _track = value; }

    private void Start() 
    {
        _player = GetComponent<Transform>();   
        _cam = Camera.main; 
        Track = new List<Vector3>();
    }

    private void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _mousePos = Input.mousePosition;
            var position = _cam.ScreenToWorldPoint(_mousePos);
            position.z = 0;

            Track.Add(position);
        }
        if (Track.Count > 0)
        {
            _player.position = Vector2.MoveTowards(_player.position, Track[0], Time.deltaTime * 4);
            if (_player.position == Track[0])
            {    
                Track.RemoveAt(0); 
            }
        }
    }
}
