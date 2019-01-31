using UnityEngine;

namespace RotatePoint {
	public class Rotate : MonoBehaviour {
		
		void Update () {
			transform.Rotate (new Vector3(190, 0, 0) * Time.deltaTime);
		}
	}
}