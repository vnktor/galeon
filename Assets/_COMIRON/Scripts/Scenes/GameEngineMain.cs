using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerBuildings;
using COMIRON.Managers.ManagerMainBuilding;
using COMIRON.Managers.ManagerMap;
using COMIRON.Managers.ManagerRoads;
using COMIRON.Managers.ManagerTransport;
using COMIRON.Managers.ManagerClouds;
using COMIRON.Settings;
using COMIRON.Ui;
using COMIRON.Ui.Panels;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace COMIRON.Scenes {
	public class GameEngineMain : GameEngineBase {
		[SerializeField]
		private Camera cameraMain;
		[SerializeField]
		private EventSystem hashEventSystem;

		private int countFrame = 0;

		private List<GameObject>  destroyObject = new List<GameObject>();
		
		
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
			Vector3 startCloudPosition = roadCreateResult.roadFinalPosition;
			this.CreateBuilding(roadCreateResult.roadFinalPosition, Direction.Right);
			roadCreateResult = this.CreateRoad(RoadDirection.Right, roadCreateResult.roadFinalPosition, 5, 1);
			Vector3 endCloudPosition = roadCreateResult.roadFinalPosition;
			this.CreateBuilding(roadCreateResult.roadFinalPosition, Direction.Left);
			roadCreateResult = this.CreateRoad(RoadDirection.Down, roadCreateResult.roadFinalPosition, 5, 1);
			this.CreateBuilding(roadCreateResult.roadFinalPosition, Direction.Left);
			roadCreateResult = this.CreateRoad(RoadDirection.Left, roadCreateResult.roadFinalPosition, 5, 1);
			this.CreateBuilding(roadCreateResult.roadFinalPosition, Direction.Right);

			this.CreateClouds(startCloudPosition, endCloudPosition);


			this.GetCreatedCloudsInfo(destroyObject);

			var managerClouds = this.GetManager<ManagerClouds>();
			var objects = managerClouds.GetCreatedControllerCloud(destroyObject);
			this.DestroyObjectMy(objects[0].gameObject);
			Debug.Log(" Удалили облако 1");

			this.GetCreatedCloudsInfo(destroyObject);

			


			var controllerMainBuilding = managerMainBuilding.CreateControllerMainBuilding(groundStartPosition + new Vector3((groundCols - 1) / 2f * groundWidth, 0, (groundRows / 2f - 1) * groundLength));
			controllerMainBuilding.OnActionClick += delegate {
				this.ShowPanelMainBuildingInfo();
			};
		}


		protected override void Update() {
			if (countFrame < 5) {
				countFrame++;
			}

			if (countFrame == 1 || countFrame == 3) {
				this.GetCreatedCloudsInfo();
			}

			if (countFrame == 2) {
				var managerClouds = this.GetManager<ManagerClouds>();
				var objects = managerClouds.GetCreatedControllerCloud();
				this.DestroyObjectMy(objects[1].gameObject);
				Debug.Log(" Удалили облако 2");
			}

		}
		
		protected override void FixedUpdate() {
			
		}

		private void CreateBuilding(Vector3 position, Direction directionBuilding) {
			var managerBuildings = this.GetManager<ManagerBuildings>();

			Quaternion buildingQuaternion;
			ControllerBase controller;
			switch (directionBuilding) {
				case Direction.Left:
					buildingQuaternion = Quaternion.Euler(0, -90, 0);
					controller = managerBuildings.CreateControllerHouse(position + new Vector3(10, 0, 0));
					break;
				case Direction.Right:
					buildingQuaternion = Quaternion.Euler(0, 90, 0);
					controller = managerBuildings.CreateControllerShop(position + new Vector3(-10, 0, 0));
					break;
				default:
					buildingQuaternion = Quaternion.Euler(0, -90, 0);
					controller = managerBuildings.CreateControllerHouse(position + new Vector3(10, 0, 0));
					break;
			}
			controller.transform.localRotation = buildingQuaternion;
		}


		void DestroyObjectMy(GameObject obj) {
			Object.Destroy(obj);
			destroyObject.Add(obj);
		}


		private RoadCreateResult CreateRoad(RoadDirection roadDirection, Vector3 startPosition, int length, int offset = 0) {
			var managerRoads = this.GetManager<ManagerRoads>();
			var managerTransport = this.GetManager<ManagerTransport>();

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

			//Выводим машину в центр каждого угла
			managerTransport.CreateControllerCar04(
				startPosition + new Vector3(0, 0.15f, 0) + roadAddPositionDirection * 7.62f * (length + offset)
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

		private void CreateClouds(Vector3 startPosition, Vector3 endPosition) {
			var managerClouds = this.GetManager<ManagerClouds>();
			int countCloud = Random.Range(3, 5);
			
			for (int i = 0; i <= countCloud - 1; i++) {
				float x = startPosition.x + (endPosition.x - startPosition.x) * i / (countCloud - 1);
				float z = startPosition.z + (endPosition.z - startPosition.z) * i / (countCloud - 1);
				float y = 20f;
				Vector3 randomPosition = new Vector3(
					Random.Range(-3, 3),
					Random.Range(-3, 3),
					Random.Range(-3, 3)
				);
				var controllerCloud = managerClouds.CreateControllerCloud(new Vector3(x, y, z) + randomPosition);
				controllerCloud.OnActionClick += delegate {
					this.ShowPanelCloudInfo();
				};
			}
		}

		private void ShowPanelCloudInfo() {
			var panelCloudInfo = this.GetCanvasByClass<CanvasInterface>().AddPanel<PanelCloudInfo>();
			panelCloudInfo.OnActionButtonCloseClick += delegate {
				GameObject.Destroy(panelCloudInfo.gameObject);
			};

			panelCloudInfo.Enable();
		}

		private void GetCreatedCloudsInfo(List<GameObject> dObject=null) {
			string message = "";
			var managerClouds = this.GetManager<ManagerClouds>();
			var objects = managerClouds.GetCreatedControllerCloud(dObject);
			message += " Облаков : " + objects.Length.ToString() + " шт\n";
			
			for (int i = 0; i < objects.Length; i++) {
					message += " Облако №"
						+ (i + 1).ToString()
						+ " координаты ("
						+ objects[i].transform.position.x.ToString()
						+ ","
						+ objects[i].transform.position.y.ToString()
						+ ","
						+ objects[i].transform.position.z.ToString()
						+ ")\n";
				}
			Debug.Log(message);

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

		private enum Direction {
			Left,
			Right,
		}
	}
}