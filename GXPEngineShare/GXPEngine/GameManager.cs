using System;
using GXPEngine;

public class GameManager : GameObject
{
    public Menu _menu { get; private set; }

    public HUD _gameHUD { get; private set; }

    public ScoreTracker _scoreTracker { get; private set; }

    public Environment _environment { get; private set; }

    public Residence _residence;

    public bool residenceActive;
    public bool environmentActive;

    private int currentAnimal;
    private int lastAnimal = 7;

    public GameManager()
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

        _scoreTracker = new ScoreTracker();
        AddChild(_scoreTracker);
    }

    private void Update()
    {
        CheckLevelStart();
        CheckResidenceActivity();
        SwitchAnimals();
        SendXpDataToTracker();
        SendXpDataToHUD();
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

        /////////////

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
                _gameHUD.showInteractionMenu = false;
                currentAnimal--;
                if (currentAnimal <= -1)
                {
                    currentAnimal = lastAnimal;
                }
                _gameHUD.clickedLeft = false;
            }

            if (_gameHUD.clickedRight)
            {
                _gameHUD.showInteractionMenu = false;
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

    private void SendXpDataToTracker()
    {
        if (_residence._penguinActive && _gameHUD.cleaning)
        {
            _scoreTracker._penguinXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._penguinActive && _gameHUD.feeding)
        {
            _scoreTracker._penguinXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._penguinActive && _gameHUD.petting)
        {
            _scoreTracker._penguinXp += 5;
            _gameHUD.petting = false;
        }
    }

    private void SendXpDataToHUD()
    {
        //Penguin
        _gameHUD._penguinLevel = _scoreTracker._penguinLevel;
        _gameHUD._penguinCurrentXp = _scoreTracker._penguinXp;
        //

        if (_gameHUD.clickedOptions)
        {
            _scoreTracker.showAnimalStats = true;
            _scoreTracker.clickedOptions = true;

            if (_residence.unlockedLion)
            {
                _scoreTracker.unlockedLion = true;
            }

            if (_residence.unlockedGiraffe)
            {
                _scoreTracker.unlockedGiraffe = true;
            }

            if (_residence.unlockedZebra)
            {
                _scoreTracker.unlockedZebra = true;
            }

            if (_residence.unlockedHippo)
            {
                _scoreTracker.unlockedHippo = true;
            }

            if (_residence.unlockedMonkey)
            {
                _scoreTracker.unlockedMonkey = true;
            }

            if (_residence.unlockedSeaLion)
            {
                _scoreTracker.unlockedSeaLion = true;
            }

            if (_residence.unlockedPenguin)
            {
                _scoreTracker.unlockedPenguin = true;
            }

            if (_residence.unlockedTurtle)
            {
                _scoreTracker.unlockedTurtle = true;
            }
        }
        else if (!_gameHUD.showAnimalStats)
        {
            _scoreTracker.showAnimalStats = false;
        }
    }
}