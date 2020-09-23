using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker, IEquatable<GoodBonus>
    {
        public int Point;
        private Material _material;
        private float _lengthFlay;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(0.5f, 1.0f);
        }

        protected override void Interaction()
        {
            _view.Display(Point);
            // Add bonus
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }

        //.....

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }
    }
}
