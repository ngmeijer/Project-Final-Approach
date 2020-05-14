﻿using System;
using System.Drawing;
using GXPEngine;

public class HUD : Canvas
{
    public Sprite _rightButton;
    public Sprite _leftButton;
    public Sprite _lowerButton;
    public Sprite _interactionMenuButton;
    public Sprite _cleanIcon;
    public Sprite _meatIcon;
    public Sprite _veggieIcon;
    public Sprite _petIcon;

    public Sprite _optionsButton;
    public OptionsMenu _optionsBackground;
    public Sprite _continueButton;
    public Sprite _mileStonesButton;
    public Sprite _exitButton;
    public Sprite _informationButton;
    public Sprite _informationBackground;

    public bool penguinActive;
    public bool monkeyActive;
    public bool giraffeActive;
    public bool lionActive;
    public bool zebraActive;
    public bool hippoActive;
    public bool seaLionActive;
    public bool turtleActive;

    public int _penguinLevel;
    public int _penguinCurrentXp;

    public bool carnivore;
    public bool herbivore;

    public bool clickedBack { get; set; }
    public bool clickedLeft { get; set; }
    public bool clickedRight { get; set; }
    public bool mainAreaActive { get; set; }
    public bool clickedOptions { get; set; }

    public bool petting { get; set; }
    public bool cleaning { get; set; }
    public bool feeding { get; set; }

    public int currentXpAmount = 0;
    private bool showInformationMenu;
    public int lionLevel = 0;

    private Brush _fontColor;
    private Font _font;

    public bool showAnimalStats { get; set; }

    public bool showInteractionMenu { get; set; }

    public bool environmentActive { get; set; }

    public bool residenceActive { get; set; }

    /////////Tips
    EasyDraw lionTip1 = new EasyDraw(1920, 1080);
    EasyDraw lionTip2 = new EasyDraw(1920, 1080);


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

        _informationButton = new Sprite("Information.png");
        AddChild(_informationButton);
        _informationButton.x = 20;
        _informationButton.y = -22;

        _informationBackground = new Sprite("InformationBackground.png");
        AddChild(_informationBackground);
        _informationBackground.scale = 1.3f;
        _informationBackground.x = game.width / 2 - _informationBackground.width / 2;
        _informationBackground.y = game.height / 2 - _informationBackground.height / 2;
        _informationBackground.visible = false;

        _interactionMenuButton = new Sprite("InteractionMenuButton.png");
        AddChild(_interactionMenuButton);
        _interactionMenuButton.x = game.width - 120;
        _interactionMenuButton.y = 10;

        _cleanIcon = new Sprite("CleanIcon.png");
        AddChild(_cleanIcon);
        _cleanIcon.x = game.width - 150;
        _cleanIcon.y = 80;
        _cleanIcon.visible = false;

        _meatIcon = new Sprite("MeatIcon.png");
        AddChild(_meatIcon);
        _meatIcon.x = game.width - 150;
        _meatIcon.y = 180;
        _meatIcon.visible = false;

        _veggieIcon = new Sprite("VeggieIcon.png");
        AddChild(_veggieIcon);
        _veggieIcon.x = game.width - 150;
        _veggieIcon.y = 180;
        _veggieIcon.visible = false;

        _petIcon = new Sprite("PetIcon.png");
        AddChild(_petIcon);
        _petIcon.x = game.width - 150;
        _petIcon.y = 280;
        _petIcon.visible = false;
        /////////////////

        //Options menu
        _optionsButton = new Sprite("OptionsButton.png");
        AddChild(_optionsButton);
        _optionsButton.x = game.width - 120;
        _optionsButton.y = 10;

        _optionsBackground = new OptionsMenu();
        AddChild(_optionsBackground);
        _optionsBackground.x = game.width / 2 - _optionsBackground.width / 2;
        _optionsBackground.y = game.height / 2 - _optionsBackground.height / 2;
        _optionsBackground.visible = false;

        _continueButton = new Sprite("ContinueButton.png");
        AddChild(_continueButton);
        _continueButton.x = game.width / 2 - _continueButton.width / 2 + 150;
        _continueButton.y = game.height / 2 - _continueButton.height / 2 + 340;
        _continueButton.visible = false;

        _exitButton = new Sprite("ExitButton.png");
        AddChild(_exitButton);
        _exitButton.x = game.width / 2 - _exitButton.width / 2 - 150;
        _exitButton.y = game.height / 2 - _exitButton.height / 2 + 340;
        _exitButton.visible = false;
        ///////////////

