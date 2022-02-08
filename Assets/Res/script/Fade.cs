using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
	public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void GameOver(){
		if(gm.gameLevel == "GameOver"){
			Application.LoadLevel("GameOver");
		}
		if(gm.gameLevel == "GameWin"){
			Application.LoadLevel("MainScene");
		}
		if(gm.gameLevel == "GameEnd"){
			Application.LoadLevel("GameWin");
		}
	}
}
