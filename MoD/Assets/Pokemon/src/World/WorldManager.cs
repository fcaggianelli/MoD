using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using monster.player;

namespace monster.world
{
    public class WorldManager : MonoBehaviour
    {
        #region Singleton
        private static WorldManager _instance;
        public static WorldManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<WorldManager>();
                }
                return _instance;
            }
        }
        #endregion
        public GameObject cellPrefab;

        private Cell[][] cells;
        private Player player;

        private void Awake()
        {
            _instance = GetComponent<WorldManager>();
        }

        public void GenerateWorld()
        {
            int randomX = Random.Range(0, 64);
            int randomY = Random.Range(0, 64);
            

            cells = new Cell[64][];
            for (int i = 0; i < 64; i++)
            {
                cells[i] = new Cell[64];
                for (int j = 0; j < 64; j++)
                {
                    cells[i][j] = Instantiate(cellPrefab, this.transform).GetComponent<Cell>();
                    cells[i][j].Initialize(i, j);
                }
            }
            player = new Player(randomX, randomY, cells[randomX][randomY]);
            Camera.main.transform.localPosition = new Vector3(randomX, randomY, -10);
        }

        public void Move(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.UpArrow:
                    player.LastCell = player.CurrentCell;
                    player.CurrentCell = cells[player.CurrentCell.X][player.CurrentCell.Y + 1];
                    
                    break;
                case KeyCode.DownArrow:
                    player.LastCell = player.CurrentCell;
                    player.CurrentCell = cells[player.CurrentCell.X][player.CurrentCell.Y - 1];

                    break;
                case KeyCode.RightArrow:
                    player.LastCell = player.CurrentCell;
                    player.CurrentCell = cells[player.CurrentCell.X + 1][player.CurrentCell.Y];

                    break;
                case KeyCode.LeftArrow:
                    player.LastCell = player.CurrentCell;
                    player.CurrentCell = cells[player.CurrentCell.X - 1][player.CurrentCell.Y];

                    break;
            }
            //Camera.main.transform.localPosition = new Vector3(player.CurrentCell.X, player.CurrentCell.Y, -10);
        }

    }
}

