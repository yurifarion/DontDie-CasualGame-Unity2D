using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
	public Text gameOverText;
    // Start is called before the first frame update
    void Start()
    {
		  Cursor.visible = true;
		if(gameOverText != null){
			string placeholder = PlayerPrefs.GetString("GameOverText","Don't die");
			gameOverText.text = placeholder;
		}
    }
	public void PlayAgain(){
		PlayerPrefs.SetInt("Level",00000);
		Application.LoadLevel("MainScene");
	}
	public void Quit(){
	 Application.Quit();
	}		
    // Update is called once per frame
    void Update()
    {
        
    }
}
