using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform target;

    public float range = 15f;
    public Transform turretHead;
    public string enemyTag = "Enemy";

    public float turnSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
            Rotate();
    }

    void UpdateTarget()
    {
        var shortestDist = Mathf.Infinity;
        var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(transform.position,enemy.transform.position);
            if (distance < shortestDist)
            {
                shortestDist = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        
    }

    void Rotate()
    {
        var dir = target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(dir);
        var rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
