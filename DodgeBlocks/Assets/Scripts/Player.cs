using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Sprite hitMaterial;
    SpriteRenderer rend;

    void Start(){	
	rend = GetComponent<SpriteRenderer>();
	rend.enabled = true;
    }	

    private void OnCollisionEnter2D()
    {
       rend.sprite = hitMaterial;
       FindObjectOfType<GameManager>().EndGame();
    }
}
