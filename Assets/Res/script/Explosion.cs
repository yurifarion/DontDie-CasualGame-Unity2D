using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public GameManager gm;
   public void AutoDestroy(){
	   PlayerPrefs.SetString("GameOverText","Don't click on button");
	   gm.gameLevel = "GameOver";
	   Destroy(this.gameObject);
   }
}
