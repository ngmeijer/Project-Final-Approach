using System;
using System.Drawing;
using GXPEngine;
using TiledMapParser;

public class HUD : Canvas
{
    public Sprite _rightButton;
    public Sprite _leftButton;
    public Sprite _lowerButton;
    public Sprite _interactionMenuButton;
    public Sprite _cleanIcon;
    public Sprite _feedIcon;
    public Sprite _petIcon;

    public Sprite _optionsButton;
    public Sprite _optionsBackground;
    public Sprite _continueButton;
    public Sprite _mileStonesButton;
    public Sprite _exitButton;

    public Sprite _mileStonesExit;
    public Sprite _mileStonesBackground;

    public int _penguinLevel;
    public int _penguinCurrentXp;

    public bool clickedBack { get; set; }
    public bool clickedLeft { get; set; }
    public bool clickedRight { get; set; }
    public bool mainAreaActive { get; set; }
    public bool clickedOptions { get; set; }

    private bool clickedMilestones = false;
    public bool petting { get; set; }
    public bool cleaning { get; set; }
    public bool feeding { get; set; }

    public int currentXpAmount = 0;
    public bool showPenguinStats { get; set; }

    public bool showInteractionMenu { get; set; }

    public bool environmentActive { get; set; }

    public bool residenceActive { get; set; }

    private readonly Brush _fontColor;
    private readonly Font _font;

    public HUD() : base(1920, 1080, false)
    {
        //Residence HUD
        _rightButton = new Sprite("RightButton.png");
        AddChild(_rightButton);
        _rightButton.x = 1793;
        _rightButton.y = 416;

        _leftButton = new Sprite("LeftButton.png");
        AddChild(_leftButton);
        _leftButton.x = 15;
        _leftButton.y = 416;

        _lowerButton = new Sprite("LowerButton.png");
        AddChild(_lowerButton);
        _lowerButton.x = 560;
        _lowerButton.y = 966;

        _interactionMenuButton = new Sprite("InteractionMenuButton.png");
        AddChild(_interactionMenuButton);
        _interactionMenuButton.x = game.width - 100;
        _interactionMenuButton.y = 20;

        _cleanIcon = new Sprite("CleanIcon.png");
        AddChild(_cleanIcon);
        _cleanIcon.x = game.width - 150;
        _cleanIcon.y = 80;
        _cleanIcon.visible = false;

        _feedIcon = new Sprite("FeedIcon.png");
        AddChild(_feedIcon);
        _feedIcon.x = game.width - 150;
        _feedIcon.y = 180;
        _feedIcon.visible = false;

        /////////////////

        //Options menu
        _optionsButton = new Sprite("OptionsButton.png");
        AddChild(_optionsButton);
        _optionsButton.x = game.width - 100;
        _optionsButton.y = 20;

        _optionsBackground = new Sprite("OptionsBackground.png");
        AddChild(_optionsBackground);
        _optionsBackground.x = game.width / 2 - _optionsBackground.width / 2;
        _optionsBackground.y = game.height / 2 - _optionsBackground.height / 2;
        _optionsBackground.visible = false;

        _continueButton = new Sprite("ContinueButton.png");
        AddChild(_continueButton);
        _continueButton.x = game.width / 2 - _continueButton.width / 2;
        _continueButton.y = game.height / 2 - _continueButton.height / 2 - 120;
        _continueButton.visible = false;

        _mileStonesButton = new Sprite("MileStonesButton.png");
        AddChild(_mileStonesButton);
        _mileStonesButton.x = game.width / 2 - _mileStonesButton.width / 2;
        _mileStonesButton.y = game.height / 2 - _mileStonesButton.height / 2;
        _mileStonesButton.visible = false;

        _exitButton = new Sprite("ExitButton.png");
        AddChild(_exitButton);
        _exitButton.x = game.width / 2 - _exitButton.width / 2;
        _exitButton.y = game.height / 2 - _exitButton.height / 2 + 120;
        _exitButton.visible = false;
        ///////////////

        //Milestones menu
        _mileStonesBackground = new Sprite("MileStonesBackground.png");
        AddChild(_mileStonesBackground);
        _mileStonesBackground.x = game.width / 2 - _mileStonesBackground.width / 2;
        _mileStonesBackground.y = game.height / 2 - _mileStonesBackground.height / 2;
        _mileStonesBackground.visible = false;

        _mileStonesExit = new Sprite("MilestoneExit.png");
        AddChild(_mileStonesExit);
        _mileStonesExit.x = game.width / 2 - _mileStonesExit.width / 2;
        _mileStonesExit.y = game.height / 2 - _mileStonesExit.height / 2 + 200;
        _mileStonesExit.visible = false;
        SetChildIndex(_mileStonesExit, 100);
        //

        _fontColor = Brushes.White;
        _font = new Font("Arial", 20);
    }

