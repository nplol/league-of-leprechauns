using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace LoL
{
    /*The class InputManager uses the singelton pattern.
     *  To use it, reference the Instance property */
    class InputManager
    {
        private GamePadState[] currentPadStates;
        private GamePadState[] lastPadStates;
        private KeyboardState currentKeyState;
        private KeyboardState lastKeyState;

        private int numPlayers;

        private static InputManager instance;

        public static InputManager GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager(2);
                }
                return instance;
            }
        }

        private InputManager(int players)
        {
            numPlayers = players;
            currentPadStates = new GamePadState[players];
            lastPadStates = new GamePadState[players];
            currentKeyState = new KeyboardState();
            lastKeyState = new KeyboardState();
        }

        public void Update(GameTime gameTime)
        {
            //GamePad
            for (int i = (int)PlayerIndex.One; i < (int)PlayerIndex.One + numPlayers; i++)
            {
                lastPadStates[i] = currentPadStates[i];
            }

            for (int i = (int)PlayerIndex.One; i < (int)PlayerIndex.One + numPlayers; i++)
            {
                currentPadStates[i] = GamePad.GetState((PlayerIndex)i);
            }

            //Keyboard
            lastKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
        }

        public bool IsButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return currentPadStates[(int)playerIndex - (int)PlayerIndex.One].IsButtonDown(button);
        }

        public bool IsButtonPress(Buttons button, PlayerIndex playerIndex)
        {
            return currentPadStates[(int)playerIndex - (int)PlayerIndex.One].IsButtonUp(button) &&
                   lastPadStates[(int)playerIndex - (int)PlayerIndex.One].IsButtonDown(button);
        }

        public bool IsKeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        public bool IsKeyPress(Keys key)
        {
            return currentKeyState.IsKeyUp(key) && lastKeyState.IsKeyDown(key);
        }

        public float GetMovementX(PlayerIndex playerIndex)
        {
            return currentPadStates[(int)playerIndex].ThumbSticks.Left.X;
        }

        public float GetMovementY(PlayerIndex playerIndex)
        {
            return currentPadStates[(int)playerIndex].ThumbSticks.Left.Y;
        }
    }
}