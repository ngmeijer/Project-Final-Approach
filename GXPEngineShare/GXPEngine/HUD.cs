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

    public bool clickedBack { get; set; }
    public bool clickedLeft { get; set; }
    public bool clickedRight { get; set; }
    public bool mainAreaActive { get; set; }
    public bool clickedOptions { get; set; }


    public bool showHUD { get; set; }

    public HUD()
    {
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
    }

    private void Update()
    {
        CheckForAnimalSwitching();
        CheckForOptionsRequest();
    }

    private void CheckForAnimalSwitching()
    {
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

    public void CheckForOptionsRequest()
    {
        if (_optionsButton.HitTestPoint(Input.mouseX, Input.mouseY) && !clickedOptions)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedOptions = true;
            }
        }
        else if (clickedOptions && !_optionsBackground.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedOptions = false;
            }
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
    }
}
