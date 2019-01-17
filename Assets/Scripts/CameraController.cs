using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

    // Use this for initialization
    private void Start () {
        this.offset = this.transform.position - this.player.transform.position;
	}

	// Update is called once per frame
	private void LateUpdate()
	{
        this.transform.position = this.player.transform.position + this.offset;
	}
}