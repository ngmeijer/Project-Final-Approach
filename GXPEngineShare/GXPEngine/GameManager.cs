using System;
using GXPEngine;

public class GameManager : GameObject
{
    public Menu _menu { get; private set; }
    public HUD _gameHUD { get; private set; }

    public SoundManager soundManager;

    public ScoreTracker scoreTracker { get; private set; }

    public Environment environment { get; private set; }

    public Residence residence;

    public bool residenceActive;
    public bool environmentActive;

    private int feedingXp = 50;
    private int cleaningXp = 50;
    private int pettingXp = 50;

    public int currentAnimal { get; set; }
    private int lastAnimal = 2;

    private bool feedingLion;
    private bool cleaningLion;
    private bool pettingLion;

    private bool feedingMonkey;
    private bool pettingMonkey;
    private bool cleaningMonkey;

    public GameManager()
    {
        _menu = new Menu();
        AddChild(_menu);

        environment = new Environment();
        environment.OnAnimalClicked += onAnimalClicked;
        AddChild(environment);
        environment.x = 2300;

        //Animal residences
        residence = new Residence();
        AddChild(residence);
        residence.x = 0;
        /////////////////////

        _gameHUD = new HUD();
        AddChild(_gameHUD);

        soundManager = new SoundManager();
        AddChild(soundManager);

        scoreTracker = new ScoreTracker();
        AddChild(scoreTracker);
        SetChildIndex(scoreTracker, 200000);
    }

    private void Update()
    {
        CheckLevelStart();
        CheckResidenceActivity();
        SwitchAnimals();
        SendXpDataToTracker();
        SendXpDataToHUD();
        CheckAnimalLevelProgress();
        HandleAnimalAnimations();
        HandleSounds();
        SendDataToOptionsMenu();
    }
    private void onAnimalClicked(Sprite pSprite)
    {
        //Console.WriteLine("Animal clicked:"+pSprite);
        //Console.WriteLine("Is giraffe "+(pSprite == _environment._giraffe));

        _gameHUD.clickedOptions = false;

        if (pSprite == environment._penguin)
        {
            environmentActive = false;
            residenceActive = true;
            residence.penguinActive = true;
        }

        if (pSprite == environment._zebra)
        {
            environmentActive = false;
            residenceActive = true;
            residence.zebraActive = true;
        }

        if (pSprite == environment._seaLion)
        {
            environmentActive = false;
            residenceActive = true;
            residence.seaLionActive = true;
        }

        if (pSprite == environment._turtle)
        {
            environmentActive = false;
            residenceActive = true;
            residence.turtleActive = true;
        }

        if (pSprite == environment._monkey)
        {
            environmentActive = false;
            residenceActive = true;
            residence.monkeyActive = true;
        }

        if (pSprite == environment._giraffe)
        {
            environmentActive = false;
            residenceActive = true;
            residence.giraffeActive = true;
        }

        if (pSprite == environment._hippo)
        {
            environmentActive = false;
            residenceActive = true;
            residence.hippoActive = true;
        }

        if (pSprite == environment._lion)
        {
            environmentActive = false;
            residenceActive = true;
            residence.lionActive = true;
        }

        //turnOffAllAnimals(!pSprite);
    }

    private void CheckLevelStart()
    {
        if (_menu.levelStarted && !residenceActive)
        {
            _menu.x = 3000;
            environment.x = 0;
            environmentActive = true;
        }
    }

