using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

    private static GM instance = null;
    public static GM inst {
        get { if (!instance) instance = GameObject.FindObjectOfType<GM>(); return instance; }
    }

    public GameObject spawn;
    [HideInInspector]
    public GameObject lastCheckpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
