# playerbackpack asset

## about the project

this is a Unity game asset for a 3d First person game
simply steal the code from here or the asset store (Not yet)
and you are done.<br>
after the inport you can edit all scripts or add new ones
With a right click can you make new game object like: <br>

## Controlls
WASD to move <br>
Space to jump <br>
C to crawl <br>
Tab to open invetory <br>
E to open craftingstations <br>
Leftclick to hit breakables and enemies <br>

# For the Developers

### item
every item can be:<br>
material to craft <br>
equipable to increase stats while worn<br>
consumable to consume stats permenantly <br>
Not all parameters have to be set when creating an item is should be enough to just set the ones you need / want<br>
more paramaters can be added the item scirptableobject and used in your own scripts<br>
#### add item to asset
to add a item to a gameobjet so you can collet it with e<br>
give the item the tag item add the itemvalue script add the item to the script<br>

### enemy
An enemy is of course an enemy <br>
every enemy has a array of items it can drop <br>
the array is build out of enemydropobjects they have a prefab and a dropchance<br>
there is no ai in the enemy and it is puerly for dropping items on kill<br>
#### add enemy to asset
create gameobject give it the enemy tag add the enemy script <br>
add the enemyobject you created to the script <br>

### craftingstations
A crafting station is able to craft recepies that have the same craftingstation<br>
it has a name and a array of recipies<br>
you can add an unlimited amount of recepies to each station<br>
#### add a new crafting station 
create new craftingstation object add the name and recepies you want <br>
create game object add the crafting tag <br>
add the crafting script and deactivate the scirpt <br>
in the Script add the Ui from Player/Playercollider/Cameraposition/Camera/UI/Crafting <br>
submit = Button <br>
crafting slots = Crafting 1 - 4 <br>
Outputslot = output <br>
Inventory = Inventory just click on the circle and select the first one <br>

### craftingrecepies
A crafting recepie is a recepie with an array of items and a output<br>
its a very simple class you can add everything in it but you cant get a specific amount of an output is allways one<br>

### breakables
A breakable is a object that when hit with the right Weapon will drop items<br>
the item or items are simply added to the inventory when the breakable is hit with the right tool and it is ready to be broken<br>
#### add a new breakable
create a breakableobject and add your parameters + brekabledropobject <br>
create a gameobject add the breakable tag <br>
add the breakable script <br>
add your breakableobject <br>

### inventory
You can move the items between the slots but you cant unstack them<br>
the maxstacksize controlls the max amount of the item<br>
armor will be equiped on a click and can be unequiped by click <br>
