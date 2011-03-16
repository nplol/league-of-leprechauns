using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

// TODO: replace this with the type you want to write out.
using LoL.Content;

namespace LoL.ContentImporter
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to write the specified data type into binary .xnb format.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    /// </summary>
    [ContentTypeWriter]
    public class LevelContentWriter : ContentTypeWriter<Level>
    {
        /// <summary>
        /// Writes a level from .xml to an asset file(.xnb).
        /// </summary>
        /// <param name="output"></param>
        /// <param name="value"></param>
        protected override void Write(ContentWriter output, Level value)
        {
            output.Write(value.Name);
            output.Write(value.BackgroundAsset);
            output.Write(value.SoundThemeAsset);
            output.Write(value.LevelSize);

            foreach (LevelEvent le in value.events)
            {
                output.Write(le.ActorType);
                output.Write(le.Position);
            }
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(LevelContentReader).AssemblyQualifiedName;
        }
    }
}
