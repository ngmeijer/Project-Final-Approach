using System;
using GXPEngine;

public class SoundManager : GameObject
{
    private Sound backgroundMusic;

    public Sound cleanSound;
    public Sound feedSound;
    public Sound dropdownMenuSound;

    public SoundManager()
    {
        backgroundMusic = new Sound("BackgroundMusic.mp3", true, false);
        backgroundMusic.Play(false, 0, 0f);

        cleanSound = new Sound("clean.wav", false, false);
        feedSound = new Sound("Feeding.wav", false, false);
        dropdownMenuSound = new Sound("Feeding.mp3", false, false);
    }
}