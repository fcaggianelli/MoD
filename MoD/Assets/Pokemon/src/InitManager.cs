using UnityEngine;
using monster.world;
using monster.input;

namespace monster.controller
{
    public class InitManager : MonoBehaviour
    {
        public InputManager inputManager;
        public GameManager gameManager;

        private void Awake()
        {
            gameManager.Init();
            // fine degli init input
            inputManager.Init(gameManager.PlayerDirectionInputHandler);           

        }
    }
}

