using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool isPlayerWithUmbrela = false;
	public bool isPlayerWithMask = false;
	public GameObject Umbrela;
	public GameObject Mask;
	void Update(){
		Umbrela.SetActive(isPlayerWithUmbrela);
		Mask.SetActive(isPlayerWithMask);
	}
	public void PlayerInvisible(bool invisibility){
		this.gameObject.GetComponent<SpriteRenderer>().enabled = !invisibility;
	}
}
