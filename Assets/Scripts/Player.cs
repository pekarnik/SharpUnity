using System;
using System.Collections;
using UnityEngine;
using static System.Diagnostics.Debug;
namespace Geekbrains
{
    public abstract class Player : MonoBehaviour, IDisposable
    {
        public float Speed = 3.0f;
        private Rigidbody _rigidbody;
        private Material _material;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponent<Renderer>().material;
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            _rigidbody.AddForce(movement * Speed);
        }
        public void BecomeImmortal(float time)
		{
            StartCoroutine(nameof(Blinking), time);
        }
        IEnumerator Blinking(float time)
        {
            Color c = _material.color;
            float curTime = 0;

            while (true)
            {
                _material.color = c;

                if (c.a == 1.0f)
                {
                    c.a = 0.0f;
                }
                else
                    c.a = 1.0f;
                curTime += 0.2f;
                if(curTime < time)
                {
                    yield return new WaitForSeconds(0.2f);
                }
                else
				{
                    c.a = 1.0f;
                    _material.color = c;
                    break;
				}
            }
        }

		public void Dispose()
		{
            Debug.Log("player died");
            Destroy(gameObject);
		}
	}
}
