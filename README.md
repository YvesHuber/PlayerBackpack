# PlayerBackpack Asset

## About the Project

This is a Unity Game Asset for a 3D First Person Game
Simply steal the code from here or the Asset store (Not yet)
and you are Done.<br>
After the Inport you can edit all Scripts or add new ones
With a right Click can you make new Game Object like: <br>

### Item
Every Item can be:<br>
Material to Craft <br>
Consumable to increase stats temporary <br>
Equipable to increase stats while worn<br>
Not all Parameters have to be set when creating an Item is should be enough to just set the ones you need / want<br>

### Enemy
An Enemy is of course an Enemy <br>
Every Enemy has a Array of Items it can Drop <br>
Each Array has a Defined Rarity <br>
There is no AI in the Enemy and it is puerly for Dropping items on kill<br>

### Craftingstations
A Crafting Station is Able to craft recepies that have the same Craftingstation<br>
It has a name and a array of recipies<br>

### Craftingrecepies
A Crafting Recepie is a Recepie with the following Data <br>
Crafting Station as String and Items as Array <br>
if both is true you are able to craft the definded Item <br>

### Breakables
A Breakable is a Object that when hit with the right Weapon will Drop Items<br>
You can Add one Item to the Breakable Object and it will drop that prefab when it is broken<br>
The Breakable will have a Timer after the timer if the Object is Broken it will be repaired or just reappear<br>

### Inventory
The Inventory can be pulled up with I and is in its early stages of design<br>
The whole Item system is for low numbers so 7 Wood would be a lot<br>
You can change this by adding items with a big MaxStackSize and StackSize<br>
You can move the items between the Slots but you cant unstack them<br>

