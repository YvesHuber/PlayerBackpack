# playerbackpack asset

## about the project

this is a Unity game asset for a 3d First person game
simply steal the code from here or the asset store (Not yet)
and you are done.<br>
after the inport you can edit all scripts or add new ones
With a right click can you make new game object like: <br>

### item
every item can be:<br>
material to craft <br>
equipable to increase stats while worn<br>
Not all parameters have to be set when creating an item is should be enough to just set the ones you need / want<br>
more paramaters can be added the item scirptableobject and used in your own scripts<br>

### enemy
An enemy is of course an enemy <br>
every enemy has a array of items it can drop <br>
the array is build out of prefabs so you can add everything<br>
each array has a defined rarity <br>
the drop chance can be 100%, 50%, 20%, 5% and 1% you can allways add new droprates<br>
there is no ai in the enemy and it is puerly for dropping items on kill<br>

### craftingstations
A crafting station is able to craft recepies that have the same craftingstation<br>
it has a name and a array of recipies<br>
you can add an unlimited amount of recepies to each station<br>
if you want to add a new Station you need to create a new UI set for the crafting script<br>
you need to add the activator to the Itemscanner as well I am working to make the implementation simpler but its not done yet<br>

### craftingrecepies
A crafting recepie is a recepie with an array of items and a output<br>
its a very simple class you can add everything in it but you cant get a specific amount of an output is allways one<br>

### breakables
A breakable is a object that when hit with the right Weapon will drop items<br>
its the same principle as with the enemy it has an array of items this time not prefabs with specific raritys they are the same as with the enemy<br>
the item or items are simply added to the inventory when the breakable is hit with the right tool and it is ready to be broken<br>

### inventory
The inventory can be pulled up with i and is in its early stages of design<br>
You can move the items between the slots but you cant unstack them<br>
the maxstacksize controlls the max amount of the item<br>
hovering over an item will show the name description and value <br>
armor will be equiped on a click<br>
