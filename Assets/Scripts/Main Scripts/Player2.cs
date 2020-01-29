using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour 
{
	public float speed = 5;

    private Rigidbody rb;
	private Vector3 moveDest = new Vector3(9,9,0);
	private int horizontal = 9;
    private int vertical = 9;
	private float sqrRemainingDistance;

	public float leftBound;
	public float rightBound;
    public float upperBound;
    public float lowerBound;

    public bool moving;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
        if (!moving)
        {
            //Left
            if (Input.GetKeyDown(KeyCode.A) && rb.transform.position.x >= leftBound)
            {
                horizontal += -1;
                moveDest.x = horizontal;
                moving = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && rb.transform.position.x <= rightBound)
            {
                horizontal += 1;
                moveDest.x = horizontal;
                moving = true;

            }
            else if (Input.GetKeyDown(KeyCode.W) && rb.transform.position.y <= upperBound)
            {
                vertical += 1;
                moveDest.y = vertical;
                moving = true;

            }
            else if (Input.GetKeyDown(KeyCode.S) && rb.transform.position.y >= lowerBound)
            {
                vertical += -1;
                moveDest.y = vertical;
                moving = true;
            }
        }

    }

	void FixedUpdate()
	{
		sqrRemainingDistance = (rb.transform.position - moveDest).sqrMagnitude;

		if (sqrRemainingDistance > float.Epsilon) 
		{
			Vector3 newPosition = Vector3.MoveTowards(rb.transform.position, moveDest, Time.deltaTime * speed);

			rb.MovePosition (newPosition);

			sqrRemainingDistance = (rb.transform.position - moveDest).sqrMagnitude;

            moving = false;
        }
	}


}
