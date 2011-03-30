using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    /*
     * This class is used as a Factory for creating actors from strings
     * Primarily used by the LevelManager.
     */
    class ActorFactory
    {
        /// <summary>
        /// Method to create actor instances
        /// </summary>
        /// <param name="actorClassName">The textual name of the actor class</param>
        /// <param name="position">The start position of the actor</param>
        /// <param name="contentManager">Reference to the contentManager for loading textures</param>
        /// <returns>An actor instance</returns>
        public Actor createActor(string actorClassName, Vector2 position, ContentManager contentManager, string texturePath)
        {
            switch (actorClassName)
            {
                case "TutorialObject":
                    TutorialObject tutorialObject = new TutorialObject(position, false);
                    tutorialObject.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return tutorialObject;
                case "CollapsableBridge":
                    CollapsableBridge collapseableBridge = new CollapsableBridge(position);
                    collapseableBridge.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return collapseableBridge;
                case "Button":
                    Button button = new Button(position);
                    button.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return button;
                case "Door":
                    Door door = new Door(position);
                    door.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return door;
                case "BackgroundObject":
                    BackgroundObject backgroundObject = new BackgroundObject(position, false);
                    backgroundObject.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return backgroundObject;
                case "CabbageLips":
                    CabbageLips cabbageLips = new CabbageLips(position, 1, 100, 0, Settings.DEFAULT_JUMPFORCE);
                    cabbageLips.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return cabbageLips;
                case "DroppingPlatform":
                    DroppingPlatform droppingPlatform = new DroppingPlatform(position, 0f, 0);
                    droppingPlatform.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return droppingPlatform;
                case "FlufferNutter":
                    FlufferNutter flufferNutter = new FlufferNutter(position, 1, 100, 0, Settings.DEFAULT_JUMPFORCE);
                    flufferNutter.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return flufferNutter;
                case "MovingPlatform":
                    MovingPlatform movingPlatform = new MovingPlatform(position, Vector2.Zero, Vector2.Zero);
                    movingPlatform.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return movingPlatform;
                case "SinkablePlatform":
                    SinkablePlatform sinkablePlatform = new SinkablePlatform(position);
                    sinkablePlatform.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return sinkablePlatform;
                case "StaticPlatform":
                    StaticPlatform staticPlatform = new StaticPlatform(position);
                    staticPlatform.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return staticPlatform;
                case "EnemyMeleeGnome":
                    EnemyMeleeGnome enemyMeleeGnome = new EnemyMeleeGnome(position, 1, 100, Settings.ENEMY_JUMPFORCE);
                    enemyMeleeGnome.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return enemyMeleeGnome;
                case "EnemyFireballGnome":
                    EnemyFireballGnome enemyFireballGnome = new EnemyFireballGnome(position, 1, 100, Settings.ENEMY_JUMPFORCE);
                    enemyFireballGnome.LoadContent(contentManager, @"Sprites/" + texturePath);
                    return enemyFireballGnome;
            }
            return null;
        }
    }
}
