﻿using System;
using System.Collections.Generic;
using GXPEngine;

public class Environment : GameObject
{
    public bool canClickOnResidence { get; set; }

    public Penguin _penguin { get; private set; }
    public Zebra _zebra { get; private set; }
    public SeaLion _seaLion { get; private set; }
    public Turtle _turtle { get; private set; }
    public Monkey _monkey { get; private set; }
    public Lion _lion { get; private set; }
    public Giraffe _giraffe { get; private set; }
    public Hippo _hippo { get; private set; }

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
        _lion = new Lion();
        AddChild(_lion);
        _lion.SetXY(game.width / 2 - 600, 700);
        _lion.scale = 0.4f;

        _giraffe = new Giraffe();
        AddChild(_giraffe);
        _giraffe.SetXY(game.width / 2 - 800, 200);
        _giraffe.scale = 1f;

        _zebra = new Zebra();
        AddChild(_zebra);
        _zebra.SetXY(game.width / 2 - 500, 150);
        _zebra.scale = 0.3f;

        _hippo = new Hippo();
        AddChild(_hippo);
        _hippo.SetXY(game.width / 2 - 200, 100);
        _hippo.scale = 0.3f;

        _monkey = new Monkey();
        AddChild(_monkey);
        _monkey.SetXY(game.width / 2 + 200, 100);
        _monkey.scale = 0.3f;

        _seaLion = new SeaLion();
        AddChild(_seaLion);
        _seaLion.SetXY(game.width / 2 + 500, 150);
        _seaLion.scale = 0.3f;

        _penguin = new Penguin();
        AddChild(_penguin);
        _penguin.SetXY(game.width / 2 + 800, 550);
        _penguin.scale = 0.3f;

        _turtle = new Turtle();
        AddChild(_turtle);
        _turtle.SetXY(game.width / 2 + 600, 950);
        _turtle.scale = 0.3f;

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
