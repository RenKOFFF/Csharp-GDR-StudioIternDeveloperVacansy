using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoveByClickController))]
public class MovingLinePoint : MonoBehaviour
{
    private PlayerMoveByClickController _moveController;
    private Transform _player;

    private LineRenderer line;
    private float _width = .3f;

    private List<Vector3> _track;
    private void Start()
    {
        _player = GetComponent<Transform>();
        _moveController = GetComponent<PlayerMoveByClickController>();

        line = GetComponentInChildren<LineRenderer>();
        line.startWidth = line.endWidth = _width;
    }

    private void Update()
    {
        _track = _moveController.Track;
        if (_track != null && _track.Count > 0)
        {
            line.positionCount = _track.Count + 1;
            line.SetPosition(0, _player.position);

            for (int i = 0; i < _track.Count; i++)
            {
                line.SetPosition(i + 1, _track[i]);
            }
        }
    }
}
