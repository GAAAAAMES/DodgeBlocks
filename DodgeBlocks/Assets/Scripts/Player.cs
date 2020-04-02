using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Player : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite hitMaterial;
    SpriteRenderer rend;

    void Start(){	
	rend = GetComponent<SpriteRenderer>();
	rend.enabled = true;
    }	

    private void OnCollisionEnter2D()
    {
       audioSource.Play(0);
       rend.sprite = hitMaterial;
       FindObjectOfType<GameManager>().EndGame();
    }
}
