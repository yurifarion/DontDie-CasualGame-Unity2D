using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public float moveSpeed =5f;
	public float jumpForce = 5f;
	public bool isGrounded = false;
	private Animator anim;
	public bool isControllerEnable = true;
	private AudioSource _audioSource;

	
	void Start(){
		
		anim = this.gameObject.GetComponent<Animator>();
		_audioSource = this.gameObject.GetComponent<AudioSource>();
	}
 
	void Update(){
		if(isControllerEnable){
			Jump();
			Flip();
			
			Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
			if(Input.GetAxis("Horizontal") != 0){
				anim.SetFloat("Speed",1);
				if(_audioSource.isPlaying == false)_audioSource.Play();		
			}
			else {
				anim.SetFloat("Speed",0);
				_audioSource.Pause();
			}
			
			transform.position += movement * Time.deltaTime * moveSpeed;
			
			if(Input.GetKeyDown(KeyCode.C)){
				anim.SetBool("Crouch",true);
				moveSpeed = 2f;
			}
			if(Input.GetKeyUp(KeyCode.C)){
				anim.SetBool("Crouch",false);
				moveSpeed = 5f;
			}
			if(Input.GetKeyUp(KeyCode.E)){
				StartCoroutine(Pick());
				
			}
		}
		
	}
	IEnumerator Pick()
    {
        anim.SetTrigger("Pick");
		isControllerEnable = false;
        yield return new WaitForSeconds(0.27f);
		anim.ResetTrigger("Pick");
		isControllerEnable = true;
    }
	void Jump(){
		
		if(Input.GetButtonDown("Jump") && isGrounded == true){
			Deebug();
			gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0f,jumpForce), ForceMode2D.Impulse);
		}
		
		anim.SetBool("Jump",!isGrounded);
	}
	void Flip(){
		if(Input.GetAxis("Horizontal") > 0){
			//this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
			this.gameObject.transform.localScale = new Vector3(10.50552f,10.50552f,10.50552f);
		}
		else if(Input.GetAxis("Horizontal") < 0){
			this.gameObject.transform.localScale = new Vector3(-10.50552f,10.50552f,10.50552f);
		}
	}
	void Deebug(){
		Debug.Log("Movement Input"+Input.GetAxis("Horizontal"));
		Debug.Log("Jump Input"+Input.GetButtonDown("Jump"));
		Debug.Log("is Grounded = "+isGrounded);
		
	}
	public void death(){
		
		
		
	}


}