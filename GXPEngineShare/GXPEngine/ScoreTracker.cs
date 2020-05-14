using GXPEngine;
using System;
using System.Drawing;

public class ScoreTracker : Canvas
{
    #region
    private float _multiplier = 1.15f;
    private int maxLevel = 10;

    //////////////
    ///
    public int penguinLevel { get; set; } = 0;
    public int penguinXp { get; set; } = 0;
    private float maxXpAmountPenguin = 150;
    ///

    ///
    public int zebraLevel { get; set; } = 0;
    public int zebraXp { get; set; } = 0;
    private float maxXpAmountZebra = 150;
    ///

    ///
    public int _seaLionLevel { get; set; } = 0;
    public int seaLionXp { get; set; } = 0;
    private float maxXpAmountSeaLion = 150;
    ///

    ///
    public int _turtleLevel { get; set; } = 0;
    public int turtleXp { get; set; } = 0;
    private float maxXpAmountTurtle = 150;
    ///

    ///
    public int _monkeyLevel { get; set; } = 0;
    public int monkeyXp { get; set; } = 0;
    private float maxXpAmountMonkey = 150;
    ///

    ///
    public int lionLevel { get; set; } = 0;
    public int lionXp { get; set; } = 0;
    private float maxXpAmountLion = 150;
    ///

    ///
    public int giraffeLevel { get; set; } = 0;
    public int giraffeXp { get; set; } = 0;
    private float maxXpAmountGiraffe = 150;
    ///

    ///
    public int hippoLevel { get; set; } = 0;
    public int hippoXp { get; set; } = 0;
    private float maxXpAmountHippo = 150;
    /////////////

    public bool unlockedPenguin;
    public bool unlockedTurtle;
    public bool unlockedSeaLion;
    public bool unlockedZebra;
    public bool unlockedMonkey;
    public bool unlockedLion;
    public bool unlockedGiraffe;
    public bool unlockedHippo;
    public bool clickedOptions { get; set; }

    public bool showAnimalStats { get; set; }

    private readonly Brush _fontColor;
    private readonly Font _font;

    EasyDraw lionLevelText = new EasyDraw(1920, 1080);
    EasyDraw penguinLevelText = new EasyDraw(1920, 1080);
    EasyDraw monkeyLevelText = new EasyDraw(1920, 1080);

    #endregion

    public ScoreTracker() : base(1920, 1080, false)
    {
        _fontColor = Brushes.White;
        _font = new Font("Arial", 30);

        AddChild(lionLevelText);
        AddChild(penguinLevelText);
        AddChild(monkeyLevelText);
    }

    private void Update()
    {
        TrackXpAmount();
    }

    public void TrackXpAmount()
    {
        //Console.WriteLine("lion current xp: " + _lionXp + ", lion current level: " + _lionLevel);
        
        #region

        if (penguinXp >= maxXpAmountPenguin && penguinLevel < 10)
        {
            penguinLevel += 1;
            penguinXp = 0;
            maxXpAmountPenguin *= _multiplier;
        }

        if (zebraXp >= maxXpAmountZebra && zebraLevel < 10)
        {
            zebraLevel += 1;
            zebraXp = 0;
            maxXpAmountZebra *= _multiplier;
        }

        if (seaLionXp >= maxXpAmountSeaLion && _seaLionLevel < 10)
        {
            _seaLionLevel += 1;
            seaLionXp = 0;
            maxXpAmountSeaLion *= _multiplier;
        }

        if (turtleXp >= maxXpAmountTurtle && _turtleLevel < 10)
        {
            _turtleLevel += 1;
            turtleXp = 0;
            maxXpAmountTurtle *= _multiplier;
        }

        if (monkeyXp >= maxXpAmountMonkey && _monkeyLevel < 10)
        {
            _monkeyLevel += 1;
            monkeyXp = 0;
            maxXpAmountMonkey *= _multiplier;
        }

        if (giraffeXp >= maxXpAmountGiraffe && giraffeLevel < 10)
        {
            giraffeLevel += 1;
            giraffeXp = 0;
            maxXpAmountGiraffe *= _multiplier;
        }

        if (hippoXp >= maxXpAmountHippo && hippoLevel < 10)
        {
            hippoLevel += 1;
            hippoXp = 0;
            maxXpAmountHippo *= _multiplier;
        }

        if (lionXp >= maxXpAmountLion && lionLevel < 10)
        {
            lionLevel += 1;
            lionXp = 0;
            maxXpAmountLion *= _multiplier;
        }

        //////////////
        if (lionLevel >= 1 && _monkeyLevel >= 1 && penguinLevel >= 1)
        {
            unlockedGiraffe = true;
        }

        if (lionLevel >= 2 && _monkeyLevel >= 2 && penguinLevel >= 2 
            && giraffeLevel >= 2)
        {
            unlockedZebra = true;
        }

        if (lionLevel >= 3 && _monkeyLevel >= 3 && penguinLevel >= 3 
            && giraffeLevel >= 3 && zebraLevel >= 3)
        {
            unlockedHippo = true;
        }

        if (lionLevel >= 4 && _monkeyLevel >= 4 && penguinLevel >= 4
            && giraffeLevel >= 4 && zebraLevel >= 4 && hippoLevel >= 4)
        {
            unlockedSeaLion = true;
        }

        if (lionLevel >= 5 && _monkeyLevel >= 5 && penguinLevel >= 5
            && giraffeLevel >= 5 && zebraLevel >= 5 
            && hippoLevel >= 5 && _seaLionLevel >= 5)
        {
            unlockedTurtle = true;
        }

        #endregion
    }
}
