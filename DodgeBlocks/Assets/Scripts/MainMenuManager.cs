using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    bool isMute = false; 
    public Image muteButtonImage;
    public Sprite muteSprite;
    public Sprite unmuteSprite;

    public void PlayGame()
    {
	    SceneManager.LoadScene("GameScene");
    }

    public void MuteTheme(){
	if(isMute){
          muteButtonImage.sprite = unmuteSprite;
	  FindObjectOfType<AudioManager>().Unmute("Theme1");
      FindObjectOfType<AudioManager>().Resume("Theme1");	
	}else{
          muteButtonImage.sprite = muteSprite;
	  FindObjectOfType<AudioManager>().Mute("Theme1");
      FindObjectOfType<AudioManager>().Pause("Theme1");
	}
	isMute = !isMute;
    }

    public void EndGame(){}
}
