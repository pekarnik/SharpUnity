using Assets.Scripts.Interfaces;
using Assets.Scripts.Model;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
	public sealed class InputController:IExecute
	{
		private readonly PlayerBase _playerBase;
		private ListExecuteObject _interactiveObject;
		private CameraController _cameraController;
		private InputController _inputController;

		public InputController(PlayerBase player)
		{
			_playerBase = player;
		}

		public void Execute()
		{
			_playerBase.Move(Input.GetAxis("Horizontal"), 0.0f,
				Input.GetAxis("Vertical"));
		}
	}
}
