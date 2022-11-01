namespace Events
{
    public class PointsEventArgs:EventArgs
    {
        public int HP { get; set; }

        public PointsEventArgs(int HPchanged)
        {
            HP = HPchanged;
        }


    }
}