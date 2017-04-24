using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour {
    private Vector3 direction;
    private float speed;

	void Start () {
        direction = -Vector3.up;
	}
	
	void Update () {
        transform.position = transform.position + direction * speed;
        if (transform.position.y < -25)
            MeteoriteFactory.instance.Recycle(gameObject);
	}

    public void SetSpeed(float spd) {
        speed = spd;
    }
}
