using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_position : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	private void Start() {
		this.offset = transform.position - this.player.transform.position;
	}

	private void LateUpdate() {
		transform.position = this.player.transform.position + this.offset;
	}
}