using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Platformer
{
    static class InputKeyManager
    {
        [FlagsAttribute]
        public enum Triggers : ulong
        {
            LeftArrow = 0x0000000000000001,
            RightArrow = 0x0000000000000002,
            UpArrow = 0x0000000000000004,
            DownArrow = 0x0000000000000008,
            Fire = 0x0000000000000010,
            ExitLevel = 0x0000000000000020,
            Pause = 0x0000000000000040
            // Add new triggers below here...
        }

        private static GamePadState previousGamePadState = new GamePadState();
        private static Triggers lastKeyValuesRead;

        /// <summary>
        /// The input routine transforms input key or mouse values into trigger values as appropriate.
        /// </summary>
        /// <returns>Trigger value(s) representing the input condition(s).</returns>
        static public Triggers Read()
        {
            Triggers currentKeyState = 0;

            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape) || ((previousGamePadState.Buttons.Back != ButtonState.Pressed) && (gamepadState.Buttons.Back == ButtonState.Pressed)))
                currentKeyState |= Triggers.ExitLevel;

            if (keyboardState.IsKeyDown(Keys.Down))
                currentKeyState |= Triggers.DownArrow;

            if (keyboardState.IsKeyDown(Keys.Up))
                currentKeyState |= Triggers.UpArrow;

            if (keyboardState.IsKeyDown(Keys.Right))
                currentKeyState |= Triggers.RightArrow;

            if (keyboardState.IsKeyDown(Keys.Left))
                currentKeyState |= Triggers.LeftArrow;

            if (keyboardState.IsKeyDown(Keys.Space))
                currentKeyState |= Triggers.Fire;

            if (keyboardState.IsKeyDown(Keys.Pause))
                currentKeyState |= Triggers.Pause;

            if (gamepadState.DPad.Down == ButtonState.Pressed)
                currentKeyState |= Triggers.DownArrow;

            if (gamepadState.DPad.Up == ButtonState.Pressed)
                currentKeyState |= Triggers.UpArrow;

            if (gamepadState.DPad.Right == ButtonState.Pressed)
                currentKeyState |= Triggers.RightArrow;

            if (gamepadState.DPad.Left == ButtonState.Pressed)
                currentKeyState |= Triggers.LeftArrow;

            if (gamepadState.Buttons.A == ButtonState.Pressed)
                // This is the big Zunepad button
                currentKeyState |= Triggers.Fire;

            if ((previousGamePadState.Buttons.B != ButtonState.Pressed) && (gamepadState.Buttons.B == ButtonState.Pressed))
                // This is the forward key next to the Zunepad button
                currentKeyState |= Triggers.Pause;

            previousGamePadState = gamepadState;

            lastKeyValuesRead = currentKeyState;

            return currentKeyState;
        }
    }
}