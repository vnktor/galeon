using System;
using System.Collections.Generic;
using UnityEngine;

namespace COMIRON.GameFramework.Core {
	public abstract class GameEngineBase : MonoBehaviour {
		private List<ManagerBase> managersList;
		private List<SettingsBase> settingsLoaded;
		
		private void Awake() {
			this.managersList = new List<ManagerBase>();
			this.settingsLoaded = new List<SettingsBase>();
			
			this.AwakeInherit();
		}
		
		protected abstract void AwakeInherit();
		protected abstract void Update();
		protected abstract void FixedUpdate();
		
		protected T GetManager<T>() where T : ManagerBase {
			// Check if the class already created.
			foreach (var m in this.managersList) {
				if (m is T) {
					return (T) Convert.ChangeType(m, typeof (T));
				}
			}
			
			var instance = (ManagerBase) Activator.CreateInstance(typeof(T));
			
			this.managersList.Add(instance);
			
			instance.Awake(this);
			
			return (T) instance;
		}
		
		public T GetSettings<T>() where T : SettingsBase {
			// Check if the file already loaded.
			foreach (var s in this.settingsLoaded) {
				if (s is T) {
					return (T) Convert.ChangeType(s, typeof (T));
				}
			}
			
			var instance = Resources.Load<SettingsBase>("Settings/" + typeof(T).Name);
			
			this.settingsLoaded.Add(instance);
			
			instance.Awake();
			
			return (T) instance;
		}
	}
}