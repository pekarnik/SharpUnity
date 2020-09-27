﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private List<InteractiveObject> _interactiveObjects;
        private int numOfGoodBonuses;
        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            var displayBonuses = new DisplayBonuses();
            foreach (var interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(displayBonuses);
                if(interactiveObject is GoodBonus)
				{
                    numOfGoodBonuses++;
                    interactiveObject.OnDestroyChange += OnGoodBonusTake;
				}
                
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
            }
        }
        private void OnGoodBonusTake(InteractiveObject value)
		{
            numOfGoodBonuses--;
        }
		private void Start()
		{
            MainObjects.Player = FindObjectOfType<Player>();
		}
		private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            if (value is GoodBonus)
            {
                value.OnDestroyChange -= OnGoodBonusTake;
                if(numOfGoodBonuses == 0)
				{
                    Win();
				}
            }
            _interactiveObjects.Remove(value);
           
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }
        public void Win()
		{
            Debug.Log("Победа");
            Destroy(MainObjects.Player);
		}
        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }
    }
}
