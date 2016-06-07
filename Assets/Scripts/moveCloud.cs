using UnityEngine;

public class moveCloud : MonoBehaviour {

    public bool side = false;
    public int speed;
	
	void Start () {
	}

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

	void OnTriggerEnter(Collider col)
	{
		if (col.name == "leftWall" || col.name == "rightWall")
			side = !side;
	}

}
