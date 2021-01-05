# Welcome to GameLibra!

Hi! This is Markdown file for project **GameLibra**.


# Project Description

> **GameLibra** is my web application, built on .Net MVC. For regular users, this app is for creating their own ***Libraries***  of games. 
> That means, project has some library of games, and game related data stored in database. Then, registered and authorised users can browse trough the library of games and add that game into existing library. 
> Thus creating a personal **Collection** of games, where through IsThereAnyDeal, any applicable offers may be shown.
> Currently works with eu region only

# Starting the Project

To start the application, you should have Microsoft Visual Studio 2019, and add following NuGet packages to work with this project properly:
 1. Bootstrap v. 4.5.*
 2. Entity Framework v. 6.4.*
 3. JQuery v. 3.5.*
 4. jQuery.UI.Combined v. 1.12.1
 5. jQuery.Validation v. 1.19.2
 6. jQuery.Validation.Globalize v. 1.1.0
 7. Microsoft.AspNet.Identity.Owin v. 2.2.3
 8. Microsoft.AspNet.Mvc v. 5.2.7
 9. Microsoft.AspNet.Razor v. 3.2.7
 10. MSTest.TestAdapter v. 1.2.0
 11. MSTest.TestFramework v 1.2.0
 12. IsThereAnyDealAPI.

Some of the given items from the list can also be categorized as used tech.

# About Structure, Simplified
Like any other MVC, I have Models, Views and Controllers. For every created model I have Controllers, that respond for interactions between users and models.
By providing connection to Models for users, Controllers uses Views.
To load most of the views, loading templates to **_Layout.cshtml** is used is used. 
> And thats basically it!

##### ~~Screenshots From Project~~ [_Low probability to being added_]

# Some Sources
[Readme Markdowns](https://docs.github.com/en/free-pro-team@latest/github/writing-on-github/basic-writing-and-formatting-syntax)

["How to write a good readme"](https://medium.com/@meakaakka/a-beginners-guide-to-writing-a-kickass-readme-7ac01da88ab3)

[IsThereAnyDeal API](https://itad.docs.apiary.io/#)
["Kingdom" game, source of most background images](https://www.kingdomthegame.com)

[My Github](https://docs.github.com/Farad2020)

#### Project was based on following task

Collection tracker (web app). Build a tool to keep track of something you collect.


#### Note for devs that will be trying out this project. 
In GameLibra folder, web.confing file in "<system.web>" don't forget to turn "Off" "<customErrors mode="On">" to get more appropriate error pages.


![Snapshot_1](https://github.com/Farad2020/GameLibra/blob/main/bonusDocs/Opera%20Snapshot.png)
![Snapshot_2](https://github.com/Farad2020/GameLibra/blob/main/bonusDocs/Opera%20Snapshot_2.png)
![Snapshot_3](https://github.com/Farad2020/GameLibra/blob/main/bonusDocs/Opera%20Snapshot_3.png)

