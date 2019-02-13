using System;
using System.Collections.Generic;
using COMIRON.GameFramework.Links;
using COMIRON.GameFramework.Ui;
using COMIRON.GameFramework.Soc;
using UnityEngine;

namespace COMIRON.GameFramework.Core {
	public abstract class GameEngineBase : MonoBehaviour {
		[SerializeField]
		private Transform[] canvasesContainers;

		private List<ManagerBase> managersList;
		private List<SettingsBase> settingsLoaded;
		private List<CanvasBase> canvasesList;
		private List<SocBase> socList;

		private void Awake() {
			this.managersList = new List<ManagerBase>();
			this.settingsLoaded = new List<SettingsBase>();
			this.socList = new List<SocBase>();
			this.canvasesList = new List<CanvasBase>();
			for (int i = 0; i < canvasesContainers.Length; i++) {
				CanvasBase[] canvasBase = canvasesContainers[i].GetComponentsInChildren<CanvasBase>(false);
				var count = canvasBase.Length;
				for (int j = 0; j < count; j++) {
					this.canvasesList.Add(canvasBase[j]);
				}
			}
			
			for (int i = 0; i < this.canvasesList.Count; i++) {
				var canvas = this.canvasesList[i];
				canvas.Initialize(this);
			}

			SocBase[] socBase = this.GetComponentsInChildren<SocBase>(false);
			for (int j = 0; j < socBase.Length; j++) {
				this.socList.Add(socBase[j]);
			}

			for (int i = 0; i < this.socList.Count; i++) {
				var soc = this.socList[i];
				soc.Initialize(this);
			}

			this.AwakeInherit();
		}
		
		protected abstract void AwakeInherit();
		protected abstract void Update();
		protected abstract void FixedUpdate();
		
		public T GetManager<T>() where T : ManagerBase {
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
		
		private string GetLinkPanelPath(System.Type typeOf) {
			string path = "Links/Ui/Panels/Link" + typeOf.Name;
			
			return path;
		}
		
		public LinkPanel GetLinkPanel<T>() where T : PanelBase {
			var typeOf = typeof(T);
			string path = this.GetLinkPanelPath(typeOf);
			
			LinkPanel linkPanel = Resources.Load<LinkPanel>(path);
			if (linkPanel == null) {
				Debug.LogWarning("GetLinkPanel. FILE ABSENT, " + ("filePath: " + path) + ("  type: " + typeOf) + "\r\n");
				
				return null;
			}
			
			return linkPanel;
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
		
		protected T GetCanvasByClass<T>() where T : CanvasBase {
			var count = this.canvasesList.Count;
			for (int i = 0; i < count; i++) {
				var canvas = this.canvasesList[i];
				if (canvas is T) {
					return (T) Convert.ChangeType(canvas, typeof (T));
				}
			}
		
			return default(T);
		}

		protected T GetSocByClass<T>() where T : SocBase {
			var count = this.socList.Count;
			for (int i = 0; i < count; i++) {
				var soc = this.socList[i];
				if (soc is T) {
					return (T)Convert.ChangeType(soc, typeof(T));
				}
			}
			return default(T);
		}
	}
}