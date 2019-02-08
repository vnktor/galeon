using UnityEngine;
using System.Collections.Generic;

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

		protected T[] GetCreatedObjects<T>(List<GameObject> dObject = null) where T : ControllerBase {
			List<T> rezult= new List<T>();
			foreach(T obj in Object.FindObjectsOfType<T>()) {
				bool isExistsInDestroyList = false;
				if (dObject != null) {
					foreach (GameObject dobj in dObject) {
						if (obj.gameObject == dobj) {
							isExistsInDestroyList = true;
						}
					}
				}
				if (!isExistsInDestroyList && obj != null) {
					rezult.Add(obj);
				}
			}
			return rezult.ToArray(); 
		}
	}
}