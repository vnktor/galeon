using UnityEngine;

namespace COMIRON.GameFramework.Core {
	public abstract class ManagerBase {
		private GameEngineBase gameEngine;
		
		private Transform container;
		
		public void Awake(GameEngineBase gameEngine) {
			this.gameEngine = gameEngine;
			
			this.container = new GameObject {name = this.GetType().Name + "Container"}.transform;
			
			this.AwakeInherit();
		}
		
		protected abstract void AwakeInherit();
		
		protected T GetSettings<T>() where T : SettingsBase {
			return this.gameEngine.GetSettings<T>();
		}
		
		protected T CreateController<T>(T prefab, Vector3 position) where T : ControllerBase {
			return Object.Instantiate(prefab.transform, position, Quaternion.identity, this.container).GetComponent<T>();
		}
	}
}