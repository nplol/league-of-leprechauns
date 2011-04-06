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
        public Actor CreateActor(string actorClassName, Vector2 position, string texturePath)
        {
            switch (actorClassName)
            {
                case "TutorialObject":
                    TutorialObject tutorialObject = new TutorialObject(position, false);
                    tutorialObject.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return tutorialObject;
                case "CollapsableBridge":
                    CollapsableBridge collapseableBridge = new CollapsableBridge(position);
                    collapseableBridge.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return collapseableBridge;
                case "Button":
                    Button button = new Button(position);
                    button.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return button;
                case "Door":
                    Door door = new Door(position);
                    door.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return door;
                case "BackgroundObject":
                    BackgroundObject backgroundObject = new BackgroundObject(position, false);
                    backgroundObject.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return backgroundObject;
                case "CabbageLips":
                    CabbageLips cabbageLips = CabbageLips.GetInstance();
                    cabbageLips.Initialize(position);
                    cabbageLips.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return cabbageLips;
                case "FlufferNutter": 
                    FlufferNutter flufferNutter = FlufferNutter.GetInstance();
                    flufferNutter.Initialize(position);
                    flufferNutter.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return flufferNutter;
                case "LevelExitDoor":
                    LevelExitDoor levelExitDoor = new LevelExitDoor(position);
                    levelExitDoor.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return levelExitDoor;
                case "InvisiblePlatform":
                    InvisiblePlatform invisiblePlatform = new InvisiblePlatform(position);
                    invisiblePlatform.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return invisiblePlatform;
                //Vertical moving platforms.
                case "MovingPlatform1":
                    MovingPlatform movingPlatform1 = new MovingPlatform(position);
                    movingPlatform1.Initialize(200, new Vector2(0, 1));
                    movingPlatform1.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return movingPlatform1;
                //Horizontal moving platforms.
                case "MovingPlatform2":
                    MovingPlatform movingPlatform2 = new MovingPlatform(position);
                    movingPlatform2.Initialize(200, new Vector2(1, 0));
                    movingPlatform2.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return movingPlatform2;
                case "MovingPlatformGroup":
                    MovingPlatformGroup movingPlatformGroup = new MovingPlatformGroup(position);
                    movingPlatformGroup.Initialize();
                    return movingPlatformGroup;
                case "StaticPlatform":
                    StaticPlatform staticPlatform = new StaticPlatform(position);
                    staticPlatform.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return staticPlatform;
                case "EnemyMeleeGnome":
                    EnemyMeleeGnome enemyMeleeGnome = new EnemyMeleeGnome(position);
                    enemyMeleeGnome.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return enemyMeleeGnome;
                case "EnemyFireballGnome":
                    EnemyFireballGnome enemyFireballGnome = new EnemyFireballGnome(position);
                    enemyFireballGnome.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return enemyFireballGnome;
                case "EnemyFireballGnomeStationary":
                    EnemyFireballGnomeStationary enemyFireballGnomeStationary = new EnemyFireballGnomeStationary(position);
                    enemyFireballGnomeStationary.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return enemyFireballGnomeStationary;
                case "Nacklebiddle":
                    Nacklebiddle nacklebiddle = new Nacklebiddle(position);
                    nacklebiddle.LoadContent(GlobalVariables.ContentManager, GlobalVariables.SPRITES_PATH + texturePath);
                    return nacklebiddle;
            }
            return null;
        }
    }
}
