using System;
using System.Collections.Generic;
using GXPEngine;

public class Environment : GameObject
{
    public bool canClickOnResidence { get; set; }

    public Sprite HubBackground { get; private set; }
    public Sprite _penguin { get; private set; }
    public Sprite _zebra { get; private set; }
    public Sprite _seaLion { get; private set; }
    public Sprite _turtle { get; private set; }
    public Sprite _monkey { get; private set; }
    public Sprite _lion { get; private set; }
    public Sprite _giraffe { get; private set; }
    public Sprite _hippo { get; private set; }

    public bool giraffeUnlocked { get; set; }
    public bool zebraUnlocked { get; set; }
    public bool hippoUnlocked { get; set; }
    public bool seaLionUnlocked { get; set; }
    public bool turtleUnlocked { get; set; }


    public bool clickedPenguin { get; set; }
    public bool clickedZebra { get; set; }
    public bool clickedSeaLion { get; set; }
    public bool clickedTurtle { get; set; }
    public bool clickedMonkey { get; set; }
    public bool clickedLion { get; set; }
    public bool clickedGiraffe { get; set; }
    public bool clickedHippo { get; set; }

    public int currentAnimal;

    //3 starting animals
    //Penguin monkey lion

    //5 starting animals
    //Penguin monkey lion giraffe zebra

    private List<Sprite> animals = new List<Sprite>();

    public event Action<Sprite> OnAnimalClicked = delegate { };

    public Environment()
    {
        HubBackground = new Sprite("HubNoAnimals.png");
        AddChild(HubBackground);

        _penguin = new Sprite("HubPenguin.png");
        AddChild(_penguin);
        _penguin.SetXY(game.width / 2 + 550, 520);

        _monkey = new Sprite("HubMonkey.png");
        AddChild(_monkey);
        _monkey.SetXY(game.width / 2, -20);

        _giraffe = new Sprite("HubGiraffe.png");
        AddChild(_giraffe);
        _giraffe.SetXY(game.width / 2 - 950, 0);
        _giraffe.visible = false;

        _lion = new Sprite("HubLion.png");
        AddChild(_lion);
        _lion.SetXY(game.width / 2 - 600, 750);

        _zebra = new Sprite("HubZebra.png");
        AddChild(_zebra);
        _zebra.SetXY(game.width / 2 - 950, 450);
        _zebra.visible = false;

        _hippo = new Sprite("HubHippo.png");
        AddChild(_hippo);
        _hippo.SetXY(game.width / 2 - 400, 100);
        _hippo.visible = false;

        _seaLion = new Sprite("HubSeaLion.png");
        AddChild(_seaLion);
        _seaLion.SetXY(game.width / 2 + 400, 200);
        _seaLion.visible = false;

        _turtle = new Sprite("HubTurtle.png");
        AddChild(_turtle);
        _turtle.SetXY(game.width / 2 + 250, 760);
        _turtle.visible = false;

        //0
        animals.Add(_penguin);
        //1
        animals.Add(_monkey);
        //2
        animals.Add(_giraffe);
        //3
        animals.Add(_lion);
        //4
        animals.Add(_zebra);
        //5
        animals.Add(_hippo);
        //6
        animals.Add(_seaLion);
        //7
        animals.Add(_turtle);
    }

    private void Update()
    {
        ClickResidence();
        UnlockAnimals();
    }

    /*
    private void pseudoCode()
    {
        InteractiveImage animal = new InteractiveImage("zebra", x, y, index);
        animal.onClicked += onZebraClicked;
        animal.onClicked += onAnimalClicked;

        InteractiveImage leftButton = ....
            leftButton.onClicked ...
    }
    */

    private void ClickResidence()
    {
        if (!Input.GetMouseButtonDown(0)) return; 

        foreach (Sprite animal in animals)
        {
            if (animal.HitTestPoint(Input.mouseX, Input.mouseY) && animal.visible)
            {
                OnAnimalClicked(animal);
            }
        }
    }

    private void UnlockAnimals()
    {
        if (giraffeUnlocked)
        {
            _giraffe.visible = true;
        }

        if (zebraUnlocked)
        {
            _zebra.visible = true;
        }

        if (hippoUnlocked)
        {
            _hippo.visible = true;
        }

        if (seaLionUnlocked)
        {
            _seaLion.visible = true;
        }

        if (turtleUnlocked)
        {
            _turtle.visible = true;
        }
    }
}
