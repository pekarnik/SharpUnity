using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class PlayerBall : Player
    {
        private void FixedUpdate()
        {
            Move();
        }

    }

}