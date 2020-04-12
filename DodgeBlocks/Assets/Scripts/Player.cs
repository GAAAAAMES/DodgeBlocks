using System.Collections;
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
	   if(GetComponent<BoxCollider2D>().isTrigger)
            FindObjectOfType<GameManager>().goBack();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("HEHE");
       
        if (col.gameObject.tag == "Power")
        {
            Debug.Log("JEJE");
            FindObjectOfType<GameManager>().goThrough();
            isTriggerTime = 3f;
        }
        else
        {
            if (GetComponent<Collider2D>().isTrigger == false)
            {
       		rend.sprite = hitMaterial;
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                FindObjectOfType<AudioManager>().Play("Evil laught");
                FindObjectOfType<GameManager>().EndGame();

            }
        }
    }
}
