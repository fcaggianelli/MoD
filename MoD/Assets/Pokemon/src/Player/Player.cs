using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using monster.world;

namespace monster.player
{
    public class Player
    {
        private int _x;
        private int _y;

        private Cell lastCell;
        private Cell currentCell;

        public Cell LastCell
        {
            get
            {
                return LastCell;
            }
            set
            {
                lastCell = value;
                lastCell.sp.sprite = lastCell.blankSprite;
            }
        }
        
        public Cell CurrentCell {
            get
            {
                return currentCell;
            }
            set
            {
                currentCell = value;
                currentCell.sp.sprite = currentCell.playerSprite;
            }
        }

        public Player(int x, int y, Cell cell)
        {
            _x = x;
            _y = y;
            lastCell = cell;
            CurrentCell = cell;
        }


    }
}

