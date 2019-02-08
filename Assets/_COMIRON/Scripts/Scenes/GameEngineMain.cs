using COMIRON.GameFramework.Core;
using COMIRON.Managers.ManagerTrees;
using COMIRON.Managers.ManagerMap;
using COMIRON.Managers.ManagerRoads;
using COMIRON.Settings;
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
			var settingsMap = this.GetSettings<SettingsMap>();
			
			var managerRoads = this.GetManager<ManagerRoads>();
			var managerTrees = this.GetManager<ManagerTrees>();

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

			//managerRoads.CreateControllerRoadCorner(groundStartPosition + new Vector3(30, 0.1f, 30));
			//managerRoads.CreateControllerRoadStraight(groundStartPosition + new Vector3(30, 0.1f, 30 + 7.62f));
			var roadCreateResult = this.CreateRoad(RoadDirection.Up, groundStartPosition + new Vector3(40, 0.1f, 30), 5);
			this.CreateTree(roadCreateResult.roadFinalPosition, Direction.Right);
			roadCreateResult = this.CreateRoad(RoadDirection.Right, roadCreateResult.roadFinalPosition, 5, 1);
			this.CreateTree(roadCreateResult.roadFinalPosition, Direction.Left);
			roadCreateResult = this.CreateRoad(RoadDirection.Down, roadCreateResult.roadFinalPosition, 5, 1);
			this.CreateTree(roadCreateResult.roadFinalPosition, Direction.Left);
			roadCreateResult = this.CreateRoad(RoadDirection.Left, roadCreateResult.roadFinalPosition, 5, 1);
			this.CreateTree(roadCreateResult.roadFinalPosition, Direction.Right);
		}
		
		protected override void Update() {
			
		}
		
		protected override void FixedUpdate() {
			
		}

		private void CreateTree(Vector3 position, Direction directionTree){
			var managerTrees = this.GetManager<ManagerTrees>();

			Quaternion treeQuaternion;
			ControllerBase controller;
			switch (directionTree) {
				case Direction.Left:
					treeQuaternion = Quaternion.Euler(0, -90, 0);
					controller = managerTrees.CreateControllerCtree(position + new Vector3(10, 0, 0));
					break;
				case Direction.Right:
					treeQuaternion = Quaternion.Euler(0, 90, 0);
					controller = managerTrees.CreateControllerLtree(position + new Vector3(-10, 0, 0));
					break;
				default:
					treeQuaternion = Quaternion.Euler(0, -90, 0);
					controller = managerTrees.CreateControllerCtree(position + new Vector3(10, 0, 0));
					break;
			}
			controller.transform.localRotation = treeQuaternion;
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
			
		private struct RoadCreateResult {
			public Vector3 roadFinalPosition;
		}
		
		private enum RoadDirection {
			Up,
			Down,
			Left,
			Right,
		}

		private enum Direction
		{
			Left,
			Right,
		}
	}
}