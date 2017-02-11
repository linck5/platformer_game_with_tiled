using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
        this.transform.position = GM.inst.spawn.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Deadly") {

            if(GM.inst.lastCheckpoint != null){
                this.transform.position = GM.inst.lastCheckpoint.transform.position;
            }
            else {
                this.transform.position = GM.inst.spawn.transform.position;
            }
        }
        else if (other.tag == "Checkpoint") {
            GM.inst.lastCheckpoint = other.gameObject;
        }

    }
}
