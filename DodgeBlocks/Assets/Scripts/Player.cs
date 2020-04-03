using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Player : MonoBehaviour
{
    public Sprite hitMaterial;
    SpriteRenderer rend;

    void Start()
    {	
    	rend = GetComponent<SpriteRenderer>();
    	rend.enabled = true;
    }	

    private void OnCollisionEnter2D()
    {
       FindObjectOfType<AudioManager>().Play("PlayerDeath");
       FindObjectOfType<AudioManager>().Play("Evil laught");
       rend.sprite = hitMaterial;
       FindObjectOfType<GameManager>().EndGame();
    }
}
