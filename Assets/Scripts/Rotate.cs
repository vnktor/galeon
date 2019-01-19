using UnityEngine;

namespace RotatePoint {
	public class Rotate : MonoBehaviour {
		
		private void Update () {
			transform.Rotate (new Vector3(190, 0, 0) * Time.deltaTime);
		}
	}
}