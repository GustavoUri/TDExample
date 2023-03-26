using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    private Transform _target;

    public float speed = 70f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        var dir = _target.position - transform.position;
        var distanceThisFrame = Time.deltaTime * speed;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
        //return;
    }
}
