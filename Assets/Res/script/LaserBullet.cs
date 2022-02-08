using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
	public Vector3 movement = new Vector3(0,-0.5f,0);
	public float moveSpeed;
	public GameObject bulletSplash;
	public string orientation;
	private GameManager gm;
	
	void Start(){
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
    // Update is called once per frame
    void Update()
    {
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
	private void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ground"){
			Vector3 position = new Vector3(transform.position.x,transform.position.y + 0.7f,0);
			Quaternion rotation = Quaternion.identity;
			GameObject p = Instantiate(bulletSplash, position, rotation);
			StartCoroutine(destroyBulletSplash(p));
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		if (collision.gameObject.tag == "Player"){
			gm.gameLevel = "GameOver";
			PlayerPrefs.SetString("GameOverText","Try to dogde the plasma bullets !");
			Vector3 position = new Vector3(transform.position.x,transform.position.y + 0.7f,0);
			Quaternion rotation = Quaternion.identity;
			
			if(orientation == "Left"){
				rotation = Quaternion.Euler(0, 0, -90);
				position = new Vector3(transform.position.x,transform.position.y - 0.5f,0);
			}
			
			GameObject p = Instantiate(bulletSplash, position, rotation);
			StartCoroutine(destroyBulletSplash(p));
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	IEnumerator destroyBulletSplash(GameObject p){
		yield return new WaitForSeconds(0.5f);
		Destroy(p);
		Destroy(this.gameObject);
	}
}