        _fontColor = Brushes.White;
        _font = new Font("Arial", 30);

        //////////
        /////Tips
        AddChild(lionTip1);
        AddChild(lionTip2);
    }

    private void Update()
    {
        graphics.Clear(Color.Empty);
        CheckForAnimalSwitching();
        CheckForOptionsRequest();
        ShowInteractionMenu();
        ShowInformationMenu();
        InteractWithAnimal();
    }

    private void CheckForAnimalSwitching()
    {
        if (residenceActive)
        {
            _lowerButton.visible = true;
            _rightButton.visible = true;
            _leftButton.visible = true;

            _interactionMenuButton.visible = true;

            _informationButton.visible = true;

            if (_lowerButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    clickedBack = true;
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
            _cleanIcon.visible = false;
            _petIcon.visible = false;
            _meatIcon.visible = false;
            _veggieIcon.visible = false;

            _informationButton.visible = false;
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
                _exitButton.visible = true;
                showAnimalStats = true;
            }
            else if (!clickedOptions)
            {
                _optionsBackground.visible = false;
                _continueButton.visible = false;
                _exitButton.visible = false;
            }

            if (_continueButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
            {
                clickedOptions = false;
                showAnimalStats = false;
            }

            if (_optionsBackground.visible)
            {
                if (_exitButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
                {
                    MyGame.main.Destroy();
                }
            }
        }

        if (!environmentActive)
        {
            _optionsButton.visible = false;
        }
    }

    private void ShowInteractionMenu()
    {
        if (residenceActive)
        {
            if (showInteractionMenu)
            {
                if (carnivore)
                {
                    _meatIcon.visible = true;
                    _veggieIcon.visible = false;
                    herbivore = false;
                }

                if (herbivore)
                {
                    _veggieIcon.visible = true;
                    _meatIcon.visible = false;
                    carnivore = false;
                }

                _cleanIcon.visible = true;
                _petIcon.visible = true;
            }
            else if (!showInteractionMenu)
            {
                _cleanIcon.visible = false;
                _meatIcon.visible = false;
                _veggieIcon.visible = false;
                _petIcon.visible = false;
            }

            if (_interactionMenuButton.HitTestPoint(Input.mouseX, Input.mouseY)
                && Input.GetMouseButtonDown(0) && !showInteractionMenu)
            {
                showInteractionMenu = true;
            }

            if (!_interactionMenuButton.HitTestPoint(Input.mouseX, Input.mouseY)
                && Input.GetMouseButtonDown(0) && showInformationMenu)
            {
                showInteractionMenu = false;
            }
        }
    }

    private void ShowInformationMenu()
    {
        if (_informationButton.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            showInformationMenu = true;
        }

        if (!(_informationButton.HitTestPoint(Input.mouseX, Input.mouseY)
            || _informationBackground.HitTestPoint(Input.mouseX, Input.mouseY))
            && Input.GetMouseButtonDown(0) && showInformationMenu)
        {
            showInformationMenu = false;
        }

        if (showInformationMenu)
        {
            _informationBackground.visible = true;
        }

        if (!showInformationMenu)
        {
            _informationBackground.visible = false;
        }

        if (showInformationMenu)
        {
            if (lionActive && lionLevel == 0)
            {
                lionTip1.graphics.DrawString("Lions are cat-like animals", _font, _fontColor, game.width / 2 - 225, game.height / 2);
            }

            if (lionActive && lionLevel == 1)
            {
                lionTip1.graphics.Clear(Color.Transparent);
                lionTip2.graphics.DrawString("Lions are carnivores", _font, _fontColor, game.width / 2 - 200, game.height / 2);
            }

            if (lionActive && lionLevel == 2)
            {

            }
        }
        else
        {
            lionTip1.graphics.Clear(Color.Transparent);
            lionTip2.graphics.Clear(Color.Transparent);
        }
    }

    private void InteractWithAnimal()
    {
        if (_cleanIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            cleaning = true;
        }

        if ((_meatIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0)) ||
            (_veggieIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0)))
        {
            feeding = true;
        }

        if (_petIcon.HitTestPoint(Input.mouseX, Input.mouseY) && Input.GetMouseButtonDown(0))
        {
            petting = true;
        }
    }
}