    private void CheckResidenceActivity()
    {
        if (residenceActive)
        {
            environment.visible = false;
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
            environment.canClickOnResidence = true;
        }

        if (_gameHUD.clickedBack)
        {
            TurnOffAllAnimals();
            environment.visible = true;

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
                    residence.penguinActive = true;
                    residence.zebraActive = false;
                    residence.seaLionActive = false;
                    residence.turtleActive = false;
                    residence.monkeyActive = false;
                    residence.lionActive = false;
                    residence.giraffeActive = false;
                    residence.hippoActive = false;

                    _gameHUD.carnivore = true;
                    _gameHUD.herbivore = false;
                    break;
                case 1:
                    //Monkey
                    residence.penguinActive = false;
                    residence.zebraActive = false;
                    residence.seaLionActive = false;
                    residence.turtleActive = false;
                    residence.monkeyActive = true;
                    residence.lionActive = false;
                    residence.giraffeActive = false;
                    residence.hippoActive = false;

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;

                    _gameHUD.lionActive = false;
                    _gameHUD.monkeyActive = true;
                    break;
                case 2:
                    //Lion
                    residence.penguinActive = false;
                    residence.zebraActive = false;
                    residence.seaLionActive = false;
                    residence.turtleActive = false;
                    residence.monkeyActive = false;
                    residence.lionActive = true;
                    residence.giraffeActive = false;
                    residence.hippoActive = false;

                    _gameHUD.carnivore = true;
                    _gameHUD.herbivore = false;

                    _gameHUD.monkeyActive = false;
                    _gameHUD.lionActive = true;
                    break;
                case 3:
                    //Giraffe
                    residence.penguinActive = false;
                    residence.zebraActive = false;
                    residence.seaLionActive = false;
                    residence.turtleActive = false;
                    residence.monkeyActive = false;
                    residence.lionActive = false;
                    residence.giraffeActive = true;
                    residence.hippoActive = false;

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
                    break;
                case 4:
                    //Zebra
                    residence.penguinActive = false;
                    residence.zebraActive = true;
                    residence.seaLionActive = false;
                    residence.turtleActive = false;
                    residence.monkeyActive = false;
                    residence.lionActive = false;
                    residence.giraffeActive = false;
                    residence.hippoActive = false;

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
                    break;
                case 5:
                    //Hippo
                    residence.penguinActive = false;
                    residence.zebraActive = false;
                    residence.seaLionActive = false;
                    residence.turtleActive = false;
                    residence.monkeyActive = false;
                    residence.lionActive = false;
                    residence.giraffeActive = false;
                    residence.hippoActive = true;

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
                    break;
                case 6:
                    //Sea-lion
                    residence.penguinActive = false;
                    residence.zebraActive = false;
                    residence.seaLionActive = true;
                    residence.turtleActive = false;
                    residence.monkeyActive = false;
                    residence.lionActive = false;
                    residence.giraffeActive = false;
                    residence.hippoActive = false;

                    _gameHUD.carnivore = true;
                    _gameHUD.herbivore = false;
                    break;
                case 7:
                    //Turtle
                    residence.penguinActive = false;
                    residence.zebraActive = false;
                    residence.seaLionActive = false;
                    residence.turtleActive = true;
                    residence.monkeyActive = false;
                    residence.lionActive = false;
                    residence.giraffeActive = false;
                    residence.hippoActive = false;

                    _gameHUD.herbivore = true;
                    _gameHUD.carnivore = false;
                    break;
            }
        }
    }

    private void SendXpDataToTracker()
    {
        ////
        if (residence.penguinActive && _gameHUD.cleaning)
        {
            scoreTracker.penguinXp += cleaningXp;
            _gameHUD.cleaning = false;
        }

        if (residence.penguinActive && _gameHUD.feeding)
        {
            scoreTracker.penguinXp += feedingXp;
            _gameHUD.feeding = false;
        }

        if (residence.penguinActive && _gameHUD.petting)
        {
            scoreTracker.penguinXp += pettingXp;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.monkeyActive && _gameHUD.cleaning)
        {
            scoreTracker.monkeyXp += cleaningXp;
            cleaningMonkey = true;
            _gameHUD.cleaning = false;
        }

        if (residence.monkeyActive && _gameHUD.feeding)
        {
            scoreTracker.monkeyXp += feedingXp;
            feedingMonkey = true;
            _gameHUD.feeding = false;
        }

        if (residence.monkeyActive && _gameHUD.petting)
        {
            scoreTracker.monkeyXp += pettingXp;
            pettingMonkey = true;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.lionActive && _gameHUD.cleaning)
        {
            scoreTracker.lionXp += cleaningXp;
            cleaningLion = true;
            _gameHUD.cleaning = false;
        }

        if (residence.lionActive && _gameHUD.feeding)
        {
            scoreTracker.lionXp += feedingXp;
            soundManager.feedSound.Play(false, 0, 1);
            feedingLion = true;
            _gameHUD.feeding = false;
        }

        if (residence.lionActive && _gameHUD.petting)
        {
            scoreTracker.lionXp += pettingXp;
            pettingLion = true;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.giraffeActive && _gameHUD.cleaning)
        {
            scoreTracker.giraffeXp += cleaningXp;
            _gameHUD.cleaning = false;
        }

        if (residence.giraffeActive && _gameHUD.feeding)
        {
            scoreTracker.giraffeXp += feedingXp;
            _gameHUD.feeding = false;
        }

        if (residence.giraffeActive && _gameHUD.petting)
        {
            scoreTracker.giraffeXp += pettingXp;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.zebraActive && _gameHUD.cleaning)
        {
            scoreTracker.zebraXp += cleaningXp;
            _gameHUD.cleaning = false;
        }

        if (residence.zebraActive && _gameHUD.feeding)
        {
            scoreTracker.zebraXp += feedingXp;
            _gameHUD.feeding = false;
        }

        if (residence.zebraActive && _gameHUD.petting)
        {
            scoreTracker.zebraXp += pettingXp;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.hippoActive && _gameHUD.cleaning)
        {
            scoreTracker.hippoXp += cleaningXp;
            _gameHUD.cleaning = false;
        }

        if (residence.hippoActive && _gameHUD.feeding)
        {
            scoreTracker.hippoXp += feedingXp;
            _gameHUD.feeding = false;
        }

        if (residence.hippoActive && _gameHUD.petting)
        {
            scoreTracker.hippoXp += pettingXp;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.seaLionActive && _gameHUD.cleaning)
        {
            scoreTracker.seaLionXp += cleaningXp;
            _gameHUD.cleaning = false;
        }

        if (residence.seaLionActive && _gameHUD.feeding)
        {
            scoreTracker.seaLionXp += 15;
            _gameHUD.feeding = false;
        }

        if (residence.seaLionActive && _gameHUD.petting)
        {
            scoreTracker.seaLionXp += pettingXp;
            _gameHUD.petting = false;
        }
        ///

        ///
        if (residence.turtleActive && _gameHUD.cleaning)
        {
            scoreTracker.turtleXp += cleaningXp;
            _gameHUD.cleaning = false;
        }

        if (residence.turtleActive && _gameHUD.feeding)
        {
            scoreTracker.turtleXp += feedingXp;
            _gameHUD.feeding = false;
        }

        if (residence.turtleActive && _gameHUD.petting)
        {
            scoreTracker.turtleXp += pettingXp;
            _gameHUD.petting = false;
        }
        ///
    }

    private void SendXpDataToHUD()
    {
        _gameHUD.lionLevel = scoreTracker.lionLevel;
        _gameHUD._penguinLevel = scoreTracker.penguinLevel;
        _gameHUD.monkeyLevel = scoreTracker.monkeyLevel;

        if (_gameHUD.clickedOptions)
        {
            scoreTracker.showAnimalStats = true;
            scoreTracker.clickedOptions = true;

            if (residence.unlockedLion)
            {
                scoreTracker.unlockedLion = true;
            }

            if (residence.unlockedGiraffe)
            {
                scoreTracker.unlockedGiraffe = true;
            }

            if (residence.unlockedZebra)
            {
                scoreTracker.unlockedZebra = true;
            }

            if (residence.unlockedHippo)
            {
                scoreTracker.unlockedHippo = true;
            }

            if (residence.unlockedMonkey)
            {
                scoreTracker.unlockedMonkey = true;
            }

            if (residence.unlockedSeaLion)
            {
                scoreTracker.unlockedSeaLion = true;
            }

            if (residence.unlockedPenguin)
            {
                scoreTracker.unlockedPenguin = true;
            }

            if (residence.unlockedTurtle)
            {
                scoreTracker.unlockedTurtle = true;
            }
        }
        else if (!_gameHUD.showAnimalStats)
        {
            scoreTracker.showAnimalStats = false;
        }
    }

    private void CheckAnimalLevelProgress()
    {
        if (scoreTracker.unlockedGiraffe)
        {
            lastAnimal = 3;
            environment.giraffeUnlocked = true;
            _gameHUD._optionsBackground.giraffeUnlocked = true;
        }

        if (scoreTracker.unlockedZebra)
        {
            lastAnimal = 4;
            environment.zebraUnlocked = true;
            _gameHUD._optionsBackground.zebraUnlocked = true;
        }

        if (scoreTracker.unlockedHippo)
        {
            lastAnimal = 5;
            environment.hippoUnlocked = true;
            _gameHUD._optionsBackground.hippoUnlocked = true;
        }

        if (scoreTracker.unlockedSeaLion)
        {
            lastAnimal = 6;
            environment.seaLionUnlocked = true;
            _gameHUD._optionsBackground.seaLionUnlocked = true;
        }

        if (scoreTracker.unlockedTurtle)
        {
            lastAnimal = 7;
            environment.turtleUnlocked = true;
            _gameHUD._optionsBackground.turtleUnlocked = true;
        }
    }

    private void TurnOffAllAnimals()
    {
        environment.clickedPenguin = false;
        environment.clickedZebra = false;
        environment.clickedSeaLion = false;
        environment.clickedTurtle = false;
        environment.clickedMonkey = false;
        environment.clickedLion = false;
        environment.clickedGiraffe = false;
        environment.clickedHippo = false;

        residence.penguinActive = false;
        residence.zebraActive = false;
        residence.seaLionActive = false;
        residence.turtleActive = false;
        residence.monkeyActive = false;
        residence.lionActive = false;
        residence.giraffeActive = false;
        residence.hippoActive = false;
    }

    private void HandleAnimalAnimations()
    {
        if (residence.lionActive)
        {
            if (feedingLion)
            {
                residence._lion.feeding = true;
                feedingLion = false;
            }

            if (pettingLion)
            {
                residence._lion.petting = true;
                pettingLion = false;
            }

            if (cleaningLion)
            {
                residence._lion.cleaning = true;
                cleaningLion = false;
            }
        }

        if (residence.monkeyActive)
        {
            if (feedingMonkey)
            {
                residence._monkey.feeding = true;
                feedingMonkey = false;
            }

            if (pettingMonkey)
            {
                residence._monkey.petting = true;
                pettingMonkey = false;
            }

            if (cleaningMonkey)
            {
                residence._monkey.cleaning = true;
                cleaningMonkey = false;
            }
        }
    }

    private void HandleSounds()
    {
        if (_gameHUD.feeding)
        {
            //soundManager.feedSound.Play(false, 1, 1);
        }

        if (_gameHUD.cleaning)
        {
            soundManager.cleanSound.Play(false, 1, 1);
        }
    }

    private void SendDataToOptionsMenu()
    {
        _gameHUD._optionsBackground.penguinLevel = scoreTracker.penguinLevel;
        _gameHUD._optionsBackground.lionLevel = scoreTracker.lionLevel;
        _gameHUD._optionsBackground._monkeyLevel = scoreTracker.monkeyLevel;
        _gameHUD._optionsBackground.giraffeLevel = scoreTracker.giraffeLevel;
        _gameHUD._optionsBackground.zebraLevel = scoreTracker.zebraLevel;
        _gameHUD._optionsBackground.hippoLevel = scoreTracker.hippoLevel;
        _gameHUD._optionsBackground._seaLionLevel = scoreTracker._seaLionLevel;
        _gameHUD._optionsBackground._turtleLevel = scoreTracker._turtleLevel;
    }
}