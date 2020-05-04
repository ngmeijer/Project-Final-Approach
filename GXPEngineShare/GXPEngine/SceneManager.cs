using System;
using GXPEngine;

public class SceneManager : GameObject
{
    public Menu _menu { get; private set; }

    private Environment _environment;

    private HUD _gameHUD;

    public Residence _residencePenguins;

    public SceneManager(Menu menuScript)
    {
        _menu = new Menu();
        AddChild(_menu);

        _environment = new Environment();
        AddChild(_environment);
        _environment.visible = false;

        _residencePenguins = new Residence();
        AddChild(_residencePenguins);
        _residencePenguins.visible = false;

        _gameHUD = new HUD();
        AddChild(_gameHUD);
        _gameHUD.visible = false;

        _residencePenguins.x = game.width / 2 - _residencePenguins.width / 2;
        _residencePenguins.y = game.height / 2 - _residencePenguins.height / 2;
    }

    private void Update()
    {
        CheckGameStart();
        CheckResidenceClick();
        CheckMainArea();
        CheckGameReset();
    }

    private void CheckGameStart()
    {
        if (_menu.levelStarted)
        {
            _environment.visible = true;

            _gameHUD.visible = true;

            _menu.visible = false;

            _menu.levelStarted = false;
        }
    }

    private void CheckGameReset()
    {
        if (_environment != null)
        {
            if (_gameHUD.backToMainMenu)
            {
                _menu.visible = true;
                _environment.visible = false;
                _gameHUD.visible = false;
            }
        }
    }

    private void CheckResidenceClick()
    {
        if (_environment != null)
        {
            if (_environment.clickedPenguins)
            {
                _environment.visible = false;
                _residencePenguins.visible = true;
                _gameHUD.activeResidence = true;
            }
        }
    }

    private void CheckMainArea()
    {
        if (_gameHUD.mainAreaActive)
        {
            _environment.visible = true;
        }
    }
}
