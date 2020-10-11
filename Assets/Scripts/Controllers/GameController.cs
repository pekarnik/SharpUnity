using Assets.Scripts.Model;
using Assets.Scripts.View;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
	class GameController : MonoBehaviour, IDisposable
	{
		private ListExecuteObject _interactiveObject;
		private CameraController _cameraController;
		private DisplayEndGame _displayEndGame;
		private DisplayBonuses _displayBonuses;
		private DisplayWinGame _displayWinGame;
		private InputController _inputController;
		private Reference _reference;
		private int _countBonuses;
		private int _bonusGOCount;

		private void Awake()
		{
			_interactiveObject = new ListExecuteObject();

			_reference = new Reference();

			PlayerBase player = _reference.PlayerBall;

			_cameraController = new CameraController(_reference.PlayerBall.transform, _reference.MainCamera.transform);
			_interactiveObject.AddExecuteObject(_cameraController);


			if (Application.platform == RuntimePlatform.WindowsEditor)
			{
				_inputController = new InputController(_reference.PlayerBall);
				_interactiveObject.AddExecuteObject(_inputController);
			}

			_displayEndGame = new DisplayEndGame(_reference.EndGame);
			_displayBonuses = new DisplayBonuses(_reference.Bonus);
			_displayWinGame = new DisplayWinGame(_reference.Win);
			foreach (var o in _interactiveObject)
			{
				if(o is BadBonus badBonus)
				{
					badBonus.OnCaughtPlayerChange += CaughtPlayer;
					badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
				}

				if(o is GoodBonus goodBonus)
				{
					goodBonus.onPointChange += AddBonus;
					_bonusGOCount++;
				}
			}

			_reference.RestartButton.onClick.AddListener(RestartGame);
			_reference.RestartButton.gameObject.SetActive(false);
		}

		private void RestartGame()
		{
			SceneManager.LoadScene(0);
			Time.timeScale = 1.0f;
		}

		private void CaughtPlayer(string value, Color Args)
		{
			_reference.RestartButton.gameObject.SetActive(true);
			Time.timeScale = 0.0f;
		}

		private void AddBonus(int value)
		{
			_countBonuses += value;
			_displayBonuses.Display(_countBonuses);

			_bonusGOCount--;
			if (_bonusGOCount == 0)
			{
				Time.timeScale = 0.0f;
				_reference.RestartButton.gameObject.SetActive(true);
				_displayWinGame.GameOver();
			}
		}

		private void Update()
		{
			for(var i = 0; i < _interactiveObject.Length; i++)
			{
				var interactiveObject = _interactiveObject[i];
				if(interactiveObject == null)
				{
					continue;
				}
				interactiveObject.Execute();
			}
		}

		public void Dispose()
		{
			foreach(var o in _interactiveObject)
			{
				if(o is BadBonus badBonus)
				{
					badBonus.OnCaughtPlayerChange -= CaughtPlayer;
					badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
				}

				if(o is GoodBonus goodBonus)
				{
					goodBonus.onPointChange -= AddBonus;
				}
			}
		}
	}
}
