using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float slowness = 10f;
    public GameObject restartMenu;

    public void EndGame()
    {

       FindObjectOfType<AudioManager>().Stop("Theme1");
       restartMenu.gameObject.SetActive(true);
       StartCoroutine(SlowDown());
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
