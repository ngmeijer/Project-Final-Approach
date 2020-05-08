using System;
using GXPEngine;

public class HUD : GameObject
{
    public Sprite _rightButton;
    public Sprite _leftButton;
    public Sprite _lowerButton;

    public Sprite _optionsButton;
    public Sprite _optionsBackground;
    public Sprite _continueButton;
    public Sprite _mileStonesButton;
    public Sprite _exitButton;

    public Sprite _mileStonesExit;
    public Sprite _mileStonesBackground;

    public bool clickedBack { get; set; }
    public bool clickedLeft { get; set; }
    public bool clickedRight { get; set; }
    public bool mainAreaActive { get; set; }
    public bool clickedOptions { get; set; }

    private bool clickedMilestones = false;

    public bool environmentActive { get; set; }

    public bool residenceActive { get; set; }

    public HUD()
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

        _mileStonesExit = new Sprite("ExitButton.png");
        AddChild(_mileStonesExit);
        _mileStonesExit.x = game.width / 2 - _mileStonesExit.width / 2;
        _mileStonesExit.y = game.height / 2 - _mileStonesExit.height / 2 + 240;
        _mileStonesExit.visible = false;
        //
    }

    private void Update()
    {
        CheckForAnimalSwitching();
        CheckForOptionsRequest();
    }

    private void CheckForAnimalSwitching()
    {
        if (residenceActive)
        {
            _lowerButton.visible = true;
            _rightButton.visible = true;
            _leftButton.visible = true;
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
        }

        if (!environmentActive)
        {
            _optionsButton.visible = false;
        }
    }

    private void ShowMilestones()
    {

    }
}