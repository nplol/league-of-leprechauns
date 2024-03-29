﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    /// <summary>
    /// A factory which instanciates actors as they are read from the level XML file.
    /// </summary>
    class ActorFactory
    {
        /// <summary>
        /// Method for instanciatng actors.
        /// </summary>
        /// <param name="actorClassName">The textual name of the actor class</param>
        /// <param name="position">The start position of the actor</param>
        /// <param name="contentManager">Reference to the contentManager for loading textures</param>
        /// <returns>An actor instance</returns>
        public Actor CreateActor(string actorClassName, Vector2 position, string texturePath)
        {
            switch (actorClassName)
            {
                case "BackgroundObject":
                    BackgroundObject backgroundObject = new BackgroundObject(position, false);
                    backgroundObject.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return backgroundObject;
                case "Button":
                    Button button = new Button(position);
                    button.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return button;
                case "CabbageLips":
                    CabbageLips cabbageLips = CabbageLips.GetInstance();
                    cabbageLips.Initialize(position);
                    cabbageLips.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return cabbageLips;
                case "CollapsableBridge":
                    CollapsableBridge collapseableBridge = new CollapsableBridge(position);
                    collapseableBridge.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return collapseableBridge;
                case "Door":
                    Door door = new Door(position);
                    door.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return door;
                case "EnemyFireballGnome":
                    EnemyFireballGnome enemyFireballGnome = new EnemyFireballGnome(position);
                    enemyFireballGnome.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return enemyFireballGnome;
                case "EnemyFireballGnomeStationary":
                    EnemyFireballGnomeStationary enemyFireballGnomeStationary = new EnemyFireballGnomeStationary(position);
                    enemyFireballGnomeStationary.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return enemyFireballGnomeStationary;
                case "EnemyMeleeGnome":
                    EnemyMeleeGnome enemyMeleeGnome = new EnemyMeleeGnome(position);
                    enemyMeleeGnome.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return enemyMeleeGnome;
                case "FlufferNutter":
                    FlufferNutter flufferNutter = FlufferNutter.GetInstance();
                    flufferNutter.Initialize(position);
                    flufferNutter.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return flufferNutter;
                case "InvisiblePlatform":
                    InvisiblePlatform invisiblePlatform = new InvisiblePlatform(position);
                    invisiblePlatform.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return invisiblePlatform;
                case "LevelExitDoor":
                    LevelExitDoor levelExitDoor = new LevelExitDoor(position);
                    levelExitDoor.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return levelExitDoor;
                case "MovingPlatform":
                    MovingPlatform movingPlatform = new MovingPlatform(position);
                    movingPlatform.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return movingPlatform;
                case "MovingPlatformGroup":
                    MovingPlatformGroup movingPlatformGroup = new MovingPlatformGroup(position);
                    return movingPlatformGroup;
                case "Nacklebiddle":
                    Nacklebiddle nacklebiddle = new Nacklebiddle(position);
                    nacklebiddle.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return nacklebiddle;
                case "StaticPlatform":
                    StaticPlatform staticPlatform = new StaticPlatform(position);
                    staticPlatform.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return staticPlatform;
                case "TutorialObject":
                    TutorialObject tutorialObject = new TutorialObject(position, false);
                    tutorialObject.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return tutorialObject;
            }
            return null;
        }
    }
}
