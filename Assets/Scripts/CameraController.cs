using UnityEngine;

public class CameraController : MonoBehaviour
{
	public PlayerController player;
	public Transform target;
	public LayerMask mask;

	private Vector3 offset;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			MouseClick();
		}
	}

	private void MouseClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit[] hits = Physics.RaycastAll(ray, 50.0f, this.mask);
		foreach (var hit in hits)
		{
			if (hit.transform.CompareTag("Terrain"))
			{
				this.target.position = hit.point;
				this.player.NewTarget();
				break;
			}
		}
	}

	private void Start ()
	{
		this.offset = this.transform.position - this.player.transform.position;
	}

	private void LateUpdate ()
	{
		this.transform.position = this.player.transform.position + this.offset;
	}
}