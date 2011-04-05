
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

        /// <summary>
        /// Updates the gamepadstates and keyboardstate
        /// </summary>
        /// <param name="gameTime"></param>
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

        /// <summary>
        /// Checks if the given button is down on the gamepad
        /// </summary>
        /// <param name="button">The button to check</param>
        /// <param name="playerIndex">Index of the gamepad</param>
        /// <returns></returns>
        public bool IsButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return currentPadStates[(int)playerIndex - (int)PlayerIndex.One].IsButtonDown(button);
        }

        /// <summary>
        /// Check if the given button was pressed on the gamepad
        /// </summary>
        /// <param name="button">The button to check</param>
        /// <param name="playerIndex">Index of the gamepad</param>
        /// <returns></returns>
        public bool IsButtonPress(Buttons button, PlayerIndex playerIndex)
        {
            return currentPadStates[(int)playerIndex - (int)PlayerIndex.One].IsButtonDown(button) &&
                   !lastPadStates[(int)playerIndex - (int)PlayerIndex.One].IsButtonDown(button);
        }

        /// <summary>
        /// Check if the given key is down on the keyboard.
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key)
        {
            return currentKeyState.IsKeyDown(key);
        }

        /// <summary>
        /// Check if the given key was pressed on the keyboard.
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns></returns>
        public bool IsKeyPress(Keys key)
        {
            return currentKeyState.IsKeyDown(key) && !lastKeyState.IsKeyDown(key);
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