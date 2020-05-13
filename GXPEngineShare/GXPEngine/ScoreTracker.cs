using System;
using System.Drawing;
using GXPEngine;

public class ScoreTracker : Canvas
{
    private float _multiplier = 1.15f;
    private int maxLevel = 10;

    //////////////
    ///
    public int _penguinLevel { get; set; } = 0;
    public int _penguinXp { get; set; } = 0;
    private float maxXpAmountPenguin = 150;
    ///
    
    ///
    public int _zebraLevel { get; set; } = 0;
    public int _zebraXp { get; set; } = 0;
    private float maxXpAmountZebra = 150;
    ///
   
    ///
    public int _seaLionLevel { get; set; } = 0;
    public int _seaLionXp { get; set; } = 0;
    private float maxXpAmountSeaLion = 150;
    ///

    ///
    public int _turtleLevel { get; set; } = 0;
    public int _turtleXp { get; set; } = 0;
    private float maxXpAmountTurtle = 150;
    ///

    ///
    public int _monkeyLevel { get; set; } = 0;
    public int _monkeyXp { get; set; } = 0;
    private float maxXpAmountMonkey = 150;
    ///

    ///
    public int _lionLevel { get; set; } = 0;
    public int _lionXp { get; set; } = 0;
    private float maxXpAmountLion = 150;
    ///

    ///
    public int _giraffeLevel { get; set; } = 0;
    public int _giraffeXp { get; set; } = 0;
    private float maxXpAmountGiraffe = 150;
    ///

    ///
    public int _hippoLevel { get; set; } = 0;
    public int _hippoXp { get; set; } = 0;
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

    public ScoreTracker() : base(1920, 1080, false)
    {
        _fontColor = Brushes.White;
        _font = new Font("Arial", 30);
    }

    private void Update()
    {
        TrackXpAmount();
    }

    public void TrackXpAmount()
    {
        //Console.WriteLine("lion current xp: " + _lionXp + ", lion current level: " + _lionLevel);
        #region

        if (_penguinXp >= maxXpAmountPenguin)
        {
            _penguinLevel += 1;
            _penguinXp = 0;
            maxXpAmountPenguin *= _multiplier;
        }

        if (_zebraXp >= maxXpAmountZebra)
        {
            _zebraLevel += 1;
            _zebraXp = 0;
            maxXpAmountZebra *= _multiplier;
        }

        if (_penguinXp >= maxXpAmountSeaLion)
        {
            _seaLionLevel += 1;
            _seaLionXp = 0;
            maxXpAmountSeaLion *= _multiplier;
        }

        if (_turtleXp >= maxXpAmountTurtle)
        {
            _turtleLevel += 1;
            _turtleXp = 0;
            maxXpAmountTurtle *= _multiplier;
        }

        if (_monkeyXp >= maxXpAmountMonkey)
        {
            _monkeyLevel += 1;
            _monkeyXp = 0;
            maxXpAmountMonkey *= _multiplier;
        }

        if (_giraffeXp >= maxXpAmountGiraffe)
        {
            _giraffeLevel += 1;
            _giraffeXp = 0;
            maxXpAmountGiraffe *= _multiplier;
        }

        if (_hippoXp >= maxXpAmountHippo)
        {
            _hippoLevel += 1;
            _hippoXp = 0;
            maxXpAmountHippo *= _multiplier;
        }

        if (_lionXp >= maxXpAmountLion)
        {
            _lionLevel += 1;
            _lionXp = 0;
            maxXpAmountLion *= _multiplier;
        }

        #endregion

        if (showAnimalStats && clickedOptions)
        {
            if (unlockedPenguin)
            {
                graphics.DrawString("Penguin level = " + _penguinLevel, _font, _fontColor, 630, 410);
            }

            if (unlockedMonkey)
            {
                graphics.DrawString("Monkey level = " + _monkeyLevel, _font, _fontColor, 630, 460);
            }

            if (unlockedLion)
            {
                graphics.DrawString("Lion level = " + _lionLevel, _font, _fontColor, 630, 510);
            }

            if (unlockedGiraffe)
            {
                graphics.DrawString("Giraffe level = " + _giraffeLevel, _font, _fontColor, 630, 560);
            }

            if (unlockedZebra)
            {
                graphics.DrawString("Zebra level = " + _zebraLevel, _font, _fontColor, 970, 410);
            }

            if (unlockedHippo)
            {
                graphics.DrawString("Hippo level = " + _hippoLevel, _font, _fontColor, 970, 460);
            }

            if (unlockedSeaLion)
            {
                graphics.DrawString("Sea Lion level = " + _seaLionLevel, _font, _fontColor, 970, 510);
            }

            if (unlockedTurtle)
            {
                graphics.DrawString("Turtle level = " + _turtleLevel, _font, _fontColor, 970, 560);
            }
        }
        else
        {
            graphics.Clear(Color.Empty);
        }
    }

    //private void IncreaseXP(float xp, float maxXpAmount, int animalLevel)
    //{
    //    if (xp >= maxXpAmount)
    //    {
    //        animalLevel += 1;
    //        xp = 0;
    //        maxXpAmount *= _multiplier;
    //    }
    //}
}
