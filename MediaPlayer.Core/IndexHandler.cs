namespace MediaPlayer.Core;

public class IndexHandler
{
    readonly Random _randomizer;

    private int _previousIndex;

    public IndexHandler(int maximum)
    {
        _randomizer = new Random();
        Maximum = maximum - 1;
    }

    public int CurrentIndex { get; set; }

    /// <summary>
    /// Zero based maximum possible index.
    /// The maximum index of a set with 24 items would be 23.
    /// </summary>
    public int Maximum { get; }

    /// <summary>
    /// Moves index back by 1
    /// </summary>
    public void IndexBack()
    {
        _previousIndex = CurrentIndex;

        CurrentIndex = (CurrentIndex - 1 + Maximum + 1) % (Maximum + 1);
    }

    /// <summary>
    /// Moves index forward by 1
    /// </summary>
    public void IndexNext()
    {
        _previousIndex = CurrentIndex;

        CurrentIndex = (CurrentIndex + 1) % (Maximum + 1);
    }

    /// <summary>
    /// Sets current index to a random number.
    /// </summary>
    public void RandomizeIndex()
    {
        // Shuffle the index by generating a random index number between 0 and the max ammount and if the index is greater than 0
        _previousIndex = CurrentIndex;

        do
        {
            CurrentIndex = _randomizer.Next(0, Maximum);
        } while(_previousIndex == CurrentIndex && Maximum > 0);
    }
}