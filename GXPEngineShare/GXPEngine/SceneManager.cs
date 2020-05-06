using System;
using GXPEngine;

public class SceneManager : GameObject
{
    public Menu _menu { get; private set; }

    public HUD _gameHUD { get; private set; }

    public Environment _environment { get; private set; }

    public Residence _penguinResidence;
    public Residence _zebraResidence;
    public Residence _seaLionResidence;
    public Residence _turtleResidence;
    public Residence _monkeyResidence;
    public Residence _lionResidence;
    public Residence _giraffeResidence;
    public Residence _hippoResidence;

    public bool residenceActive;

    public SceneManager()
    {
        _menu = new Menu();
        AddChild(_menu);

        _gameHUD = new HUD();
        AddChild(_gameHUD);
        _gameHUD.visible = false;

        _environment = new Environment();
        AddChild(_environment);
        _environment.x = 1920;

        //Animal residences
        _penguinResidence = new Residence();
        AddChild(_penguinResidence);
        _penguinResidence.x = 1920;

        _zebraResidence = new Residence();
        AddChild(_zebraResidence);
        _zebraResidence.x = 1920;

        _seaLionResidence = new Residence();
        AddChild(_seaLionResidence);
        _seaLionResidence.x = 1920;

        _turtleResidence = new Residence();
        AddChild(_turtleResidence);
        _turtleResidence.x = 1920;

        _monkeyResidence = new Residence();
        AddChild(_monkeyResidence);
        _monkeyResidence.x = 1920;

        _lionResidence = new Residence();
        AddChild(_lionResidence);
        _lionResidence.x = 1920;

        _giraffeResidence = new Residence();
        AddChild(_giraffeResidence);
        _giraffeResidence.x = 1920;

        _hippoResidence = new Residence();
        AddChild(_hippoResidence);
        _hippoResidence.x = 1920;
        /////////////////////
    }

    private void Update()
    {
        CheckLevelStart();
        CheckResidenceActivity();
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
            _gameHUD.visible = true;
        }

        if (_environment._penguinsActive)
        {
            residenceActive = true;
            _penguinResidence._penguinActive = true;
            _penguinResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._zebraActive)
        {
            residenceActive = true;
            _zebraResidence._zebraActive = true;
            _zebraResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._seaLionActive)
        {
            residenceActive = true;
            _seaLionResidence._seaLionActive = true;
            _seaLionResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._turtleActive)
        {
            residenceActive = true;
            _turtleResidence._turtleActive = true;
            _turtleResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._monkeyActive)
        {
            residenceActive = true;
            _monkeyResidence._monkeyActive = true;
            _monkeyResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._lionActive)
        {
            residenceActive = true;
            _lionResidence._lionActive = true;
            _lionResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._giraffeActive)
        {
            residenceActive = true;
            _giraffeResidence._giraffeActive = true;
            _giraffeResidence.x = 0;
            _environment.x = 1920;
        }

        if (_environment._hippoActive)
        {
            residenceActive = true;
            _hippoResidence._hippoActive = true;
            _hippoResidence.x = 0;
            _environment.x = 1920;
        }

        //////////////////////////////////////
        ///

        if (_gameHUD.clickedBack)
        {
            _environment._penguinsActive = false;
            _environment._zebraActive = false;
            _environment._seaLionActive = false;
            _environment._turtleActive = false;
            _environment._monkeyActive = false;
            _environment._lionActive = false;
            _environment._giraffeActive = false;
            _environment._hippoActive = false;

            _gameHUD.clickedBack = false;
            
            _penguinResidence.x = 1920;
            _zebraResidence.x = 1920;
            _seaLionResidence.x = 1920;
            _turtleResidence.x = 1920;
            _monkeyResidence.x = 1920;
            _lionResidence.x = 1920;
            _giraffeResidence.x = 1920;
            _hippoResidence.x = 1920;
            _environment.x = 0;
        }

        if (_gameHUD.clickedLeft)
        {
            if (_environment._penguinsActive)
            {

            }

            if (_environment._zebraActive)
            {

            }

            if (_environment._seaLionActive)
            {

            }

            if (_environment._turtleActive)
            {

            }

            if (_environment._monkeyActive)
            {

            }

            if (_environment._lionActive)
            {

            }

            if (_environment._giraffeActive)
            {

            }

            if (_environment._hippoActive)
            {

            }
        }

        if (_gameHUD.clickedRight)
        {
            if (_environment._penguinsActive)
            {

            }

            if (_environment._zebraActive)
            {

            }

            if (_environment._seaLionActive)
            {

            }

            if (_environment._turtleActive)
            {

            }

            if (_environment._monkeyActive)
            {

            }

            if (_environment._lionActive)
            {

            }

            if (_environment._giraffeActive)
            {

            }

            if (_environment._hippoActive)
            {

            }
        }
    }
}
