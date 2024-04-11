using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform nearPos_01;
    public Transform nearPos_02;
    public Transform nearPos_03;

    public Transform target;

    public float reloadTime;
    public float moveSpeed;
    public float hMove; //¼öÆò °ª
    //public float vMove;

    public Bullet bulletPrefab1;
    public Bullet bulletPrefab2;

    void Start()
    {
        hMove = transform.position.x;
        //vMove = transform.position.y;
    }

    void Update()
    {
        reloadTime += Time.deltaTime;
        Move();
        if (Input.GetKey(KeyCode.Z))
        {
            if (reloadTime >= 0.2f)
            {
                Attack();
                reloadTime= 0;
            }
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hMove -= moveSpeed * Time.deltaTime;
            transform.position = new Vector3(hMove, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hMove += moveSpeed * Time.deltaTime;
            transform.position = new Vector3(hMove, transform.position.y, transform.position.z);
        }

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    vMove += moveSpeed * Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, vMove, transform.position.z);
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    vMove -= moveSpeed * Time.deltaTime;
        //    transform.position = new Vector3(transform.position.x, vMove, transform.position.z);
        //}
    }

    void Attack()
    {
        var b1 = Instantiate(bulletPrefab1);
        var b2 = Instantiate(bulletPrefab2);

        b1.InitBullet(transform.position, nearPos_01.position, nearPos_02.position, target.position, 1.5f);
        b2.InitBullet(transform.position, nearPos_01.position, nearPos_03.position, target.position, 1.5f);
    }
}
