using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform gunHead;
    public GameObject bulletPrefab;
    public Transform firstGunPosition;
    public Transform secondGunPosition;
    public float fireRate = 1f;
    private Transform target;
    private float countDown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0)
        {
            Shoot();
            countDown = fireRate;
        }

        countDown -= Time.deltaTime;

    }

    void Shoot()
    {
        var firedBullet1 = Instantiate(bulletPrefab, firstGunPosition.position, firstGunPosition.rotation);
        var firedBullet2 = Instantiate(bulletPrefab, secondGunPosition.position, secondGunPosition.rotation);
        var bulletScript1 = firedBullet1.GetComponent<BulletMoving>();
        var bulletScript2 = firedBullet2.GetComponent<BulletMoving>();

        if (bulletScript1 != null && bulletScript2 != null)
        {
            target = gameObject.GetComponent<Rotation>().target;
            bulletScript1.Seek(target);
            bulletScript2.Seek(target);
        }
    }
}
