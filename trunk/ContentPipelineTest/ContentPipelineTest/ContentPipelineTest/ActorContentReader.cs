using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace ContentPipelineTest
{
    public class ActorContentReader : ContentTypeReader<Actor>
    {
        protected override Actor Read(ContentReader input, Actor existingInstance)
        {
            Actor actor = new Actor();

            actor.Position = input.ReadVector2();
            actor.Rotation = input.ReadSingle();
            actor.Scale = input.ReadVector2();
            actor.TextureAsset = input.ReadString();
            
            actor.Load(input.ContentManager);

            return actor;
        }
    }
}
