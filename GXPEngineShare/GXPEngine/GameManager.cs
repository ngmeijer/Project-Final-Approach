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

    public int currentAnimal { get; set; }
    private int lastAnimal = 7;

    public GameManager()
    {
        _menu = new Menu();
        AddChild(_menu);

        _environment = new Environment();
        _environment.OnAnimalClicked += onAnimalClicked;
        AddChild(_environment);
        _environment.x = 2300;

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


    private void onAnimalClicked(Sprite pSprite)
    {
        Console.WriteLine("Animal clicked:"+pSprite);
        Console.WriteLine("Is giraffe "+(pSprite == _environment._giraffe));

        _gameHUD.clickedOptions = false;

        if(pSprite == _environment._penguin)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._penguinActive = true;
        }

        if (pSprite == _environment._zebra)
        {
            Console.WriteLine("true");
            environmentActive = false;
            residenceActive = true;
            _residence._zebraActive = true;
        }

        if (pSprite == _environment._seaLion)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._seaLionActive = true;
        }

        if (pSprite == _environment._turtle)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._turtleActive = true;
        }

        if (pSprite == _environment._monkey)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._monkeyActive = true;
        }

        if (pSprite == _environment._giraffe)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._giraffeActive = true;
        }

        if (pSprite == _environment._hippo)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._hippoActive = true;
        }

        if (pSprite == _environment._lion)
        {
            environmentActive = false;
            residenceActive = true;
            _residence._lionActive = true;
        }

        //turnOffAllAnimals(!pSprite);
    }

    private void turnOffAllAnimals()
    {

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
        }


        if (_gameHUD.clickedBack)
        {
            turnOffAllAnimals();
            _environment.visible = true;

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

                    _gameHUD.carnivore = true;
                    _gameHUD.herbivore = false;
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

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
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

                    _gameHUD.carnivore = true;
                    _gameHUD.herbivore = false;
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

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
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

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
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

                    _gameHUD.carnivore = true;
                    _gameHUD.herbivore = false;
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

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
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

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
                    break;
            }
        }
    }

    private void SendXpDataToTracker()
    {
        ////
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
        ///

        ///
        if (_residence._monkeyActive && _gameHUD.cleaning)
        {
            _scoreTracker._monkeyXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._monkeyActive && _gameHUD.feeding)
        {
            _scoreTracker._monkeyXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._monkeyActive && _gameHUD.petting)
        {
            _scoreTracker._monkeyXp += 5;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (_residence._lionActive && _gameHUD.cleaning)
        {
            _scoreTracker._lionXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._lionActive && _gameHUD.feeding)
        {
            _scoreTracker._lionXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._lionActive && _gameHUD.petting)
        {
            _scoreTracker._lionXp += 5;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (_residence._giraffeActive && _gameHUD.cleaning)
        {
            _scoreTracker._giraffeXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._giraffeActive && _gameHUD.feeding)
        {
            _scoreTracker._giraffeXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._giraffeActive && _gameHUD.petting)
        {
            _scoreTracker._giraffeXp += 5;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (_residence._zebraActive && _gameHUD.cleaning)
        {
            _scoreTracker._zebraXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._zebraActive && _gameHUD.feeding)
        {
            _scoreTracker._zebraXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._zebraActive && _gameHUD.petting)
        {
            _scoreTracker._zebraXp += 5;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (_residence._hippoActive && _gameHUD.cleaning)
        {
            _scoreTracker._hippoXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._hippoActive && _gameHUD.feeding)
        {
            _scoreTracker._hippoXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._hippoActive && _gameHUD.petting)
        {
            _scoreTracker._hippoXp += 5;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (_residence._seaLionActive && _gameHUD.cleaning)
        {
            _scoreTracker._seaLionXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._seaLionActive && _gameHUD.feeding)
        {
            _scoreTracker._seaLionXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._seaLionActive && _gameHUD.petting)
        {
            _scoreTracker._seaLionXp += 5;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (_residence._turtleActive && _gameHUD.cleaning)
        {
            _scoreTracker._turtleXp += 10;
            _gameHUD.cleaning = false;
        }

        if (_residence._turtleActive && _gameHUD.feeding)
        {
            _scoreTracker._turtleXp += 15;
            _gameHUD.feeding = false;
        }

        if (_residence._turtleActive && _gameHUD.petting)
        {
            _scoreTracker._turtleXp += 5;
            _gameHUD.petting = false;
        }
        ///
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