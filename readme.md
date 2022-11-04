# todayBing Wallpaper for Linux

**MODIFY `Program.cs`:11 FIRST!!!**

Program is checked to run well in Ubuntu 22.10 with Gnome. 

You may need to configure wallpaper first by following this:

1. Run the application once

2. check if `~/.local/share/backgrounds/todaybing.jpg` exists

3. run in terminal

```bash
gsettings set org.gnome.desktop.background picture-uri-dark 'file://absolute/path/to/todaybing.jpg'
gsettings set org.gnome.desktop.background picture-uri 'file://absolute/path/to/todaybing.jpg'
```

In my env(username spark), i should run 
``$ gsettings set org.gnome.desktop.background picture-uri-dark 'file:///home/spark/.local/share/backgrounds/todaybing.jpg'``
