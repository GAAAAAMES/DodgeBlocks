using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int temp_score;
    public int coins_added=0;
    public Text scoreLabel;
    public Text coinsLabel;
    public float slowness = 10f;
    public GameObject restartMenu;
    public GameObject reviveButton;
    public Collider2D player;
    public SpriteRenderer opacity; 
    public Text quoteLabel;
    public string[] quotes={"Nice try", "You didn't see that comming", "You'll never win this game!", "You've been hacked"};

    public void EndGame()
    {
        temp_score = 0;
        string text_score = (scoreLabel.text);
        for (int i = 7; i < text_score.Length; i++) temp_score =temp_score*10+ (int)char.GetNumericValue(text_score[i]);

        int temp_coins = PlayerPrefs.GetInt("Coins",0);
       temp_coins += ((temp_score-coins_added)/10);
       PlayerPrefs.SetInt("Coins", temp_coins);

        coinsLabel.text = "" + temp_coins;
        Debug.Log(temp_score);
	if(temp_coins >=10){
	       reviveButton.gameObject.SetActive(true);
	}
       FindObjectOfType<AudioManager>().Stop("Theme1");
       restartMenu.gameObject.SetActive(true);
       int randomQuote = Random.Range(0,quotes.Length);
       quoteLabel.text = quotes[randomQuote];
       StartCoroutine(SlowDown());
    }

    public void goThrough()
    {	
        player.isTrigger = true;
        Color tmp = opacity.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.4f;
        opacity.GetComponent<SpriteRenderer>().color = tmp;
	Debug.Log("GO");
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

    public void Revive()
    {
        if (PlayerPrefs.GetInt("Coins", 0) >= 10)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime *= slowness;
            restartMenu.gameObject.SetActive(false);
            destroyEnemies();
            FindObjectOfType<AudioManager>().Stop("Evil laught");
            FindObjectOfType<AudioManager>().Play("Theme1");
            FindObjectOfType<AudioManager>().Play("Revive");
            Debug.Log("timescale is " + Time.timeScale);
            SceneManager.GetActiveScene();
            coins_added = temp_score;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - 10);
        }

    }

    public void destroyEnemies()
    {

        GameObject[] toDestroy = (GameObject[])GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject ob in toDestroy)
        {
            Destroy(ob.gameObject);
        }
    }

    public void QuitGame()
    {
    	Application.Quit();
    }
}
