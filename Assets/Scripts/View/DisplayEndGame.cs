using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
	public sealed class DisplayEndGame
	{
		private Text _finishGameLabel;

		public DisplayEndGame()
		{

		}

		public void GameOver(string name, Color color)
		{
			_finishGameLabel.text = $"Вы проиграли. Вас убил {name} {color} цвета";
		}
	}
}
