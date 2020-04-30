using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float distance;
    public LayerMask OqeSolido;
    void Start()
    {
        
    }


    void Update()
    {
        RaycastHit2D InfoDano = Physics2D.Raycast(transform.position, transform.up, distance, OqeSolido);
        if (InfoDano.collider != null)
        {
            if(InfoDano.collider.CompareTag("Enemy"))
            {
                Debug.Log("TOMOU DANO");
            }
            Destroy(gameObject);
            
        }
    }
}
