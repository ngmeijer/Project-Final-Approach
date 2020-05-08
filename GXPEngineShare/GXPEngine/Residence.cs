using System;
using GXPEngine;

public class Residence : GameObject
{
    public Penguin _penguin { get; set; }
    private Zebra _zebra;
    private SeaLion _seaLion;
    private Turtle _turtle;
    private Monkey _monkey;
    private Lion _lion;
    private Giraffe _giraffe;
    private Hippo _hippo;

    public Sprite _penguinBackground { get; set; }
    public Sprite _seaLionBackground { get; set; }
    public Sprite _turtleBackground { get; set; }
    public Sprite _giraffeBackground { get; set; }

    public bool _penguinActive = false;
    public bool _zebraActive;
    public bool _seaLionActive;
    public bool _turtleActive;
    public bool _monkeyActive;
    public bool _lionActive;
    public bool _giraffeActive;
    public bool _hippoActive;

    public Residence() : base()
    {
        //Penguin residence
        _penguinBackground = new Sprite("PenguinBackground.png");
        AddChild(_penguinBackground);
        _penguinBackground.visible = false;

        _penguin = new Penguin();
        AddChild(_penguin);
        _penguin.x = game.width / 2;
        _penguin.y = 100;
        _penguinActive = false;
        _penguin.visible = false;
        //

        //Zebra residence
        _zebra = new Zebra();
        AddChild(_zebra);
        _zebra.x = game.width / 2;
        _zebra.y = 200;
        _zebraActive = false;
        _zebra.visible = false;
        //

        //Sea lion residence
        _seaLionBackground = new Sprite("SeaLionBackground.png");
        AddChild(_seaLionBackground);
        _seaLionBackground.visible = false;

        _seaLion = new SeaLion();
        AddChild(_seaLion);
        _seaLion.x = game.width / 2;
        _seaLion.y = 300;
        _seaLionActive = false;
        _seaLion.visible = false;
        //

        //Turtle residence
        _turtleBackground = new Sprite("TurtleBackground.png");
        AddChild(_turtleBackground);
        _turtleBackground.visible = false;

        _turtle = new Turtle();
        AddChild(_turtle);
        _turtle.x = game.width / 2;
        _turtle.y = 400;
        _turtleActive = false;
        _turtle.visible = false;
        //

        //Monkey residence
        _monkey = new Monkey();
        AddChild(_monkey);
        _monkey.x = game.width / 2;
        _monkey.y = 500;
        _monkeyActive = false;
        _monkey.visible = false;
        //

        //Lion residence
        _lion = new Lion();
        AddChild(_lion);
        _lion.x = game.width / 2;
        _lion.y = 600;
        _lionActive = false;
        _lion.visible = false;
        //

        //Giraffe (a.k.a. "Tall-Neck-Horsie")  residence
        _giraffeBackground = new Sprite("GiraffeBackground.png");
        AddChild(_giraffeBackground);
        _giraffeBackground.visible = false;

        _giraffe = new Giraffe();
        AddChild(_giraffe);
        _giraffe.x = game.width / 2;
        _giraffe.y = 700;
        _giraffeActive = false;
        _giraffe.visible = false;

        //Hippo residence
        _hippo = new Hippo();
        AddChild(_hippo);
        _hippo.x = game.width / 2;
        _hippo.y = 800;
        _hippoActive = false;
        _giraffe.visible = false;
        //
    }

    private void Update()
    {
        CheckAnimalActive();
    }

    private void CheckAnimalActive()
    {
        if (_penguinActive)
        {
            _penguinBackground.visible = true;
            _penguin.visible = true;
        }
        else
        {
            _penguinBackground.visible = false;
            _penguin.visible = false;
        }

        if (_zebraActive)
        {
            _zebra.visible = true;
        }
        else
        {
            _zebra.visible = false;
        }

        if (_seaLionActive)
        {
            _seaLionBackground.visible = true;
            _seaLion.visible = true;
        }
        else
        {
            _seaLionBackground.visible = false;
            _seaLion.visible = false;
        }

        if (_turtleActive)
        {
            _turtleBackground.visible = true;
            _turtle.visible = true;
        }
        else
        {
            _turtleBackground.visible = false;
            _turtle.visible = false;
        }

        if (_monkeyActive)
        {
            _monkey.visible = true;
        }
        else
        {
            _monkey.visible = false;
        }

        if (_lionActive)
        {
            _lion.visible = true;
        }
        else
        {
            _lion.visible = false;
        }

        if (_giraffeActive)
        {
            _giraffe.visible = true;
            _giraffeBackground.visible = true;
        }
        else
        {
            _giraffe.visible = false;
            _giraffeBackground.visible = false;
        }

        if (_hippoActive)
        {
            _hippo.visible = true;
        }
        else
        {
            _hippo.visible = false;
        }
    }
}