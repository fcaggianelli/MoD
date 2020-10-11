using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace monster.world
{
    public class Cell : MonoBehaviour
    {
        public SpriteRenderer sp;
        public Sprite playerSprite;
        public Sprite blankSprite;

        private int _x;
        private int _y;
        private bool playerInside = false;

        public bool PlayerInside { get => playerInside; }
        public int X { get => _x; }
        public int Y { get => _y; }

        public void Initialize(int x, int y)
        {
            transform.localPosition = new Vector3(x, y, 0);
            this.name = "Cell [" + x + "][" + y + "]";
            _x = x;
            _y = y;
        }
    }
}

