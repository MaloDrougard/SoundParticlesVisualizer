## Lüterne show application

**See the application in use: https://www.youtube.com/watch?v=E549XDdgT9A**

This application is part of the light show for the surf rock music band Lüterne.
Basically, the application analyses the audio stream given by a microphone and produce a video stream.
The produced video stream can be control by some parameters.
So the application needs two screens, one for the controlled panel and one for the video output.


![soundVisualizerImg](https://github.com/MaloDrougard/SoundParticlesVisualizer/blob/master/Doc/Img/soundVisulatizer-videoOutput.png)
Video output example

![soundVisualizerImg](https://github.com/MaloDrougard/SoundParticlesVisualizer/blob/master/Doc/Img/soundVisualizer-controls.png)
Control panel screenshot

## Details

The application uses the system particles of Unity to produce the video.
There are 8 systems of particles (aka "suns").
Each suns is connected to some range of frequencies.
The particles react to the magnitude of the frequencies.
For example, the size of the particles can change depending on the magnitude of its connected frequencies.
There are three main parameters of the particles system that are connected to the frequencies:
the velocity, the size and the emission.
The user can set the for each of these parameters (size, velocity, emission) if they
are currently connected to the frequencies or not ("use static .." checkbox in control panel).
If not, the user can set manually a value for this parameter. This allows
the user to change the effect during the live and to adapt the light show to the public and the music.
During the lüterne show, we also use bouncing mirrors that reflect the video stream to create an organic effect.