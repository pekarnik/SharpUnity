﻿using System;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public sealed class CreateWayPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private PathBot _rootWayPoint;

        public void InstantiateObj(Vector3 pos)
        {
            if (!_rootWayPoint)
            {
                _rootWayPoint = new GameObject("WayPoint").AddComponent<PathBot>();
            }

            if (_prefab != null)
            {
                Instantiate(_prefab, pos, Quaternion.identity, _rootWayPoint.transform);
            }
            else
            {
                throw new Exception($"Нет префаба на компоненте {typeof(CreateWayPoint)} {gameObject.name}");
            }
        }
    }

}
