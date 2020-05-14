using System;
using System.Drawing;
using GXPEngine;
public class OptionsMenu : Sprite
{
    EasyDraw lionLevelText = new EasyDraw(1920, 1080);
    EasyDraw penguinLevelText = new EasyDraw(1920, 1080);
    EasyDraw monkeyLevelText = new EasyDraw(1920, 1080);
    EasyDraw giraffeLevelText = new EasyDraw(1920, 1080);
    EasyDraw zebraLevelText = new EasyDraw(1920, 1080);
    EasyDraw hippoLevelText = new EasyDraw(1920, 1080);
    EasyDraw seaLionLevelText = new EasyDraw(1920, 1080);
    EasyDraw turtleLevelText = new EasyDraw(1920, 1080);

    private readonly Brush _fontColor;
    private readonly Font _font;

    public int penguinLevel { get; set; } = 0;
    ///

    ///
    public int zebraLevel { get; set; } = 0;
    ///

    ///
    public int _seaLionLevel { get; set; } = 0;
    ///

    ///
    public int _turtleLevel { get; set; } = 0;
    ///

    ///
    public int _monkeyLevel { get; set; } = 0;
    ///

    ///
    public int lionLevel { get; set; } = 0;
    ///

    ///
    public int giraffeLevel { get; set; } = 0;
    ///

    ///
    public int hippoLevel { get; set; } = 0;
    ///
    public bool giraffeUnlocked { get; set; }
    public bool zebraUnlocked { get; set; }
    public bool hippoUnlocked { get; set; }
    public bool seaLionUnlocked { get; set; }
    public bool turtleUnlocked { get; set; }

    public OptionsMenu() : base("MilestonesBackground.png")
    {
        _fontColor = Brushes.White;
        _font = new Font("Arial", 35);

        AddChild(penguinLevelText);
        AddChild(monkeyLevelText);
        AddChild(lionLevelText);
        AddChild(giraffeLevelText);
        AddChild(zebraLevelText);
        AddChild(seaLionLevelText);
        AddChild(turtleLevelText);
        AddChild(hippoLevelText);
    }

    private void Update()
    {
        DrawAnimalLevelStrings();
    }

    private void DrawAnimalLevelStrings()
    {
        penguinLevelText.graphics.Clear(Color.Transparent);
        monkeyLevelText.graphics.Clear(Color.Transparent);
        lionLevelText.graphics.Clear(Color.Transparent);
        giraffeLevelText.graphics.Clear(Color.Transparent);
        zebraLevelText.graphics.Clear(Color.Transparent);
        seaLionLevelText.graphics.Clear(Color.Transparent);
        turtleLevelText.graphics.Clear(Color.Transparent);
        hippoLevelText.graphics.Clear(Color.Transparent);


        penguinLevelText.graphics.DrawString("Penguin level = " + penguinLevel,
                    _font, _fontColor, 225, 150);
        monkeyLevelText.graphics.DrawString("Monkey level = " + _monkeyLevel,
                    _font, _fontColor, 225, 210);
        lionLevelText.graphics.DrawString("Lion level = " + lionLevel,
                    _font, _fontColor, 225, 270);

        if (giraffeUnlocked)
        {
            giraffeLevelText.graphics.DrawString("Giraffe level = " + giraffeLevel,
                    _font, _fontColor, 225, 330);
        }

        if (zebraUnlocked)
        {
            zebraLevelText.graphics.DrawString("Zebra level = " + zebraLevel,
                    _font, _fontColor, 225, 390);
        }

        if (hippoUnlocked)
        {
            hippoLevelText.graphics.DrawString("Hippo level = " + hippoLevel,
                    _font, _fontColor, 225, 450);
        }

        if (seaLionUnlocked)
        {
            seaLionLevelText.graphics.DrawString("Sea Lion level = " + _seaLionLevel,
                    _font, _fontColor, 225, 510);
        }

        if (turtleUnlocked)
        {
            turtleLevelText.graphics.DrawString("Turtle level = " + _turtleLevel,
                    _font, _fontColor, 225, 570);
        }
    }
}
