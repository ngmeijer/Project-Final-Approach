using System;
using GXPEngine;

public class Residence : GameObject
{
    private Penguin _penguin;
    private Zebra _zebra;
    private SeaLion _seaLion;
    private Turtle _turtle;
    private Monkey _monkey;
    private Lion _lion;
    private Giraffe _giraffe;
    private Hippo _hippo;

    private Sprite _penguinBackground;

    public bool _penguinActive;
    public bool _zebraActive;
    public bool _seaLionActive;
    public bool _turtleActive;
    public bool _monkeyActive;
    public bool _lionActive;
    public bool _giraffeActive;
    public bool _hippoActive;

    public Residence() : base()
    {
        
    }

    private void Update()
    {
        CheckAnimals();
    }

    private void CheckAnimals()
    {
        if (_penguinActive)
        {
            _penguinBackground = new Sprite("TurtleBackground.png");
            AddChild(_penguinBackground);

            _penguin = new Penguin();
            AddChild(_penguin);
            _penguin.x = game.width / 2;
            _penguin.y = game.height / 2;
        }

        if (_zebraActive)
        {
            _zebra = new Zebra();
            AddChild(_zebra);
            _zebra.x = game.width / 2 + 100;
            _zebra.y = game.height / 2;
        }

        if (_seaLionActive)
        {
            _seaLion = new SeaLion();
            AddChild(_seaLion);
            _seaLion.x = game.width / 2;
            _seaLion.y = game.height / 2;

            
        }

        if (_turtleActive)
        {
            _turtle = new Turtle();
            AddChild(_turtle);
            _turtle.x = game.width / 2;
            _turtle.y = game.height / 2;
        }

        if (_monkeyActive)
        {
            _monkey = new Monkey();
            AddChild(_monkey);
            _monkey.x = game.width / 2;
            _monkey.y = game.height / 2;
        }

        if (_lionActive)
        {
            _lion = new Lion();
            AddChild(_lion);
            _lion.x = game.width / 2;
            _lion.y = game.height / 2;
        }

        if (_giraffeActive)
        {
            _giraffe = new Giraffe();
            AddChild(_giraffe);
            _giraffe.x = game.width / 2;
            _giraffe.y = game.height / 2;
        }

        if (_hippoActive)
        {
            _hippo = new Hippo();
            AddChild(_hippo);
            _hippo.x = game.width / 2;
            _hippo.y = game.height / 2;
        }
    }
}