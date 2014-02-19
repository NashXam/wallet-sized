wallet-sized
============

A Nashville Xamarin User Grouop coding dojo excercise

Write a Xamarin app named "Wallet Sized". The app has ten tiles each of which can store a handy bit of information (a note, a URL, or a picture).

How to contribute
-----------------
Contribute your solution by adding a folder named {your twitter handle} such as:

````
/bryan_hunter
````

Create your solution below your folder. Push as you go. Enjoy!


Specs
-----

````
GIVEN I have just installed the application
WHEN I open the application
THEN I will be presented the "Main Screen" with 10 empty panels

GIVEN I have a bit of info that I like to refer to often
WHEN I open the application and click on an empty panel
THEN I am presented with a "new item" screen to enter a url, a picture, or a note, anda "Save" button.
   
GIVEN I have a web address that I frequently like to show people
    AND I am on the "new item" screen
WHEN I enter the URL to the page that hosts a video of my animatronic typing monkey 
    AND I click save
THEN I will be returned to the "Main Screen" 
    AND the formerly empty tile will now display the "Monkey Business" the title of the URL's web page  
    
GIVEN I tell a story at a bar about building an animatronic typing monkey
    AND people say "Dude! I'd love to see that!"
WHEN I open the wallet-sized app and click on the "Monkey Business" panel
THEN the application will launch the web page where my Typing Monkey video is hosted
````
