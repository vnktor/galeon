using RollaBall;
using UnityEngine;

namespace CkicktoPlayer {
	public class ClickMouse : MonoBehaviour {
		[SerializeField]
		private Animation animObject;
		private PlayerMove Pause;
		
		private void OnMouseDown() {
			Pause = GetComponent<PlayerMove>();
			Pause.enabled = !Pause.enabled;
			Invoke("Shock", 2.5f);
			animObject.Rewind("playerAnim");
			animObject.Play("playerAnim");
		}
		void Shock() {
			Pause.enabled = true;
		}
	}
}
