using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
using static UnityEngine.Random;

namespace Assets.Scripts.Model
{
	public sealed class BadBonus : InteractiveObject, IFlay, IRotation
	{
		public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };
		private float _lengthFlay;
		private float _speedRotation;

		private void Awake()
		{
			_lengthFlay = Range(1.0f, 5.0f);
			_speedRotation = Range(10.0f, 50.0f);
		}

		protected override void Interaction()
		{
			OnCaughtPlayerChange.Invoke(gameObject.name, _color);
		}

		public override void Execute()
		{
			if (!IsInteractable) { return; }
			Flay();
			Rotation();
		}
		public void Flay()
		{
			transform.localPosition = new Vector3(transform.localPosition.x,
				Mathf.PingPong(Time.time, _lengthFlay),
				transform.localPosition.z);
		}

		public void Rotation()
		{
			transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation),
				Space.World);
		}
	}
}
