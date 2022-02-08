using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSplash : MonoBehaviour
{
	public Vector3 movement = new Vector3(-0.5f,0,0);
	public float moveSpeed;
	
	void Start(){
		StartCoroutine(destroyInSec(0.7f));
	}
    // Start is called before the first frame update
    void FixedUpdate()
    {
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
	IEnumerator destroyInSec(float sec){
		 yield return new WaitForSeconds(sec);
		Destroy(this.gameObject);
	}
}
