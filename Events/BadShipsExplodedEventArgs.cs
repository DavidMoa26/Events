namespace Events
{
    public class BadShipsExplodedEventArgs:EventArgs
    {
        public int NumberOfBadShip { get; set; }
        public int NumberOfBadShipExploded { get; set; }

        public BadShipsExplodedEventArgs(int NumberOfBadShip,int NumberOfBadShipExploded)
        {
            this.NumberOfBadShip = NumberOfBadShip;
            this.NumberOfBadShipExploded = NumberOfBadShipExploded;           
        }
    }
}