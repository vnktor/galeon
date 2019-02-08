using COMIRON.GameFramework.Core;
using UnityEngine;

namespace COMIRON.GameFramework.Ui {
	public abstract class PanelBase : MonoBehaviour {
		private GameEngineBase gameEngine;
		
		public void Initialize(GameEngineBase gameEngine) {
			this.gameEngine = gameEngine;
			
			this.InitializeInherit();
		}
		
		public void Enable() {
			this.gameObject.SetActive(true);
			
			this.EnableInherit();
		}
		
		public void Disable() {
			this.DisableInherit();
		}
		
		protected abstract void InitializeInherit();
		protected abstract void EnableInherit();
		protected abstract void DisableInherit();
		
		protected T GetSettings<T>() where T : SettingsBase {
			return this.gameEngine.GetSettings<T>();
		}
		
		protected T GetManager<T>() where T : ManagerBase {
			return this.gameEngine.GetManager<T>();
		}
	}
}