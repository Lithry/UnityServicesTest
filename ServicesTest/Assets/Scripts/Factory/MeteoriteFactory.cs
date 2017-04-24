using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteFactory : MonoBehaviour {
    static public MeteoriteFactory instance = null;
    public GameObject meteoritePrefab;

    void Awake()
    {
        instance = this;
    }


    public GameObject Create(string type)
    {
        switch (type)
        {
            case "Meteorite":
                GameObject meteorite = Instantiate(meteoritePrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
                return meteorite;
            default:
                return null;
        }
    }

    public void Recycle(GameObject obj)
    {
        Destroy(obj);
    }
}