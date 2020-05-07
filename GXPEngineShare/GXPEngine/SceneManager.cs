using System;
using GXPEngine;

public class SceneManager : GameObject
{
    public Menu _menu { get; private set; }

    public HUD _gameHUD { get; private set; }

    public Environment _environment { get; private set; }

    public Residence _residence;

    public bool residenceActive;

    private int currentAnimal;
    private int lastAnimal = 7;

    public SceneManager()
    {
        _menu = new Menu();
        AddChild(_menu);

        _environment = new Environment();
        AddChild(_environment);
        _environment.x = 1920;

        //Animal residences
        _residence = new Residence();
        AddChild(_residence);
        _residence.x = 0;
        /////////////////////

        _gameHUD = new HUD();
        AddChild(_gameHUD);
        _gameHUD.visible = false;
        SetChildIndex(_gameHUD, 0);

        Console.WriteLine("current animal = " + currentAnimal);
    }

    private void Update()
    {
        CheckLevelStart();
        CheckResidenceActivity();
        SwitchAnimals();
    }

    private void CheckLevelStart()
    {
        if (_menu.levelStarted)
        {
            _menu.x = 1920;
            _environment.x = 0;
        }
    }

    private void CheckResidenceActivity()
    {
        if (residenceActive)
        {
            _environment.visible = false;
            _gameHUD.visible = true;
            SetChildIndex(_gameHUD, 1000);
        }

        if (_environment.clickedPenguin)
        {
            residenceActive = true;
            _residence._penguinActive = true;
        }

        if (_environment.clickedZebra)
        {
            residenceActive = true;
            _residence._zebraActive = true;
        }

        if (_environment.clickedSeaLion)
        {
            residenceActive = true;
            _residence._seaLionActive = true;
        }

        if (_environment.clickedTurtle)
        {
            residenceActive = true;
            _residence._turtleActive = true;
        }

        if (_environment.clickedMonkey)
        {
            residenceActive = true;
            _residence._monkeyActive = true;
        }

        if (_environment.clickedLion)
        {
            residenceActive = true;
            _residence._lionActive = true;
        }

        if (_environment.clickedGiraffe)
        {
            residenceActive = true;
            _residence._giraffeActive = true;
        }

        if (_environment.clickedHippo)
        {
            residenceActive = true;
            _residence._hippoActive = true;
        }

        //////////////////////////////////////
        ///

        if (_gameHUD.clickedBack)
        {
            _environment.visible = true;

            _residence._penguinActive = false;
            _residence._zebraActive = false;
            _residence._seaLionActive = false;
            _residence._turtleActive = false;
            _residence._monkeyActive = false;
            _residence._lionActive = false;
            _residence._giraffeActive = false;
            _residence._hippoActive = false;

            _gameHUD.clickedBack = false;

            residenceActive = false;
        }

        Console.WriteLine(currentAnimal);

        if (residenceActive)
        {
            if (_gameHUD.clickedLeft)
            {
                currentAnimal--;
                if (currentAnimal <= -1)
                {
                    currentAnimal = lastAnimal;
                }
                _gameHUD.clickedLeft = false;
            }

            if (_gameHUD.clickedRight)
            {
                currentAnimal++;
                if (currentAnimal > lastAnimal)
                {
                    currentAnimal = 0;
                }
                _gameHUD.clickedRight = false;
            }
        }

    }

    private void SwitchAnimals()
    {
        if (residenceActive)
        {
            switch (currentAnimal)
            {
                case 0:
                    //Penguin
                    _residence._penguinActive = true;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = false;
                    _residence._lionActive = false;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = false;
                    break;
                case 1:
                    //Zebra
                    _residence._penguinActive = false;
                    _residence._zebraActive = true;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = false;
                    _residence._lionActive = false;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = false;
                    break;
                case 2:
                    //Sea-lion
                    _residence._penguinActive = false;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = true;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = false;
                    _residence._lionActive = false;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = false;
                    break;
                case 3:
                    //Turtle
                    _residence._penguinActive = false;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = true;
                    _residence._monkeyActive = false;
                    _residence._lionActive = false;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = false;
                    break;
                case 4:
                    //Monkey
                    _residence._penguinActive = false;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = true;
                    _residence._lionActive = false;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = false;
                    break;
                case 5:
                    //Lion
                    _residence._penguinActive = false;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = false;
                    _residence._lionActive = true;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = false;
                    break;
                case 6:
                    //Giraffe
                    _residence._penguinActive = false;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = false;
                    _residence._lionActive = false;
                    _residence._giraffeActive = true;
                    _residence._hippoActive = false;
                    break;
                case 7:
                    //Hippo
                    _residence._penguinActive = false;
                    _residence._zebraActive = false;
                    _residence._seaLionActive = false;
                    _residence._turtleActive = false;
                    _residence._monkeyActive = false;
                    _residence._lionActive = false;
                    _residence._giraffeActive = false;
                    _residence._hippoActive = true;
                    break;
            }
        }

    }
}