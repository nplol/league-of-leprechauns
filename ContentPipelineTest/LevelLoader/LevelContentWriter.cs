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
using ContentPipelineTest;

namespace LevelLoader
{
    [ContentTypeWriter]
    public class LevelContentWriter : ContentTypeWriter<Level>
    {

        protected override void Write(ContentWriter output, Level value)
        {
            output.Write(value.Name);
            output.Write(value.BackgroundAsset);
            output.Write(value.SoundThemeAsset);

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
