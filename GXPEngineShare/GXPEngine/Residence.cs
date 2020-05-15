using System;
using GXPEngine;

public class Residence : GameObject
{
    public Penguin _penguin;
    public Zebra _zebra;
    private SeaLion _seaLion;
    private Turtle _turtle;
    public Monkey _monkey;
    public Lion _lion;
    public Giraffe _giraffe;
    private Hippo _hippo;

    public Sprite _penguinBackground { get; set; }
    public Sprite _zebraBackground { get; set; }
    public Sprite _seaLionBackground { get; set; }
    public Sprite _turtleBackground { get; set; }
    public Sprite _monkeyBackground { get; set; }
    public Sprite _giraffeBackground { get; set; }
    public Sprite _lionBackground { get; set; }
    public Sprite _hippoBackground { get; set; }

    public Sprite _giraffeFence;
    public Sprite _monkeyFence;
    public Sprite _penguinFence;
    public Sprite _hippoFence;
    public Sprite _zebraFence;

    //Checks if the animal is CURRENTLY active
    public bool penguinActive { get; set; }
    public bool zebraActive;
    public bool seaLionActive;
    public bool turtleActive;
    public bool monkeyActive;
    public bool lionActive;
    public bool giraffeActive;
    public bool hippoActive;

    //Checks if the animal is actually unlocked
    public bool unlockedPenguin { get; set; } = true;
    public bool unlockedTurtle { get; set; }
    public bool unlockedSeaLion { get; set; }
    public bool unlockedZebra { get; set; }
    public bool unlockedMonkey { get; set; } = true;
    public bool unlockedLion { get; set; } = true;
    public bool unlockedGiraffe { get; set; }
    public bool unlockedHippo { get; set; }

    public Residence() : base()
    {
        //Penguin residence
        _penguinBackground = new Sprite("PenguinBackground.png");
        AddChild(_penguinBackground);
        _penguinBackground.visible = false;

        _penguin = new Penguin();
        AddChild(_penguin);
        _penguin.x = game.width / 2;
        _penguin.y = 164;
        penguinActive = false;
        _penguin.visible = false;

        _penguinFence = new Sprite("ArcticFence.png");
        AddChild(_penguinFence);
        _penguinFence.visible = false;
        //

        //Zebra residence
        _zebraBackground = new Sprite("ZebraBackground.png");
        AddChild(_zebraBackground);
        _zebraBackground.visible = false;

        _zebra = new Zebra();
        AddChild(_zebra);
        _zebra.x = game.width / 2 - 160;
        _zebra.y = 317;
        zebraActive = false;
        _zebra.visible = false;
        _zebra.scale = 1f;

        _zebraFence = new Sprite("JungleFence.png");
        AddChild(_zebraFence);
        _zebraFence.visible = false;
        //

        //Sea lion residence
        _seaLionBackground = new Sprite("SeaLionBackground.png");
        AddChild(_seaLionBackground);
        _seaLionBackground.visible = false;

        _seaLion = new SeaLion();
        AddChild(_seaLion);
        _seaLion.x = game.width / 2 - 400;
        _seaLion.y = 250;
        seaLionActive = false;
        _seaLion.visible = false;
        _seaLion.scale = 0.5f;
        //

        //Turtle residence
        _turtleBackground = new Sprite("TurtleBackground.png");
        AddChild(_turtleBackground);
        _turtleBackground.visible = false;

        _turtle = new Turtle();
        AddChild(_turtle);
        _turtle.x = game.width / 2 - 300;
        _turtle.y = 200;
        turtleActive = false;
        _turtle.visible = false;
        _turtle.scale = 0.7f;
        //

        //Monkey residence
        _monkeyBackground = new Sprite("MonkeyBackground.png");
        AddChild(_monkeyBackground);
        _monkeyBackground.visible = false;

        _monkey = new Monkey();
        AddChild(_monkey);
        _monkey.x = game.width / 2 - 635;
        _monkey.y = 285;
        monkeyActive = false;
        _monkey.visible = false;
        _monkey.scale = 1.1f;

        _monkeyFence = new Sprite("JungleFence.png");
        AddChild(_monkeyFence);
        _monkeyFence.visible = false;
        //

        //Lion residence
        _lionBackground = new Sprite("LionBackground.png");
        AddChild(_lionBackground);
        _lionBackground.visible = false;

        _lion = new Lion();
        AddChild(_lion);
        _lion.x = game.width / 2 - 50;
        _lion.y = 50;
        lionActive = false;
        _lion.visible = false;
        _lion.scale = 0.8f;
        //

        //Giraffe residence
        _giraffeBackground = new Sprite("GiraffeBackground.png");
        AddChild(_giraffeBackground);
        _giraffeBackground.visible = false;

        _giraffe = new Giraffe();
        AddChild(_giraffe);
        _giraffe.x = game.width / 2 - 165;
        _giraffe.y = 155;
        giraffeActive = false;
        _giraffe.visible = false;

        _giraffeFence = new Sprite("JungleFence.png");
        AddChild(_giraffeFence);
        _giraffeFence.visible = false;

        //Hippo residence
        _hippoBackground = new Sprite("HippoBackground.png");
        AddChild(_hippoBackground);
        _hippoBackground.visible = false;

        _hippo = new Hippo();
        AddChild(_hippo);
        _hippo.x = game.width / 2 - 350;
        _hippo.y = 370;
        hippoActive = false;
        _hippo.visible = false;
        _hippo.scale = 0.5f;

        _hippoFence = new Sprite("JungleFence.png");
        AddChild(_hippoFence);
        _hippoFence.visible = false;
        //
    }

