using UnityEngine;
using System.Collections.Generic;
using System;

namespace COMIRON.GameFramework.Core {
	public abstract class ManagerBase {
		private GameEngineBase gameEngine;
		
		private Transform container;
		private List<ControllerBase> controllerList ;

		public void Awake(GameEngineBase gameEngine) {
			this.gameEngine = gameEngine;
			this.controllerList = new List<ControllerBase>();

			this.container = new GameObject {name = this.GetType().Name + "Container"}.transform;
			
			this.AwakeInherit();
		}
		
		protected abstract void AwakeInherit();
		
		protected T GetSettings<T>() where T : SettingsBase {
			return this.gameEngine.GetSettings<T>();
		}
		
		protected T CreateController<T>(T prefab, Vector3 position) where T : ControllerBase {
			T newControllerBase = UnityEngine.Object.Instantiate(
				prefab.transform,
				position,
				Quaternion.identity,
				this.container
			).GetComponent<T>();
			this.controllerList.Add(newControllerBase);

			return newControllerBase;
		}

		

		protected T[] GetCreatedObjects<T>() where T : ControllerBase {
			List<T> listController = new List<T>();
			foreach (var controller in this.controllerList) {
				if(controller is T) {
					if (controller.enabled) {
						listController.Add((T)Convert.ChangeType(controller, typeof(T)));
					}
				}
			}
			return listController.ToArray();
		}


		
	}
}