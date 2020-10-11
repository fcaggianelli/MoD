using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace monster.input
{
    public class InputManager : MonoBehaviour
    {
        public GameManager gameManager;
        public event Action<KeyCode> directionInputEvent;

        private bool directionPressed = false;
        private bool actionPressed = false;

        private IEnumerator DirectionInputListener()
        {

            while (!directionPressed)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Debug.Log("down");
                    directionInputEvent?.Invoke(KeyCode.DownArrow);
                    isPressed();
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("up");
                    directionInputEvent?.Invoke(KeyCode.UpArrow);
                    isPressed();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Debug.Log("right");
                    directionInputEvent?.Invoke(KeyCode.RightArrow);
                    isPressed();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("left");
                    directionInputEvent?.Invoke(KeyCode.LeftArrow);
                    isPressed();
                }

                void isPressed()
                {
                    directionPressed = true;
                }
                yield return null;
            }
        }

        private IEnumerator ActionInputListener()
        {
            while (!actionPressed)
            {
                if(Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("a");

                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("b");
                }

                yield return null;
            }

        }

        public void Init(Action<KeyCode> @event)
        {
            directionInputEvent += @event;
            StartCoroutine(DirectionInputListener());
            StartCoroutine(ActionInputListener());
            
        }

    }
}

