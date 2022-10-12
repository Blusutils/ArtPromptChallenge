# Art Prompt Challenge
Website, where you can roll virtual dices to get inspiration for "creating whatever you want (if you want too much)". Original idea by [Polyfjord](https://youtube.com/c/Polyfjord)[^1]. 

## How about to create...
Surely you've had a situation where you had no ideas for an artwork. 
Or you wanted to have fun by challenging yourself to create something on a random theme. 
And there it is, the solution!

Want to create something like ***wild** **aquamarine** colored **toy** in **ancient** world, created with **pixelated/voxelated** art style ruleset*? 
No problem! 
Roll the virtual dice and get a random[^2] artwork prompt, not forgetting to try to implement it.

By default you can generate place, what you'll draw or render, accent color, art style and etc.

You're also able to create your own generator and share it with others.

## How to use

Just open [artpromptchallenge.net](https://artpromptchallenge.net) in browser that supports JS and WebGL.

Click on "Generate" button and after couple of seconds you'll get your prompt.

If you want to share result of your artwork, you need to create free account[^5].

Account also required if you want to create own prompt generator.

`Art Prompt Challenge` website support OAuth2 integrations with YouTube (Google), Discord, Bēhance, Vimeo, Imgur.

## Screenshots
> Website look and some artworks

![Main page]()

![Dice roll]()

![Final prompt string]()

![Gallery 1]()

![Gallery 2]()


## Credits
* Website back-end, front-end base and some artworks[^3]: [EgorBron](https://github.com/EgorBron) 
* Original idea: [Polyfjord](https://youtube.com/c/Polyfjord)[^1]
* 3rd-party libraries and software
  * [ASP.NET Core 6.0](https://github.com/dotnet/aspnetcore)
  * [Three.js (latest)](https://github.com/mrdoob/three.js/)
  * [jQuery (latest)](https://github.com/jquery/jquery)
  * [Bootstrap (latest)](https://github.com/twbs/bootstrap)
* Any other cool things: [contributors](https://github.com/Blusutils/ArtPromptChallenge/graphs/contributors)[^4]


[^1]: `Art Prompt Challenge` is not original idea of this repo creator(s)/maintainer(s). That belongs to [Polyfjord](https://youtube.com/c/Polyfjord) (subscribe to his YouTube channel, he creates really cool videos about Blender).
[^2]: Website uses built-in .NET random function, because work with [Random.org](https://random.org) API (to use truly random) withount violations of API guidelines is unreal. 
[^3]: Standard website images and 3D models are under [CC BY 4.0 license](https://creativecommons.org/licenses/by/4.0/). Other files like sources is under [GNU GPL v3.0](./LICENSE) or another compatable license. Data created by users is under licenses that applied to it by themself (mostly [Creative Commons licenses](https://creativecommons.org/licenses/)). If you think your copyright has been violated, message [EgorBron](https://github.com/EgorBron) in Telegram/Discord via the links in his profile or on E-mail (egorbron@inbox.ru) (English or Russian only).
[^4]: If you want to contribute, read [this](./CONTRIBUTING.md). 
[^5]: If you want to know how this website manipulates with your data, read [Privacy policy](https://artpromptchallenge.net/privacy). Also you can browse source code, if you understand this and you are not here for just read this file.
 
