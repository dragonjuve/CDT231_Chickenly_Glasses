using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController player;
    public bool isFollowing;
    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();
        isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
	}
}
