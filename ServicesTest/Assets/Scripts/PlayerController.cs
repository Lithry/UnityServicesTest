using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 rotation;
    private float speed;

    private int xLimit;
    private int yLimit;

	void Start () {
        rb = GetComponent<Rigidbody>();
        xLimit = 10;
        yLimit = 18;
	}
	
	void Update () {
        rb.AddForce(InputManager.instance.Movement() * speed);

        if (InputManager.instance.Movement().x > 0)
            rotation.Set(-90, 90, -145);
        else if (InputManager.instance.Movement().x < 0)
            rotation.Set(-90, 90, -35);
        else
            rotation.Set(-90, 90, -90);

        transform.eulerAngles = rotation;

        Limits();

        Score.score += 0.02f;
    }

    public void SetSpeed(float spd) {
        speed = spd;
    }

    private void Limits()
    {
        if (transform.position.x < -xLimit)
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        else if (transform.position.x > xLimit)
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);

        if (transform.position.y > yLimit)
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        else if (transform.position.y < -yLimit)
            transform.position = new Vector3(transform.position.x, -yLimit, transform.position.z);
    }

    void OnTriggerEnter(Collider coll) {
        StartCoroutine(Dead());
        Analytics.CustomEvent("GameOver", new Dictionary<string, object> { { "score", Score.score } });
    }

    IEnumerator Dead() {
        yield return new WaitForSeconds(0.15f);
        PlayerFactory.instance.Recycle(gameObject); 
    }
}
