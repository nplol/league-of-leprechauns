using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using LoL;

namespace LoL.Content
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content
    /// Pipeline to read the specified data type from binary .xnb format.
    /// 
    /// Unlike the other Content Pipeline support classes, this should
    /// be a part of your main game project, and not the Content Pipeline
    /// Extension Library project.
    /// </summary>
    public class LevelContentReader : ContentTypeReader<Level>
    {
        protected override Level Read(ContentReader input, Level existingInstance)
        {
            Level level = new Level();

            level.Name = input.ReadString();
            level.BackgroundAsset = input.ReadString();
            level.SoundThemeAsset = input.ReadString();

            while (true)
            {
                try
                {
                    string actorType = input.ReadString();
                    Vector2 position = input.ReadVector2();
                    level.addEvent(new LevelEvent(actorType, position));
                }
                catch (System.IO.EndOfStreamException ex)
                {
                    break;
                }
            }

            return level;
        }
    }
}
