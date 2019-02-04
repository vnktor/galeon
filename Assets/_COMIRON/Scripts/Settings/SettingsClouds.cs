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
}