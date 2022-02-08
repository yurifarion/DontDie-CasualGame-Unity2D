using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void Update () {
     Vector3 velocity = Vector3.zero;
     Vector3 forward = _player.transform.forward * 10.0f;
     Vector3 needPos = _player.transform.position - forward;
     transform.position = Vector3.SmoothDamp(transform.position, needPos,
                                             ref velocity,0.05f);
     transform.LookAt (_player.transform);
     transform.rotation = _player.transform.rotation;
 }
}
