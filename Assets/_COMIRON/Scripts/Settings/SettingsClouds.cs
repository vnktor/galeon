using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerClouds;
using UnityEngine;

public class SettingsClouds : SettingsBase {
	[SerializeField]
	private ControllerCloud controllerCloudPrefab;

	protected override void AwakeInherit() {

	}

	public ControllerCloud GetControllerCloudPrefab() {
		return this.controllerCloudPrefab;
	}

	public string GetCloudName(string slot) {
		return this.GetPref<string>(Clouds.Name, null, slot);
	}
	   
	public void SetCloudName(string name, string slot) {
		this.SetPref(Clouds.Name, name, slot);
	}

	private enum Clouds {
		Name
	}

}