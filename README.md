TheOpenLauncher
===============

A modern open source Windows installer and updater, written in C# for .NET 3.5 and higher.
This project uses the MIT license, so you are free to use this in your personal/commercial projects.
A reference is appreciated, but not required.

<img src="https://dl.dropboxusercontent.com/u/35774053/Markdowntest/example1.png" alt="Version publisher new project dialog" width="275px"/>
<img src="https://dl.dropboxusercontent.com/u/35774053/Markdowntest/example2.png" alt="Version publisher new project dialog" />
<img src="https://dl.dropboxusercontent.com/u/35774053/Markdowntest/example3.png" alt="Version publisher new project dialog" width="275px"/>

##Getting started##
To get started with TheOpenLauncher, you will first need to customize and build the updater for your project.
After that, you can start publishing updates with the Version Publisher.

###Creating the updater###
To create the updater, you will first need to get a copy of the source code. Simply (optionally fork) and clone this repository to a local folder and open the enclosed project in Visual Studio. The project was created in Visual Studio 2013 Express but should also work in Visual Studio 2012.


<table style="width:100%"><tbody><tr><td class="block" style="padding-right: 20px; vertical-align: text-top;">
The VS solution should look something like this. To set up the the launcher for your project, take a look in the LauncherSettings.cs file. This file contains branding options such as the target application name, your company or organization name and website URLs. <br>
Technical settings such as target executable, update hosts, application ID and more are also found in this file. 
<br>Make sure to remember the AppID you choose, it should be unique (a GUID is allowed), as this will be required to set up the version publisher.
<br><br>
By default the launcher contains a English.txt locale file under the Locale folder. Should you wish to add another language, simply create another .txt file in the Locale folder in the same format as the English default. The language will automatically be added to the list of available installer languages.
<br>More detailed customizations are also possible since all the updater source code is in the solution.
<br><br>When you have finished customizing the installer, build it and obtain a copy from the Release folder.
</td><td>
<img src="https://dl.dropboxusercontent.com/u/35774053/Markdowntest/img1.png" alt="Project page"/>
</td></tr></tbody></table><br>

###Publishing your first version###
After you have created the updater you will need to set up one or more update hosts by publishing an initial version. To do this, run the Version Publisher included in the VS solution. 


<table width="100%"><tbody><tr><td class="block" style="padding-right: 20px; vertical-align: text-top;">
<img src="https://dl.dropboxusercontent.com/u/35774053/Markdowntest/img2.png" alt="Version publisher new project dialog" width="300px"/>
</td><td style="width:50%; padding-right: 20px; vertical-align: text-top;">
Start the Version Publisher and click the "New project" button on the main page.<br>
Choose a project name, enter the appid you chose for the updater, and select a project folder. The project folder is where you will keep the most recent version of the application. The publisher will automatically generate updates from the difference between the last version and the current state of the files in this folder. <br>
Select a publishing channel and press Create.
</td></tr></tbody></table><br>

<table width="100%"><tbody><tr><td style="width:50%; padding-right: 20px; vertical-align: text-top;">
Add the files of the initial version of your program to the project folder. Note that you need to include the updater/installer in this folder to add it to the installation. (for uninstallation/updating purposes)<br><br>
When your version is ready, press the "Create new update" button. A list of files that will be included in the version should be shown on the right. Press the "Create update from changes..." button to go to the next step. Add a summary and some notes and finally click "Publish update" to publish your first update. Make sure the update is available on the update hosts specified in the updater.
</td><td class="block" style="padding-right: 20px; vertical-align: text-top;">
<img src="https://dl.dropboxusercontent.com/u/35774053/Markdowntest/img3.png" alt="Update file changes" width="300px"/>
</td></tr></tbody></table><br>

###Done!###
You are now ready to distribute your installer! <br>
Releasing your next update is now just a matter of modifying the files in the project folder and publishing it in the Version Publisher.
