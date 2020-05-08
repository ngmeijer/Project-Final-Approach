using System;
using GXPEngine;

public class SceneManager : GameObject
{
    public Menu _menu { get; private set; }

    public HUD _gameHUD { get; private set; }

    public Environment _environment { get; private set; }

    public Residence _residence;

    public bool residenceActive;
    public bool environmentActive;

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
        SetChildIndex(_gameHUD, 1000);
    }

    private void Update()
    {
        CheckLevelStart();
        CheckResidenceActivity();
        SwitchAnimals();
    }

    private void CheckLevelStart()
    {
        if (_menu.levelStarted && !residenceActive)
        {
            _menu.x = 1920;
            _environment.x = 0;
            environmentActive = true;
        }
    }

    private void CheckResidenceActivity()
    {
        ////////////
        if (residenceActive)
        {
            _environment.visible = false;
            _gameHUD.residenceActive = true;
            SetChildIndex(_gameHUD, 1000);
        }

        if (!residenceActive)
        {
            _gameHUD.residenceActive = false;
        }
        /////////////

        if (environmentActive)
        {
            _gameHUD.environmentActive = true;
        }
        else if (!environmentActive)
        {
            Console.WriteLine("dont show options");
            _gameHUD.environmentActive = false;
        }

        if (!_gameHUD.clickedOptions)
        {
            _environment.canClickOnResidence = true;

            if (_environment.clickedPenguin)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._penguinActive = true;
            }

            if (_environment.clickedZebra)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._zebraActive = true;
            }

            if (_environment.clickedSeaLion)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._seaLionActive = true;
            }

            if (_environment.clickedTurtle)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._turtleActive = true;
            }

            if (_environment.clickedMonkey)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._monkeyActive = true;
            }

            if (_environment.clickedLion)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._lionActive = true;
            }

            if (_environment.clickedGiraffe)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._giraffeActive = true;
            }

            if (_environment.clickedHippo)
            {
                environmentActive = false;
                residenceActive = true;
                _residence._hippoActive = true;
            }
        }

        //////////////////////////////////////
        ///

        if (_gameHUD.clickedBack)
        {
            _environment.visible = true;
            _environment.clickedPenguin = false;
            _environment.clickedZebra = false;
            _environment.clickedSeaLion = false;
            _environment.clickedTurtle = false;
            _environment.clickedMonkey = false;
            _environment.clickedLion = false;
            _environment.clickedGiraffe = false;
            _environment.clickedHippo = false;

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