# Abertay Volleyball Utility Tool
This tool was made to help track weekly training session attendance in order to fill out the University Activity Tracker. Since that was working well, I added features that made my life easier as the recreational captain who coached/hosted each training session. I hope this tool can be passed down to the next generations of committe members to make their life easier too.

## An overview of what this tool does:<br>
* Players who are present sign in by typing their name
    * Players are also prompted to select one of two tickboxes to indicate whether they are a team or non team player 
    * This information is stored temporarily in the working directory
    <br>
* Once the session is over, an email is sent is to the Abertay Volleyball email inbox as well as the current club Secretary for redundancy
    * Once an email is sent, the list of present players is deleted to prevent permanent storage and to ready the tool for next training session
    <br>
* In another form, teams are generated based on the number of players present (24 players == 4 teams)
    * Excess players are divided equally between the number of teams (if there are 14 players, 2 teams of 7 will be generated)
    * Players are distributed according to the skill level they selected (team or non team)
    * Each generated team is initially allocated 2 team players
    * The non team players are distributed to every team
    * The remaining team players distributed last
    <br>
* (WORK IN PROGRESS) Another form generates the match pairing order
<br>
# Prerequisites

# Download/Setup Instructions

These instructions _**should**_ be included in the Committe Handover Book for the next generation, but they are also here for your benefit. 

## Step 1

* To get started, click on [this link here](https://github.com/rleviathan5/Volleyball-Club-Utility/releases) (https://github.com/rleviathan5/Volleyball-Club-Utility/releases)

* This will take you to the releases page. You should see a page very similar to the one below.

<p align="center"><img src="Images/Volleyball setup.png" width="500"></p>

*  At the time of writing, version 3 is still being developed and isn't shown in the screenshot above. Unless I have been hit by a bus, you will see "v3" as the latest release when you click on the link

*  In the most recent release (most likely "v3" or above for you), click the ZIP file link as seen below. This will download the ZIP file

* Once you have the file downloaded, extract it to somewhere on your computer/laptop that provides easy access (my recommendation is your Desktop)

* If you see the 'exe' file below, then you are on the right track.

## Step 2
