using System;
using GXPEngine;

public class Environment : GameObject
{
    public HUD _gameHUD { get; private set; }

    public Penguin _penguin { get; private set; }
    public Penguin _penguin2 { get; private set; }
    public Penguin _penguin3 { get; private set; }
    public Penguin _penguin4 { get; private set; }
    public Penguin _penguin5 { get; private set; }

    public bool clickedPenguins { get; set; }
    public bool residenceActive { get; set; }

    public Residence _residencePenguins { get; set; }

    public Environment()
    {
        _penguin = new Penguin();
        AddChild(_penguin);
        _penguin.SetXY(50, 450);

        _penguin2 = new Penguin();
        AddChild(_penguin2);
        _penguin2.SetXY(100, 300);

        _penguin3 = new Penguin();
        AddChild(_penguin3);
        _penguin3.SetXY(150, 150);

        _penguin4 = new Penguin();
        AddChild(_penguin4);
        _penguin4.SetXY(300, 0);

        _penguin5 = new Penguin();
        AddChild(_penguin5);
        _penguin5.SetXY(500, 150);
    }

    private void Update()
    {
        ClickPenguins();
    }

    //Trying out to place items relative to screen size.
    //private void RelativePlacement(int xPixels, int yPixels)
    //{
    //    int xPixelsPercent = xPixels / game.width;
    //    int yPixelsPercent = yPixels / game.height;
    //}

    private void ClickPenguins()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_penguin.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                clickedPenguins = true;
            }
        }
    }

    private void HideMainArea()
    {
        _penguin.visible = false;
        _penguin2.visible = false;
        _penguin3.visible = false;
        _penguin4.visible = false;
        _penguin5.visible = false;
    }
}
