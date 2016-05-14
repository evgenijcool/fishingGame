using UnityEngine;
using System.Collections;

public class moveCloud : MonoBehaviour {


    //false - right
    //true - left
    public bool side = false;
    public int speed;

	// Use this for initialization
	void Start () {
	    
	}

    // Update is called once per frame
    void Update()
    {
        if (side)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
    }
}
