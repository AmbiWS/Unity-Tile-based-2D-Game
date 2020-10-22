using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTineY;
    public float smoothTineX;

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Hero");
	}

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTineX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTineX);

        if (posY <= -1f) posY = -1f;

        transform.position = new Vector3(posX, posY, transform.position.z);

        
    }
}
