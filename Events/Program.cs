using System;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpaceQuestGameManager spaceQuestGameManager = new SpaceQuestGameManager(100, 50, 30, 5);
            GameViewer gameViewer = new GameViewer();


            spaceQuestGameManager.GoodSpaceHpChanged += gameViewer.GoodSpaceHpChangedEventHandler;
            spaceQuestGameManager.GoodSpaceLocationChanged += gameViewer.GoodSpaceLocationChangedEventHandler;
            spaceQuestGameManager.BadShipsExploded += gameViewer.BadShipExplodedEventHandler;
            spaceQuestGameManager.LevelUpReached += gameViewer.LevelUpReachedEventHandler;
            spaceQuestGameManager.GoodSpaceShipsDestroyed += gameViewer.GoodSpaceShipDestroyedEventHandler;
            Run(spaceQuestGameManager);

          

            static void Run(SpaceQuestGameManager spaceQuestGameManager)
            {
                Random randomChoise = new Random();
                Random randomDemage = new Random();
                Random randomMove = new Random();
                Random randomExtraHp = new Random();

                while (spaceQuestGameManager.goodSpaceHp > 0)
                    switch (randomChoise.Next(0, 4))
                    {
                        case 0:
                            spaceQuestGameManager.GoodShipMove(randomMove.Next(0, 1000), randomMove.Next(0, 1000));
                            Thread.Sleep(1000);
                            break;

                        case 1:
                            spaceQuestGameManager.GoodShipGotDamged(randomDemage.Next(0, 30));
                            Thread.Sleep(1000);
                            break;

                        case 2:
                            spaceQuestGameManager.GoodShipGetHP(randomExtraHp.Next(0, 50));
                            Thread.Sleep(1000);
                            break;
                        case 3:
                            spaceQuestGameManager.EnemyShipsDestroyed(randomDemage.Next(0, 4));
                            Thread.Sleep(1000);
                            break;
                        default:
                            break;
                    }
            }


        }
    }
}