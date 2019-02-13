using System.Collections;
using System.Collections.Generic;
using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerClouds;
using UnityEngine;

public class SettingsClouds : SettingsBase {
	[SerializeField]
	private ControllerCloud controllerCloudPrefab;

	enum Clouds {
		Name
	}

	protected override void AwakeInherit() {

	}

	public string GetCloudNameFromPrefag(System.Enum numberCloud) {
		return this.GetPref<ControllerCloud>(numberCloud).name;
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

}