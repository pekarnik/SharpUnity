using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
	public sealed class DisplayWinGame
	{
		private Text _finishGameLabel;

		public DisplayWinGame(GameObject endGame)
		{
			_finishGameLabel = endGame.GetComponentInChildren<Text>();
			_finishGameLabel.text = String.Empty;

		}

		public void GameOver()
		{
			_finishGameLabel.text = $"Вы выиграли.";
		}
	}
}
