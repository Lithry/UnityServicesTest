using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteManager : MonoBehaviour {
    static public MeteoriteManager instance = null;

    private float respawnDelay;
    private float respawn;
    private Vector3 respawnPos;

    // Use this for initialization
    void Start()
    {
        instance = this;
        respawnDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Respawn();
    }

    private void Respawn()
    {
        respawn += Time.deltaTime;

        if (respawn > respawnDelay)
        {
            respawnPos = new Vector3(Random.Range(-10, 10), 25, 20);

            MeteoriteBuilder.instance.Build("Meteorite", respawnPos, new Vector3(0, 0, 0));
            respawn = 0;
            respawnDelay = Random.Range(0.5f, 1.0f);
        }
    }
}
