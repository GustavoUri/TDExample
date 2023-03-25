using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 5f;

    private Transform _target;

    private int _wavePointIndex;

    // Start is called before the first frame update
    void Start()
    {
        _target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * (speed * Time.deltaTime), Space.World);
        
        if (Vector3.Distance(transform.position, _target.position) <= 0.01f)
        {
            MoveNextPoint();
        }
    }

    void MoveNextPoint()
    {
        if (_wavePointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _wavePointIndex++;
        _target = Waypoints.points[_wavePointIndex];
    }
}