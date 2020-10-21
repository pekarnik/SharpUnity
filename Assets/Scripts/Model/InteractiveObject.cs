using Assets.Scripts.Interfaces;
using UnityEngine;
using static UnityEngine.Random;

namespace Assets.Scripts.Model
{
	public abstract class InteractiveObject : MonoBehaviour, IExecute
	{
		protected Color _color;
		private bool _isInteractible;

		[SerializeField] private bool _isAllowScaling;
		[SerializeField] private float ActiveDis;

		//……….

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "bot.jpg", _isAllowScaling);
		}

		private void OnDrawGizmosSelected()
		{
#if UNITY_EDITOR
			Transform t = transform;

			//Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
			//Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

			var flat = new Vector3(ActiveDis, 0, ActiveDis);
			Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
			Gizmos.DrawWireSphere(Vector3.zero, 5);
#endif
		}

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
