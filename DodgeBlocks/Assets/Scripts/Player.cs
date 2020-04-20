﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Player : MonoBehaviour
{
    public Sprite hitMaterial;
    private float isTriggerTime=0;
    SpriteRenderer rend;

    void Start()
    {	
    	rend = GetComponent<SpriteRenderer>();
    	rend.enabled = true;
    }

    void Update()
    {
        if(isTriggerTime>0)
        {
            isTriggerTime -= Time.deltaTime;
	    Color tmp = rend.GetComponent<SpriteRenderer>().color;
	    tmp.a += 0.002f;
	    rend.GetComponent<SpriteRenderer>().color = tmp;
        }
        else
        {
	   if(GetComponent<PolygonCollider2D>().isTrigger)
            FindObjectOfType<GameManager>().goBack();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {  
        if (col.gameObject.tag == "Power")
        {
            if (col.gameObject.name == "Blue PowerUp(Clone)")
            {		
	        FindObjectOfType<AudioManager>().Play("Powerup1");	
                FindObjectOfType<GameManager>().goThrough();
                isTriggerTime = 3f;
            }
            else
            {
	        FindObjectOfType<AudioManager>().Play("Powerup2");
                FindObjectOfType<GameManager>().destroyEnemies();
            }
        }
        else
        {
            if (GetComponent<Collider2D>().isTrigger == false)
            {
                FindObjectOfType<GameManager>().destroyEnemies();
       		    rend.sprite = hitMaterial;
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                FindObjectOfType<AudioManager>().Play("Evil laught");
                FindObjectOfType<GameManager>().EndGame();

            }
        }
    }
}
