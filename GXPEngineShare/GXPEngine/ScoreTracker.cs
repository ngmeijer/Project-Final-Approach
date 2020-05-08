using System;
using GXPEngine;

public class ScoreTracker : GameObject
{
    private float _multiplier = 1.15f;
    //

    public int _penguinLevel { get; set; } = 0;
    public int _penguinXp { get; set; } = 0;
    private float maxXpAmount = 150;

    private int _zebraLevel = 0;
    private int _zebraXp;

    private int _seaLionLevel = 0;
    private int _seaLionXp = 0;

    private int _turtleLevel = 0;
    private int _turtleXp = 0;

    private int _monkeyLevel = 0;
    private int _monkeyXp = 0;

    private int _lionLevel = 0;
    private int _lionXp = 0;

    private int _giraffeLevel = 0;
    private int _giraffeXp = 0;

    private int _hippoLevel = 0;
    private int _hippoXp = 0;

    public ScoreTracker()
    {

    }

    private void Update()
    {
        TrackXpAmount();
    }

    public void TrackXpAmount()
    {
        if(_penguinXp >= maxXpAmount)
        {
            _penguinLevel += 1;
            _penguinXp = 0;
            maxXpAmount *= _multiplier;
        }
        ///
        ///
        ///
    }
}
