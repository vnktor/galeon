using UnityEngine;

namespace COMIRON.GameFramework.Core {
	public abstract class SettingsBase : ScriptableObject {
		public void Awake() {
			this.AwakeInherit();
		}
		
		protected abstract void AwakeInherit();
	}
}