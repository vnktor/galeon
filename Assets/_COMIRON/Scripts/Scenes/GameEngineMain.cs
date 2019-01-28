﻿using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerMainBuilding;
using COMIRON.Managers.ManagerMap;
using COMIRON.Managers.ManagerRoads;
using COMIRON.Settings;
using COMIRON.Ui;
using COMIRON.Ui.Panels;
using UnityEngine;
using UnityEngine.EventSystems;

namespace COMIRON.Scenes {
	public class GameEngineMain : GameEngineBase {
		[SerializeField]
		private Camera cameraMain;
		[SerializeField]
		private EventSystem hashEventSystem;
		
		protected override void AwakeInherit() {
			var managerMap = this.GetManager<ManagerMap>();
			var managerMainBuilding = this.GetManager<ManagerMainBuilding>();
			var settingsMap = this.GetSettings<SettingsMap>();
			
			
			var groundStartPosition = settingsMap.GetGroundStartPosition();
			var groundCols = settingsMap.GetGroundColumnsCount();
			var groundRows = settingsMap.GetGroundRowsCount();
			var groundWidth = settingsMap.GetGroundWidth();
			var groundLength = settingsMap.GetGroundLength();
			for (int row = 0; row < groundRows; row++) {
				for (int col = 0; col < groundCols; col++) {
					managerMap.CreateControllerGround(groundStartPosition + new Vector3(col * groundWidth, 0, row * groundLength));
				}
			}
			
			
			var roadCreateResult = this.CreateRoad(RoadDirection.Up, groundStartPosition + new Vector3(40, 0.1f, 30), 5);
			roadCreateResult = this.CreateRoad(RoadDirection.Right, roadCreateResult.roadFinalPosition, 5, 1);
			roadCreateResult = this.CreateRoad(RoadDirection.Down, roadCreateResult.roadFinalPosition, 5, 1);
			this.CreateRoad(RoadDirection.Left, roadCreateResult.roadFinalPosition, 5, 1);
			
			
			var controllerMainBuilding = managerMainBuilding.CreateControllerMainBuilding(groundStartPosition + new Vector3((groundCols - 1) / 2f * groundWidth, 0, (groundRows / 2f - 1) * groundLength));
			controllerMainBuilding.OnActionClick += delegate {
				this.ShowPanelMainBuildingInfo();
			};
		}
		
		protected override void Update() {
			
		}
		
		protected override void FixedUpdate() {
			
		}
		
		private RoadCreateResult CreateRoad(RoadDirection roadDirection, Vector3 startPosition, int length, int offset = 0) {
			var managerRoads = this.GetManager<ManagerRoads>();
			
			Quaternion roadRotation = Quaternion.identity;
			Vector3 roadAddPositionDirection = Vector3.zero;
			switch (roadDirection) {
				case RoadDirection.Up:
					roadRotation = Quaternion.Euler(0, 90, 0);
					roadAddPositionDirection = new Vector3(0, 0, 1);
					break;
				case RoadDirection.Down:
					roadRotation = Quaternion.Euler(0, 90, 0);
					roadAddPositionDirection = new Vector3(0, 0, -1);
					break;
				case RoadDirection.Right:
					roadRotation = Quaternion.Euler(0, 0, 0);
					roadAddPositionDirection = new Vector3(1, 0, 0);
					break;
				case RoadDirection.Left:
					roadRotation = Quaternion.Euler(0, 0, 0);
					roadAddPositionDirection = new Vector3(-1, 0, 0);
					break;
			}
			
			for (int i = offset; i < length + offset; i++) {
				var controllerRoadStraight = managerRoads.CreateControllerRoadStraight(
					startPosition + new Vector3(0, 0.1f, 0) + roadAddPositionDirection * 7.62f * i
				);
				
				controllerRoadStraight.transform.localRotation = roadRotation;
			}
			
			var controllerRoadCorner = managerRoads.CreateControllerRoadCorner(
				startPosition + new Vector3(0, 0.1f, 0) + roadAddPositionDirection * 7.62f * (length + offset)
			);
			
			var cornerPosition = controllerRoadCorner.transform.position;
			return new RoadCreateResult {
				roadFinalPosition = new Vector3(
					cornerPosition.x,
					startPosition.y,
					cornerPosition.z
				),
			};
		}
		
		private void ShowPanelMainBuildingInfo() {
			var panelMainBuildingInfo = this.GetCanvasByClass<CanvasInterface>().AddPanel<PanelMainBuildingInfo>();
			panelMainBuildingInfo.OnActionButtonCloseClick += delegate {
				GameObject.Destroy(panelMainBuildingInfo.gameObject);
			};
			
			panelMainBuildingInfo.Enable();
		}
		
		private struct RoadCreateResult {
			public Vector3 roadFinalPosition;
		}
		
		private enum RoadDirection {
			Up,
			Down,
			Left,
			Right,
		}
	}
}