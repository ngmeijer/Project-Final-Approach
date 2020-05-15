using System;
using GXPEngine;

public class Giraffe : AnimationSprite
{
    public bool feeding { get; set; }
    public bool petting { get; set; }
    public bool cleaning { get; set; }
    private bool idle;

    private int _animationSpeed = 290;
    private int _animationTimer;

    public Giraffe() : base("GiraffeSpritesheet.png", 15, 4)
    {

    }

    private void Update()
    {
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        if (cleaning)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 15 + 0;

            SetFrame(frame);

            if (frame >= 14)
            {
                cleaning = false;
            }
        }

        if (feeding)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 10 + 14;

            SetFrame(frame);

            if (frame >= 22)
            {
                feeding = false;
            }
        }

        if (petting)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 30;
            SetFrame(frame);

            if (frame >= 37)
            {
                petting = false;
            }
        }

        if (idle)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 45;

            SetFrame(frame);
        }

        if (!petting && !cleaning && !feeding)
        {
            idle = true;
            petting = false;
            feeding = false;
            cleaning = false;
        }
        else
        {
            idle = false;
        }
    }
}
