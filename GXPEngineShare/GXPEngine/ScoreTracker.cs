using System;
using System.Drawing;
using GXPEngine;

public class ScoreTracker : Canvas
{
    private float _multiplier = 1.15f;

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
        _fontColor = Brushes.Red;
        _font = new Font("Arial", 30);
    }

    private void Update()
    {
        TrackXpAmount();
    }

    public void TrackXpAmount()
    {
        if (_penguinXp >= maxXpAmount)
        {
            _penguinLevel += 1;
            _penguinXp = 0;
            maxXpAmount *= _multiplier;
        }
        ///
        ///
        ///

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
}
