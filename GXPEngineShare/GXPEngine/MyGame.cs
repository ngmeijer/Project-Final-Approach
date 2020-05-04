using System;
using GXPEngine;

public class MyGame : Game
{
	private SceneManager _sceneManager;

	private Menu _menu;

	public MyGame() : base(800, 600, false)
	{
		_sceneManager = new SceneManager(_menu);
		AddChild(_sceneManager);
	}

	static void Main()
	{
		new MyGame().Start();
	}
}