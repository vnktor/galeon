using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;
	public Transform target;

	private Rigidbody rb;
	private int count;
	private bool moveComplete;
	private Renderer render;

	public void NewTarget()
	{
		moveComplete = false;
		if (render.material.color == Color.green)
		{
			render.material.color = Color.red;
		}
		else
		{
			render.material.color = Color.green;
		}
	}

	private void Start()
	{
		this.rb = this.GetComponent<Rigidbody>();
		this.count = 0;
		SetCountText();
		this.winText.text = "";
		this.render = this.GetComponent<Renderer>();
		this.render.material.color = Color.red;
		this.moveComplete = true;
	}

	private void FixedUpdate()
	{
		if (!this.moveComplete)
		{
			if (Vector3.Distance(this.transform.position, this.target.position) < 1)
			{
				moveComplete = true;
			}
			else
			{
				Vector3 movement = new Vector3(target.position.x - this.transform.position.x, this.transform.position.z, target.position.z - this.transform.position.z);
				movement.Normalize();
				this.rb.AddForce(movement * this.speed);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			this.count++;
			SetCountText();
		}
	}

	private void SetCountText()
	{
		this.countText.text = "Count: " + this.count.ToString();
		if (this.count >= 12)
		{
			this.winText.text = "You Win!!!";
		}
	}
}