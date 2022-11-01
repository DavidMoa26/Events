using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class GameViewer
    {
        public void GoodSpaceHpChangedEventHandler(object sender,PointsEventArgs pointsEventArgs)
        {
            Console.WriteLine($"your HP : {pointsEventArgs.HP}");
        }
        public void GoodSpaceLocationChangedEventHandler(object sender,LocationEventArgs locationEventArgs)
        {
            Console.WriteLine($"New location X : {locationEventArgs.x} , Y : {locationEventArgs.y}");
        }
        public void GoodSpaceShipDestroyedEventHandler(object sender, PointsEventArgs pointsEventArgs)
        {
            Console.WriteLine("Your HP is gone , Game Over !!");
        }
        public void BadShipExplodedEventHandler(object sender,BadShipsExplodedEventArgs badShipsExplodedEventArgs)
        {
            if (badShipsExplodedEventArgs.NumberOfBadShip < 0)
                badShipsExplodedEventArgs.NumberOfBadShip = 0;
            Console.WriteLine($"you exploded {badShipsExplodedEventArgs.NumberOfBadShipExploded} bad ships , {badShipsExplodedEventArgs.NumberOfBadShip} left.");
        }
        public void LevelUpReachedEventHandler(object sender,LevelEventArgs levelEventArgs)
        {
            Console.WriteLine($"Level up !  -  you at level : {levelEventArgs.level}");
        }



    }
}