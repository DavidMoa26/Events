namespace Events
{
    public class LevelEventArgs:EventArgs
    {
        public int level;

        public LevelEventArgs(int level)
        {
            this.level = level;
        }
    }
}