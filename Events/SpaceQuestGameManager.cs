using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class SpaceQuestGameManager
    {
        public int goodSpaceHp;
        int xLocation;
        int yLocation;
        int numOfBadShips;
        int currentLevel = 1;

        public event EventHandler<PointsEventArgs> GoodSpaceHpChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceLocationChanged;
        public event EventHandler<PointsEventArgs> GoodSpaceShipsDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;

        public SpaceQuestGameManager(int goodSpaceHp,int xLocation,int yLocation,int numOfBadShips)
        {
            this.goodSpaceHp = goodSpaceHp;
            this.xLocation = xLocation; 
            this.yLocation = yLocation;
            this.numOfBadShips = numOfBadShips;
        }

        public void GoodShipMove(int NewxLocation,int NewyLocation)
        {
            xLocation = NewxLocation;
            yLocation = NewyLocation;
            OnGoodSpaceLocationChanged();
        }
        public void GoodShipGotDamged(int damage)
        {
            goodSpaceHp -= damage;
            if (goodSpaceHp <= 0)
            {
                OnGoodSpaceDestroyed();     
                return;
            }
            else 
            {
                Console.WriteLine($"Your spaceship was hit : -{damage}");
                OnGoodSpaceHpChanged();
            }
                
        }
        public void GoodShipGetHP(int hp)
        {
            goodSpaceHp += hp;
            Console.WriteLine($"You got extra hp +{hp}");
            OnGoodSpaceHpChanged();
        }
        public void EnemyShipsDestroyed(int NumOfBadShipsExploded)
        {
            numOfBadShips -= NumOfBadShipsExploded;
            if (numOfBadShips <= 0)
            {
                OnBadShipsExploded(NumOfBadShipsExploded);
                ++currentLevel;
                OnLevelUpReached();
            }
            else
                OnBadShipsExploded(NumOfBadShipsExploded);
        }

        private void OnGoodSpaceHpChanged()
        {
            GoodSpaceHpChanged?.Invoke(this, new PointsEventArgs(goodSpaceHp));
        }
        private void OnGoodSpaceLocationChanged()
        {
            GoodSpaceLocationChanged?.Invoke(this, new LocationEventArgs(xLocation, yLocation));
        }
        private void OnGoodSpaceDestroyed()
        {
                GoodSpaceShipsDestroyed?.Invoke(this, null);
        }
        private void OnBadShipsExploded(int NumOfBadShipsExploded)
        {
            BadShipsExploded?.Invoke(this, new BadShipsExplodedEventArgs(numOfBadShips, NumOfBadShipsExploded));
        }
        private void OnLevelUpReached()
        {
            LevelUpReached?.Invoke(this, new LevelEventArgs(currentLevel));
        }








    }
}
