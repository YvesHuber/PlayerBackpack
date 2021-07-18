# playerbackpack asset
 
## about the project
 
this is a Unity game asset for a 3d First person game
simply steal the code from here or the asset store (Not yet)
and you are done.<br>
after the import you can edit all scripts or add new ones
With a right click can you make new game object like: <br>
 
## Controls
WASD to move <br>
Space to jump <br>
C to crawl <br>
Tab to open inventory <br>
E to open crafting stations <br>
Left Click to hit breakables and enemies <br>
 
# For the Developers
 
### item
every item can be:<br>
material to craft <br>
equipable to increase stats while worn<br>
consumable to consume stats permanently <br>
Not all parameters have to be set when creating an item is should be enough to just set the ones you need / want<br>
more parameters can be added the item scriptableobject and used in your own scripts<br>
#### add item to asset
to add a item to a gameobject so you can collect it with e<br>
give the item the tag item add the itemvalue script add the item to the script<br>
you need to add the colliders, models and materials here but you can do it later <br>
 
### enemy
An enemy is of course an enemy <br>
every enemy has a array of items it can drop <br>
the array is build out of enemy drop objects they have a prefab and a drop chance<br>
there is no ai in the enemy and it is purely for dropping items on kill<br>
#### add enemy to asset
create gameobject give it the enemy tag add the enemy script <br>
add the enemy object you created to the script <br>
you need to add the colliders, models and materials here but you can do it later <br>
 
### crafting stations
A crafting station is able to craft recipes that have the same crafting station<br>
it has a name and a array of recipies<br>
you can add an unlimited amount of recipes to each station<br>
#### add a new crafting station
create new craftingstation object add the name and recipes you want <br>
create game object add the crafting tag <br>
add the crafting script and deactivate the script <br>
in the Script add the Ui from Player/Playercollider/Cameraposition/Camera/UI/Crafting <br>
submit = Button <br>
crafting slots = Crafting 1 - 4 <br>
Output Slot = output <br>
Inventory = Inventory just click on the circle and select the first one it is the inventory from the player  <br>
you need to add the colliders, models and materials here but you can do it later <br>
 
### crafting recipes
A crafting recipe is a recipe with an array of items and a output<br>
its a very simple class you can add everything in it but you cant get a specific amount of an output is allways one<br>
 
### breakables
A breakable is a object that when hit with the right Weapon will drop items<br>
the item or items are simply added to the inventory when the breakable is hit with the right tool and it is ready to be broken<br>
#### add a new breakable
create a breakable object and add your parameters + brekabledropobject <br>
create a gameobject add the breakable tag <br>
add the breakable script <br>
add your breakable object <br>
you need to add the colliders, models and materials here but you can do it later <br>

### inventory
You can move the items between the slots but you can't unstack them<br>
the maxstacksize controls the max amount of the item<br>
armor will be equipped on a click and can be equipped by click <br>


# are you still stuck?
message me per Email (cpt.rino@gmail.com)
