using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float slowness = 10f;
    public GameObject restartMenu;
    public Collider2D player;
    public SpriteRenderer opacity;
    public void EndGame()
    {

       FindObjectOfType<AudioManager>().Stop("Theme1");
       restartMenu.gameObject.SetActive(true);
       StartCoroutine(SlowDown());
    }

    public void goThrough()
    {
        player.isTrigger = true;
        Color tmp = opacity.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.8f;
        opacity.GetComponent<SpriteRenderer>().color = tmp;
    }

    public void goBack()
    {
        player.isTrigger = false;
        Color tmp = opacity.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        opacity.GetComponent<SpriteRenderer>().color = tmp;
    }

    IEnumerator SlowDown()
    {
        //before 1 sec

        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f/slowness );
	    Time.timeScale = 0f;
        //after 1 sec
    }
    
    public void RestartGame()
    {
	    Time.timeScale = 1f;
	    Time.fixedDeltaTime *= slowness;
	    restartMenu.gameObject.SetActive(false);
	    FindObjectOfType<AudioManager>().Stop("Evil laught");
	    FindObjectOfType<AudioManager>().Play("Theme1");
       	    SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
    	Application.Quit();
    }
}
