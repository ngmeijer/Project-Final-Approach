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

        _zebra = new Sprite("HubZebra.png");
        AddChild(_zebra);
        _zebra.SetXY(game.width / 2 - 950, 450);

        _giraffe = new Sprite("HubGiraffe.png");
        AddChild(_giraffe);
        _giraffe.SetXY(game.width / 2 - 950, 0);

        _lion = new Sprite("HubLion.png");
        AddChild(_lion);
        _lion.SetXY(game.width / 2 - 600, 750);

        _hippo = new Sprite("HubHippo.png");
        AddChild(_hippo);
        _hippo.SetXY(game.width / 2 - 400, 100);

        _monkey = new Sprite("HubMonkey.png");
        AddChild(_monkey);
        _monkey.SetXY(game.width / 2, -20);

        _seaLion = new Sprite("HubSeaLion.png");
        AddChild(_seaLion);
        _seaLion.SetXY(game.width / 2 + 400, 200);

        _penguin = new Sprite("HubPenguin.png");
        AddChild(_penguin);
        _penguin.SetXY(game.width / 2 + 550, 520);

        _turtle = new Sprite("HubTurtle.png");
        AddChild(_turtle);
        _turtle.SetXY(game.width / 2 + 250, 760);

        animals.Add(_lion);
        animals.Add(_giraffe);
        animals.Add(_zebra);
        animals.Add(_hippo);
        animals.Add(_monkey);
        animals.Add(_seaLion);
        animals.Add(_penguin);
        animals.Add(_turtle);
    }

    private void Update()
    {
        ClickResidence();
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
            if (animal.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                OnAnimalClicked(animal);
            }
        }

        /*
        if (canClickOnResidence)
        {
            if (_penguin.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedPenguin = true;
                }
            }

            if (_zebra.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedZebra = true;
                }
            }

            if (_seaLion.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedSeaLion = true;
                }
            }

            if (_turtle.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedTurtle = true;
                }
            }

            if (_monkey.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedMonkey = true;
                }
            }

            if (_lion.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedLion = true;
                }
            }

            if (_giraffe.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedGiraffe = true;
                }
            }

            if (_hippo.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedHippo = true;
                }
            }
        }
        */
    }
}
