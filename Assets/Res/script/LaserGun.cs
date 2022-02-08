using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
	public GameObject bullet;
	private bool laserBulletEnable = true;
	public string shootDirection = "Down";
	public Transform bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateGun());
    }

    // Update is called once per frame
    void Update()
    {
        if(!laserBulletEnable){
			laserBulletEnable = true;
			StartCoroutine(laserBulletCoolDown());
			GameObject p = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
			if(shootDirection == "Down"){
				p.GetComponent<LaserBullet>().movement = new Vector3(0,-0.5f,0);
				p.GetComponent<LaserBullet>().orientation = "Down";
			}
			else if(shootDirection == "Left"){
				p.transform.rotation = Quaternion.Euler(0, 0, -90);
				p.GetComponent<LaserBullet>().orientation = "Left";
				p.GetComponent<LaserBullet>().movement = new Vector3(-0.5f,0,0);
			}
		}
    }
	IEnumerator laserBulletCoolDown(){
		yield return new WaitForSeconds(0.8f);
		laserBulletEnable = false;
	}
	IEnumerator ActivateGun(){
		yield return new WaitForSeconds(2f);
		laserBulletEnable = false;
	}
}
