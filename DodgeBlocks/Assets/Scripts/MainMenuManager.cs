using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
	    SceneManager.LoadScene("GameScene");
    }

    public void Tutorial(){}
    public void EndGame(){}
}
