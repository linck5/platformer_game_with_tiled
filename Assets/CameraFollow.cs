using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    PlatformerMotor2D motor;

    Vector3 lastGroundPosition;

    void Awake () {
        motor = player.GetComponent<PlatformerMotor2D>();

    }

	// Use this for initialization
	void Start () {

        //Time.timeScale = 0.1f;

        lastGroundPosition = player.transform.position;

        motor.onLanded = delegate
        {
            lastGroundPosition = player.transform.position;
        };

        
	}
	
	// Update is called once per frame
	void Update () {

        float xFollowSpeed = Time.deltaTime * 4f;
        float yFollowSpeed = Time.deltaTime * 2f;
        float yFollowSpeedFast = Time.deltaTime * 4f;

        if(motor.motorState == PlatformerMotor2D.MotorState.OnGround){
            this.transform.position = new Vector3(
               Mathf.Lerp(this.transform.position.x, player.transform.position.x, xFollowSpeed),
               Mathf.Lerp(this.transform.position.y, player.transform.position.y, yFollowSpeed),
               this.transform.position.z
               );


        }
        else if (Mathf.Abs(lastGroundPosition.y - player.transform.position.y) > 5.0f) {
            this.transform.position = new Vector3(
                Mathf.Lerp(this.transform.position.x, player.transform.position.x, xFollowSpeed),
                Mathf.Lerp(this.transform.position.y, player.transform.position.y, yFollowSpeed),
                this.transform.position.z
                );

        }
        else if (Mathf.Abs(this.transform.position.y - lastGroundPosition.y) > 0.2f) {
            this.transform.position = new Vector3(
                Mathf.Lerp(this.transform.position.x, player.transform.position.x, xFollowSpeed),
                Mathf.Lerp(this.transform.position.y, lastGroundPosition.y, yFollowSpeed),
                this.transform.position.z
                );

        }
        else{
           this.transform.position = new Vector3(
                Mathf.Lerp(this.transform.position.x, player.transform.position.x, xFollowSpeed),
                Mathf.Lerp(this.transform.position.y, lastGroundPosition.y, yFollowSpeed),
                this.transform.position.z
                );
        }

        float crosshairSize = 2.0f;
        Debug.DrawLine(this.transform.position + Vector3.left * crosshairSize, this.transform.position + Vector3.right * crosshairSize);
        Debug.DrawLine(this.transform.position + Vector3.up * crosshairSize, this.transform.position + Vector3.down * crosshairSize);
	}
}
