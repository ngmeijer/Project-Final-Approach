using System;
using GXPEngine;

public class Environment : GameObject
{
    public Penguin _penguin { get; private set; }
    public Zebra _zebra { get; private set; }
    public SeaLion _seaLion { get; private set; }
    public Turtle _turtle { get; private set; }
    public Monkey _monkey { get; private set; }
    public Lion _lion { get; private set; }
    public Giraffe _giraffe { get; private set; }
    public Hippo _hippo { get; private set; }

    public bool _penguinsActive { get; set; }
    public bool _zebraActive { get; set; }
    public bool _seaLionActive { get; set; }
    public bool _turtleActive { get; set; }
    public bool _monkeyActive { get; set; }
    public bool _lionActive { get; set; }
    public bool _giraffeActive { get; set; }
    public bool _hippoActive { get; set; }


    public Environment()
    {
        _penguin = new Penguin();
        AddChild(_penguin);
        _penguin.SetXY(100, 950);

        _zebra = new Zebra();
        AddChild(_zebra);
        _zebra.SetXY(200, 700);

        _seaLion = new SeaLion();
        AddChild(_seaLion);
        _seaLion.SetXY(350, 500);

        _turtle = new Turtle();
        AddChild(_turtle);
        _turtle.SetXY(500, 200);

        _monkey = new Monkey();
        AddChild(_monkey);
        _monkey.SetXY(750, 200);

        _lion = new Lion();
        AddChild(_lion);
        _lion.SetXY(900, 500);

        _giraffe = new Giraffe();
        AddChild(_giraffe);
        _giraffe.SetXY(1200, 650);

        _hippo = new Hippo();
        AddChild(_hippo);
        _hippo.SetXY(1500, 950);
    }

    private void Update()
    {
        ClickResidence();
    }

    //Trying out to place items relative to screen size.
    //private void RelativePlacement(int xPixels, int yPixels)
    //{
    //    int xPixelsPercent = xPixels / game.width;
    //    int yPixelsPercent = yPixels / game.height;
    //}

    private void ClickResidence()
    {
        if (_penguin.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _penguinsActive = true;
            }
        }

        //if (_zebra.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _zebraActive = true;
        //    }
        //}

        //if (_seaLion.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _seaLionActive = true;
        //    }
        //}

        //if (_turtle.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _turtleActive = true;
        //    }
        //}

        //if (_monkey.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _monkeyActive = true;
        //    }
        //}

        //if (_lion.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _lionActive = true;
        //    }
        //}

        //if (_giraffe.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _giraffeActive = true;
        //    }
        //}

        //if (_hippo.HitTestPoint(Input.mouseX, Input.mouseY))
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _hippoActive = true;
        //    }
        //}
    }
}
