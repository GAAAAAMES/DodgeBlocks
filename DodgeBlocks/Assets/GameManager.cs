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
    
    public void RestartGame(){
   	Time.timeScale = 1f;
        Time.fixedDeltaTime *= slowness;
	restartMenu.gameObject.SetActive(false);

        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
    	Application.Quit();
    }
}
