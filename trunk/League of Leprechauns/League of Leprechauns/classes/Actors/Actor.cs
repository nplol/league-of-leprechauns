using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace League_of_Leprechauns
{
    // TODO
    //  * Løse texture problemstillingen.
    //      - Hvor skal vi ha animasjonen
    //      - Skal den øverste klassen støtte animasjon? Eller skal vi ha det i en subklasse
    //
    //  * Finne en løsning på hvordan Scale skal fungere. Dette er mht platformer (Steffen)
    //
    //  * Skrive noe kode slik at vi kan teste at actor fungerer som den skal.
    //    Vi burde derfor prøve å få lagt Actor inn i et "test"-prosjekt

    class Actor
      
    {
        static List<Actor> ListOfAllActors;
        private SpriteEffects spriteEffect;
        private Texture2D texture; // TODO: Hvordan løser vi dette mht animasjon? Enkelte sprites skal animeres og andre ikke.
        private Rectangle frame;

        public float Depth
        {
            set;
            get;
        }

        public Vector2 Origin
        {
            get { return new Vector2(texture.Width / 2, texture.Height / 2); }

        }

        public Vector2 Position
        {
            get;
            set;
        }

        public float Rotation
        {
            get;
            set;
        }

        public float Scale
        {
            get;
            set;
        }


        public void flipHorizontally()
        {
            if (spriteEffect == SpriteEffects.FlipHorizontally)
                spriteEffect = SpriteEffects.None;
            else
                spriteEffect = SpriteEffects.FlipHorizontally;
        }


        static Actor()
        {
            ListOfAllActors = new List<Actor>();
        }

        public Actor(Texture2D texture)
        {
            ListOfAllActors.Add(this);
            this.texture = texture;
            frame = new Rectangle(0, 0, texture.Width, texture.Height); // TODO: Midlertidig løsning. Den øverste klassen skal kanskje ikke støtte animasjon?
            spriteEffect = SpriteEffects.None;
            Depth = 0.0f;
            Scale = 1.0f;
            Rotation = 0.0f;
            Position = new Vector2(0, 0);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, frame, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }
    }
}