using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    private Vector3 finalPos;
    [Range(0, 10)]
    public float smooth = 3f;

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
        finalPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, finalPos, smooth * Time.deltaTime);
    }
}
