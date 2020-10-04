using Assets.Scripts.Interfaces;
using UnityEngine;
using static UnityEngine.Random;

namespace Assets.Scripts.Model
{
	public abstract class InteractiveObject : MonoBehaviour, IExecute
	{
		protected Color _color;
		private bool _isInteractible;
		protected bool IsInteractable
		{
			get { return _isInteractible; }
			private set
			{
				_isInteractible = value;
				GetComponent<Renderer>().enabled = _isInteractible;
				GetComponent<Collider>().enabled = _isInteractible;
			}
		}
		private void OnTriggerEnter(Collider other)
		{
			if(!IsInteractable || !other.CompareTag("Player"))
			{
				return;
			}
			Interaction();
			IsInteractable = false;
		}
		protected abstract void Interaction();
		public abstract void Execute();
		private void Start()
		{
			IsInteractable = true;
			_color = ColorHSV();
			if(TryGetComponent(out Renderer renderer))
			{
				renderer.material.color = _color;
			}
		}
	}
}
