using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteBuilder : MonoBehaviour {
    static public MeteoriteBuilder instance = null;
    private GameObject obj;
    // Use this for initialization
    void Awake () {
        instance = this;
    }

    public GameObject Build(string type, Vector3 pPos, Vector3 pRot)
    {
        switch (type)
        {
            case "Meteorite":
                obj = MeteoriteFactory.instance.Create(type);
                MeteoriteController a = obj.AddComponent<MeteoriteController>();
                a.SetSpeed(Random.Range(0.1f, 0.5f));
                obj.transform.position = pPos;
                obj.transform.eulerAngles = pRot;
                return obj;
            default:
                return null;
        }
    }
}
