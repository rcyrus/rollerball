using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	private int boxCount;
	void Start ()
	{
		boxCount = GameObject.FindGameObjectsWithTag("PickUp").Length;
		winText.text = "";
		count = 0;
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= boxCount) {
			winText.text = "Winner is you!";
		}
	}
}