    private void Update()
    {
        graphics.Clear(Color.Empty);
        CheckForAnimalSwitching();
        CheckForOptionsRequest();
        ShowInteractionMenu();
        InteractWithAnimal();
        ShowCurrentXpAndLevel();
    }

    private void CheckForAnimalSwitching()
    {
        if (residenceActive)
        {
            _lowerButton.visible = true;
            _rightButton.visible = true;
            _leftButton.visible = true;

            _interactionMenuButton.visible = true;

            if (_lowerButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedBack = true;
                    mainAreaActive = true;
                }
            }

            if (_leftButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedLeft = true;
                }
            }

            if (_rightButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedRight = true;
                }
            }
        }

        if (!residenceActive)
        {
            _lowerButton.visible = false;
            _rightButton.visible = false;
            _leftButton.visible = false;

            _interactionMenuButton.visible = false;
        }
    }

    public void CheckForOptionsRequest()
    {
        if (environmentActive)
        {
            _optionsButton.visible = true;

            if (_optionsButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
            {
                clickedOptions = true;
            }

            if (clickedOptions)
            {
                _optionsBackground.visible = true;
                _continueButton.visible = true;
                _mileStonesButton.visible = true;
                _exitButton.visible = true;
            }
            else if (!clickedOptions)
            {
                _optionsBackground.visible = false;
                _continueButton.visible = false;
                _mileStonesButton.visible = false;
                _exitButton.visible = false;
            }

            if (_continueButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
            {
                clickedOptions = false;
            }

            if (_mileStonesButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
            {
                clickedMilestones = true;
            }

            if (_exitButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
            {
                MyGame.main.Destroy();
            }

            if (clickedMilestones)
            {
                ShowMilestones();
            }

            if (!clickedMilestones && clickedOptions)
            {
                _mileStonesBackground.visible = false;
                _mileStonesExit.visible = false;

                _optionsBackground.visible = true;
                _continueButton.visible = true;
                _mileStonesButton.visible = true;
                _exitButton.visible = true;
            }
        }

        if (!environmentActive)
        {
            _optionsButton.visible = false;
        }
    }

    private void ShowMilestones()
    {
        graphics.DrawString("Level = ", _font, _fontColor, 700, 500);

        _mileStonesBackground.visible = true;
        _mileStonesExit.visible = true;


        if (_mileStonesExit.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            clickedMilestones = false;
            clickedOptions = true;
        }
    }

    private void ShowInteractionMenu()
    {
        if (residenceActive)
        {
            if (showInteractionMenu)
            {
                _cleanIcon.visible = true;
                _feedIcon.visible = true;
            }
            else if (!showInteractionMenu)
            {
                _cleanIcon.visible = false;
                _feedIcon.visible = false;
            }

            if (_interactionMenuButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0) && !showInteractionMenu)
            {
                showInteractionMenu = true;
            }

            if (!_interactionMenuButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0) && showInteractionMenu)
            {
                showInteractionMenu = false;
            }
        }
    }

    private void InteractWithAnimal()
    {
        if (_cleanIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            cleaning = true;
        }

        if (_feedIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            feeding = true;
        }

        //if (_petIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        //{
        //    petting = true;
        //}
    }

    private void ShowCurrentXpAndLevel()
    {

    }
}