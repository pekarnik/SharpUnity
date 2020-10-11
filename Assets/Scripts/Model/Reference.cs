﻿using Geekbrains;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Model
{
	public class Reference
	{
		private PlayerBall _playerBall;
		private Camera _mainCamera;
		private GameObject _bonus;
		private GameObject _endGame;
		private Canvas _canvas;
		private Button _restartButton;
		private GameObject _win;

		public Button RestartButton
		{
			get
			{
				if(_restartButton == null)
				{
					var gameObject = Resources.Load<Button>("UI/RestartButton");
					_restartButton = Object.Instantiate(gameObject, Canvas.transform);
				}
				return _restartButton;
			}
		}

		public GameObject Win
		{
			get
			{
				if (_win == null)
				{
					var gameObject = Resources.Load<GameObject>("UI/WinGame");
					_win = Object.Instantiate(gameObject, Canvas.transform);
				}

				return _win;
			}
		}

		public Canvas Canvas
		{
			get
			{
				if(_canvas == null)
				{
					_canvas = Object.FindObjectOfType<Canvas>();
				}
				return _canvas;
			}
		}

		public GameObject Bonus
		{
			get
			{
				if(_bonus == null)
				{
					var gameObject = Resources.Load<GameObject>("UI/GoodBonus");
					_bonus = Object.Instantiate(gameObject, Canvas.transform);
				}

				return _bonus;
			}
		}

		public GameObject EndGame
		{
			get
			{
				if(_endGame == null)
				{
					var gameObject = Resources.Load<GameObject>("UI/EndGame");
					_endGame = Object.Instantiate(gameObject, Canvas.transform);
				}

				return _endGame;
			}
		}
		public PlayerBall PlayerBall
		{
			get
			{
				if(_playerBall == null)
				{
					var gameObject = Resources.Load<PlayerBall>("Player");
					_playerBall = Object.Instantiate(gameObject);
				}
				return _playerBall;
			}
		}
		public Camera MainCamera
		{
			get
			{
				if(_mainCamera == null)
				{
					_mainCamera = Camera.main;
				}
				return _mainCamera;
			}
		}
	}
}
