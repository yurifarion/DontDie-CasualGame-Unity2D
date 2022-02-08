using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
	public GameObject lavaSplash;
	public List<Transform> spawnPoints = new List<Transform>();
	private bool lavaSplashCoolDown= false;
	
	public Vector3 movement = new Vector3(0,-0.5f,0);
	public float moveSpeed;
	public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	void FixedUpdate()
    {
		Debug.Log(transform.position.y);
		if(transform.position.y < -0.2f){
			transform.position += movement * Time.deltaTime * moveSpeed;
		}
		else gm.gameLevel = "GameWin";
    }
    // Update is called once per frame
    void Update()
    {
        if(!lavaSplashCoolDown)CreateLavaSplash();
    }
	void CreateLavaSplash(){
		lavaSplashCoolDown = true;
		StartCoroutine(lavasplashwait());
		GameObject p = Instantiate(lavaSplash, spawnPoints[Random.Range(0,7)].position, Quaternion.identity);
		p.transform.parent = transform;
	}
	IEnumerator lavasplashwait(){
		yield return new WaitForSeconds(0.8f);
		lavaSplashCoolDown = false;
	}
}
