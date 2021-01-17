﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour
{

    public float Range;
    
    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject AlarmLight;

    public GameObject Gun;

    public GameObject Bullet;

    public float FireRate;
    
    float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetpos = Target.position;

        Direction = targetpos - (Vector2)transform.position;

        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position,Direction,Range);

        if(rayinfo)
        {
            if(rayinfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            else
            {
                if(Detected == true)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                } 
            }
        }

        if(Detected)
        {
            Gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time+1/FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
