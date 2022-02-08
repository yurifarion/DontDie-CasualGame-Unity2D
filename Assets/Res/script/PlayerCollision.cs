using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	PlayerMovement Player;
	public GameObject text_pick;
	public string pickEnable = "none";
	private GameObject item;
	private PlayerStats _playerStats;
	public GameManager gm;
	public AudioSource _audioSource_Button;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.GetComponent<PlayerMovement>();
		_playerStats = gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && pickEnable == "Umbrela"){
			_playerStats.isPlayerWithUmbrela = true;
			Destroy(item);
		}
		 if(Input.GetKeyDown(KeyCode.E) && pickEnable == "Mask"){
			 text_pick.SetActive(false);
			_playerStats.isPlayerWithMask = true;
			Destroy(item);
		}
		if(Input.GetKeyDown(KeyCode.E) && pickEnable == "Button_click"){
			text_pick.SetActive(false);
			if(_audioSource_Button.isPlaying == false) _audioSource_Button.Play();
			gm.ButtonExplode();
			gm.clickedButton = true;
		}
    }
	private void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ground"){
			Player.GetComponent<PlayerMovement>().isGrounded = true;
			Player.GetComponent<Animator>().SetBool("Jump",false);	
			Player.GetComponent<PlayerMovement>().isControllerEnable = true;
		}
		
		
		
	}

	private void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground"){
			Player.GetComponent<PlayerMovement>().isGrounded = false;
		}
	}
	private void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.name == "Umbrela_item"){
			text_pick.SetActive(true);
			item = col.gameObject;
			pickEnable = "Umbrela";
		}
		if(col.gameObject.name == "Mask_item"){
			text_pick.SetActive(true);
			item = col.gameObject;
			pickEnable = "Mask";
		}
		if(col.gameObject.name == "Button_click"){
			text_pick.GetComponent<Text>().text = "Click Button [E]";
			text_pick.SetActive(true);
			item = col.gameObject;
			pickEnable = "Button_click";
		}
		if (col.gameObject.tag == "Lava"){
			Debug.Log("Die");
			PlayerPrefs.SetString("GameOverText","Climb on the boxes on the right of the lab");
			gm.gameLevel = "GameOver";
		}
		
	}
	private void OnTriggerExit2D (Collider2D col){
		if(col.gameObject.name == "Umbrela_item"){
			text_pick.SetActive(false);
			pickEnable = "None";
		}
		if(col.gameObject.name == "Mask_item"){
			text_pick.SetActive(false);
			pickEnable = "None";
		}
		if(col.gameObject.name == "Button_click"){
			text_pick.SetActive(false);
			pickEnable = "None";
		}
		
	}
}
