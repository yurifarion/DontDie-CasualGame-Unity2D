using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public string gameLevel = "R";
	
	//ThundeStorm
	public GameObject rain;
	public GameObject thunderGL;
	public GameObject normalGL;
	public bool thunderBolt = false;
	public GameObject player;
	private PlayerStats _playerStats;
	public GameObject umbrela;
	
	//Lava
	public GameObject lava;
	public GameObject woodenBox;
	
	//LaserGun
	public GameObject laserGuns;
	
	//gas
	public GameObject GasScene;
	public GameObject gasMask;
	public bool isMaskOn = false;
	
	//Button BOOM
	public GameObject ButtonScene;
	public GameObject ExplosionEffect;
	public bool clickedButton = false;
	
	
	public Animator fade;
	public int levels;
	
    // Start is called before the first frame update
    void Start()
    {
		Cursor.visible = false;
		RandomChoice();
		//PlayerPrefs.SetInt("Level",00000);
		levels = PlayerPrefs.GetInt("Level",00000);
        _playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLevel == "Rain" ){
			if(umbrela != null)umbrela.SetActive(true);
			DoThunderStorm();
		}
		if(gameLevel == "Lava" ){
			lava.SetActive(true);
			woodenBox.SetActive(true);
		}
		if(gameLevel == "Laser" ){
			laserGuns.SetActive(true);
			StartCoroutine(laserGameWIN());
			
		}
		if(gameLevel == "Gas" ){
			isMaskOn = _playerStats.isPlayerWithMask;
			
			GasScene.SetActive(true);
			if(gasMask != null)gasMask.SetActive(true);
			StartCoroutine(killOnGas());
		}
		if(gameLevel == "GameOver" ){
			fade.SetTrigger("FadeOut");
		}
		if(gameLevel == "Button" ){
			ButtonScene.SetActive(true);
			StartCoroutine(KillButton());
		}
		if(gameLevel == "GameWin" ){
			fade.SetTrigger("FadeOut");
		}
    }
	void RandomChoice(){
		//10000 - lava
		//01000 - Button
		//00100 - Laser
		//00010 - Rain
		//00001 - Gas
		if(PlayerPrefs.GetInt("Level",00000) == 11111){
			gameLevel = "GameEnd";
			fade.SetTrigger("FadeOut");
			return;
		}
		int level = Random.Range(1,6);
		Debug.Log("Try Level"+level);
		if(level == 1){//lava
		
			int temp  = PlayerPrefs.GetInt("Level",00000) / 10000;
			if(temp == 1){
				RandomChoice();
			}
			else{
				Debug.Log("Temp:"+temp+"Level"+level);
				PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",00000) + 10000);
				gameLevel = "Lava";
			}
		}
		else if(level == 2){//Button
			int temp  = (PlayerPrefs.GetInt("Level",00000) % 10000) / 1000;
			if(temp == 1){
				RandomChoice();
			}
			else{
				Debug.Log("Temp:"+temp+"Level"+level);
				PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",00000) + 1000);
				gameLevel = "Button";
			}
		}
		else if(level == 3){//Laser
			int temp  = ((PlayerPrefs.GetInt("Level",00000) % 10000) % 1000) / 100;
			if(temp == 1){
				RandomChoice();
			}
			else{
				Debug.Log("Temp:"+temp+"Level"+level);
				PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",00000) + 100);
				gameLevel = "Laser";
			}
		}
		else if(level == 4){//Rain
			int temp  = (((PlayerPrefs.GetInt("Level",00000) % 10000) % 1000) % 100) / 10;
			if(temp == 1){
				RandomChoice();
			}
			else{
				Debug.Log("Temp:"+temp+"Level"+level);
				PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",00000) + 10);
				gameLevel = "Rain";
			}
		}
		else if(level == 5){//Gas
			int temp  = ((((PlayerPrefs.GetInt("Level",00000) % 10000) % 1000) % 100) % 10);
			
			if(temp == 1){
				RandomChoice();
			}
			else{
				Debug.Log("Temp:"+temp+"Level"+level);
				PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",00000) + 1);
				gameLevel = "Gas";
			}
		}
	}
	void DoThunderStorm(){
		StartCoroutine(killOnThunder());
		rain.SetActive(true);
		
		
		if(thunderBolt){
			
			normalGL.SetActive(false);
			thunderGL.SetActive(true);
			if(!_playerStats.isPlayerWithUmbrela){
				player.GetComponent<Animator>().SetTrigger("shock");
				Destroy(player.GetComponent<PlayerMovement>());
				PlayerPrefs.SetString("GameOverText","Pick up the Umbrela on the left side of the Lab");
				StartCoroutine(dieCounter(2f));
			}
			else{
				//rain.SetActive(false);
				thunderGL.SetActive(false);
				normalGL.SetActive(true);
				//_playerStats.isPlayerWithUmbrela = false;
				gameLevel = "GameWin";
			}
		}
		
	}
	public void ButtonExplode(){
		ExplosionEffect.SetActive(true);
		_playerStats.PlayerInvisible(true);
	}
	IEnumerator KillButton()
    {
        yield return new WaitForSeconds(10);
		if(!clickedButton) gameLevel = "GameWin";
		
    }
	IEnumerator killOnGas()
    {
        yield return new WaitForSeconds(5);
		PlayerPrefs.SetString("GameOverText","Pick up the Mask on the right side of the Lab");
		if(!isMaskOn) gameLevel = "GameOver";
		else gameLevel = "GameWin";
		
    }
	IEnumerator killOnThunder()
    {
        yield return new WaitForSeconds(3);
		thunderBolt = true;
		
    }
	IEnumerator laserGameWIN()
    {
        yield return new WaitForSeconds(8);
		gameLevel = "GameWin";
		
    }
	public IEnumerator dieCounter(float sec)
    {
        yield return new WaitForSeconds(sec);
		gameLevel = "GameOver";
		
    }
	
}
