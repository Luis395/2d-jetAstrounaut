﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak : MonoBehaviour
{
    public GameObject myPlayer;
    private SpriteRenderer sr;
    private Animator anim;
    public GameObject projectile;
    public Transform shotpoint;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            sr.enabled = true;
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
            if (rotateZ < -90 || rotateZ > 90)
            {

                if (myPlayer.transform.eulerAngles.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotateZ);

                }
                else if (myPlayer.transform.eulerAngles.y == 180)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotateZ);

                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                CameraController.instance.shake();

                GameObject shoot = Instantiate(projectile, shotpoint.position, transform.rotation);
                shoot.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
            }
        }
        else
        {
            sr.enabled = false;
        }
    }
}