    private void Update()
    {
        CheckAnimalActive();
    }

    private void CheckAnimalActive()
    {
        if (penguinActive)
        {
            _penguinFence.visible = true;
            _penguinBackground.visible = true;
            _penguin.visible = true;
            unlockedPenguin = true;
        }
        else
        {
            _penguinFence.visible = false;
            _penguinBackground.visible = false;
            _penguin.visible = false;
        }

        if (zebraActive)
        {
            _zebraFence.visible = true;
            _zebraBackground.visible = true;
            _zebra.visible = true;
        }
        else
        {
            _zebraFence.visible = false;
            _zebraBackground.visible = false;
            _zebra.visible = false;
        }

        if (seaLionActive)
        {
            _seaLionBackground.visible = true;
            _seaLion.visible = true;
        }
        else
        {
            _seaLionBackground.visible = false;
            _seaLion.visible = false;
        }

        if (turtleActive)
        {
            _turtleBackground.visible = true;
            _turtle.visible = true;
        }
        else
        {
            _turtleBackground.visible = false;
            _turtle.visible = false;
        }

        if (monkeyActive)
        {
            _monkeyFence.visible = true;
            _monkeyBackground.visible = true;
            _monkey.visible = true;
            unlockedMonkey = true;
        }
        else
        {
            _monkeyFence.visible = false;
            _monkeyBackground.visible = false;
            _monkey.visible = false;
        }

        if (lionActive)
        {
            _lion.visible = true;
            _lionBackground.visible = true;
            unlockedLion = true;
        }
        else
        {
            _lionBackground.visible = false;
            _lion.visible = false;
        }

        if (giraffeActive)
        {
            _giraffeFence.visible = true;
            _giraffe.visible = true;
            _giraffeBackground.visible = true;
        }
        else
        {
            _giraffeFence.visible = false;
            _giraffe.visible = false;
            _giraffeBackground.visible = false;
        }

        if (hippoActive)
        {
            _hippoFence.visible = true;
            _hippoBackground.visible = true;
            _hippo.visible = true;
        }
        else
        {
            _hippoFence.visible = false;
            _hippoBackground.visible = false;
            _hippo.visible = false;
        }
    }
}