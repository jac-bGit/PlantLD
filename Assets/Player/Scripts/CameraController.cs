using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
        //get player
        player = FindObjectOfType<PlayerBehaviour>().transform;

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
