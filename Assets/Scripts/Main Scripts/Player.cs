using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float speed = 50;

    private Rigidbody rb;
	private Vector3 moveDest = new Vector3(0,0,0);
	private int horizontal = 0;
    private int vertical = 0;
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
            if (Input.GetKeyDown(KeyCode.LeftArrow) && rb.transform.position.x >= leftBound)
            {
                horizontal += -1;
                moveDest.x = horizontal;
                moving = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && rb.transform.position.x <= rightBound)
            {
                horizontal += 1;
                moveDest.x = horizontal;
                moving = true;

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && rb.transform.position.y <= upperBound)
            {
                vertical += 1;
                moveDest.y = vertical;
                moving = true;

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && rb.transform.position.y >= lowerBound)
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
