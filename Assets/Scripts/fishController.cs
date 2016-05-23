using UnityEngine;
using System.Collections;

public class fishController : MonoBehaviour {

    public float speed;
    public int money;
    public bool direction;
    public bool hooked;
    private float startSpeed;
    
	// Use this for initialization
	void Start () {
        startSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "leftWall") 
        {
            transform.Rotate(Vector3.up, 180);
            direction = !direction;
        }
        if (col.name == "rightWall")
        {
            transform.Rotate(Vector3.up, 180);
            direction = !direction;
        }
        if (col.name == "hook")
        {
            Debug.Log("hhoooook");
            HookController hook = ((HookController)FindObjectOfType(typeof(HookController)));
            if (!hook.isUsed)
            {
                hooked = true;
                transform.Rotate(Vector3.forward, 90);

                hook.isUsed = true;
                hook.stop = false;
                hook.side = false;
                speed = ((HookController)FindObjectOfType(typeof(HookController))).speed;
            }
        }
        if (col.name == "upWall")
        {
            Debug.Log("wall");
            transform.Rotate(Vector3.forward, -90);
            speed = startSpeed;
            transform.position = new Vector3(-55.4F, -2.7F, 9.3F);
            Sprite myFruit = Resources.Load("gg", typeof(Sprite)) as Sprite;
            Debug.Log(myFruit.ToString());
            hooked = false;
            direction = true;
        }
    }
}
