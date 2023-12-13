# PostWarApocalypse-Final-Project
Link to Download the full project from Google Drive: 
------------------------------------------------------------------------------Step 2---------------------------------------------------------------------------------------------------

Create a Sci Fi city using Unity's gameobject Terrain and packages from Unity's AssetStore. From the Asset Store, we imported these 4 packages:

Buildings: https://assetstore.unity.com/packages/3d/environments/sci-fi/lowpoly-sci-fi-buildings-set-66885

Streets: https://assetstore.unity.com/packages/3d/environments/urban/low-poly-street-pack-67475

SpaceShips: https://assetstore.unity.com/packages/3d/vehicles/space/low-poly-spaceships-set-209758

Cars: https://assetstore.unity.com/packages/3d/environments/sci-fi/warzone-vehicle-pack-57826

Final Product: 

<img width="991" alt="Screenshot 2023-12-12 at 7 26 58 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/321ca654-6f23-46a8-92f9-1bb80175c68c">
------------------------------------------------------------------------------Step 2---------------------------------------------------------------------------------------------------

Create Input Map for flying movement

First we picked a prefab from the SpaceShips assets and named it Shooter. This spaceship is our player.
Inside the Shooter we will add a Player Input component and create a new Input Actions Map.
We will add 6 actions: Move, Rotate, Thrust, ReverseThrust, Fire, and Fire1.
We name the new Input Action Maps as SpaceShipMov. In this case we decided to use a DualSense Controller(Gamepad) since it requires more actions and therefore more button configurations and a controller typically feels more natural.

![Screenshot 2023-12-11 at 12 00 11 AM](https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/ed4163fc-e2e9-4795-a17b-ef4d799a9e2d)

The Move and Rotate will by Action Type "Value" and Control Type "Stick" since we will use the controler's joystick to execute these actions. The Thrust and ReverseThrust actions will also be of Action Type "Value" but will be Control Type "Any". Lastly the Fire actions will be of Action Type "Button" since it's a trigger action. The Fire actions are defined in a separate script so that the scripts don't seem overwhelmed.
Using Scripts we will give the controller's buttons certain actions. You will find the Scripts in the repository. Each code is documented and commented for better understanding. 
Scripts: SpaceShipController and SpaceShipFire.

Movement Demo: https://drive.google.com/file/d/107JOr5QnSGGcdk9Jpr8te2GqrauwSG-F/view?usp=drive_link

------------------------------------------------------------------------------Step 3--------------------------------------------------------------------------------------------------- Creating Shooter(Player)

From the SpaceShip packages imported, we selected a ship prefab and create a prefab Variant called 'Shooter'. This Shooter should have a Player Input component sp we can move the player with a controller. We'll use the Input Action Map defined in Step 2. This is the components your player should have:

<img width="396" alt="Screenshot 2023-12-12 at 8 27 02 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/f9bf3c52-8572-4742-93fd-d0e7f73239e1">

<img width="401" alt="Screenshot 2023-12-12 at 8 27 18 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/cbfa2d93-a1e3-4256-a17f-eb9c27e6990c">


------------------------------------------------------------------------------Step 4---------------------------------------------------------------------------------------------------
Bullet Prefab

Our bullet in this case is a sphere with a red material we created. The bullet is an essential part of the game since it is a key component for every other aspect of the game. The bullet will have a script that destroys the bullet when it hits another object. It also has a script that manages how much damage it will substract from an object that has Life.

Bullet: 

<img width="1092" alt="Screenshot 2023-12-12 at 8 12 15 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/7870e06a-1cc6-4952-bfeb-ec6f4c541b17">

Shooting the bullet: The bullet should have a point of instantiation, in this case create an empty object 'ShootPoint' and place where you want the bullet to instantiate when firing. I will place 2 ShootPoints, one in each wing of my shooter.

<img width="803" alt="Screenshot 2023-12-12 at 8 16 10 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/56434b50-7fa4-4297-a04f-58f2d60084b4">

Shooting Demo:

https://drive.google.com/file/d/1YaIpLni2lbAGyPuyxlPnaO5AZxa5DmBO/view?usp=drive_link

------------------------------------------------------------------------------Step 5---------------------------------------------------------------------------------------------------
Managing Enemies

For this we used a SpaceShip prefab from the packages imported and created a Prefab Variant called Enemy Variant. Create an empty object called EnemyShipManager and attach the EnemyManager Script. Add the following components and scripts to the Enemy. As usual, read the scripts' comments for better understanding.

EnemyShipManager:

<img width="392" alt="Screenshot 2023-12-12 at 7 57 51 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/ec9c9861-e0bb-47da-a827-4d5a8a8bb5e1">

Enemy Variant:

<img width="1438" alt="Screenshot 2023-12-12 at 7 46 15 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/7fa34c01-5379-4467-a13d-1d680af8d1ec">

For now, ignore the AI in the Enemy Prefab, this will be explained later on.

------------------------------------------------------------------------------Step 6---------------------------------------------------------------------------------------------------
Enemy States and AI Navigation

To give our enemy a sense of intelligence we will use a package from Unity called AI Navigation. 

<img width="800" alt="Screenshot 2023-12-11 at 9 56 29 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/c38c6570-072d-4ad3-a51c-0756b7f3275d">

Description: Open Package Manager->Select Packages:Unity Registry->Install the 'AI Navigation' Package.

Next, go to your Enemy prefab and add the component 'NavMeshAgent'.

<img width="1440" alt="Screenshot 2023-12-11 at 10 05 50 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/1b3ca1d6-1cbd-4519-83b4-2553c769a486">

Enemy AI:
To really simulate Enemy AI, create an empty object called AI. Align the AI object with the front of the prefab and place the empty object inside the prefab's hierarchy. And add the scripts shown in the photo to the AI empty object. Make reference to the scripts.

<img width="1439" alt="Screenshot 2023-12-12 at 7 51 30 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/48275069-5878-44ac-811f-e0b179eba39f">

As you can see in the Sight Script there is an Obstacle Layer defined as player. THis is done by creating a new Layer and assigning it to your player.

<img width="393" alt="Screenshot 2023-12-12 at 7 54 02 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/86aa147d-8a9b-4efe-b189-081b0fbc71c9">

Now we will create a Plane and place it on top of our Terrain and add a NavMeshSurface component to the Plane. The NavMeshSurface scans the Plane and creates a blueprint of the areas where the Enemy can move without colliding with other objects. The NavMeshSurface is not meant for flying objects. That is why we place a Plane over the Terrain so it seems that the enemies are flying. To make the plane seem invisible we have to remove the Mesh Renderer Component from the plane.

<img width="1437" alt="Screenshot 2023-12-11 at 10 17 26 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/0b57f4b7-c8a1-4625-a206-bb209fe3fdd6">

<img width="1440" alt="Screenshot 2023-12-11 at 10 19 57 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/9dbdca70-1588-4496-98f4-8a75ce5c11d8">

In the NavMeshSurface Component in the Plane, press Bake so it makes the blueprint of the navigational areas. Turn on the Gizmo, in the upper right corner, so you can visualize the NavMeshSurface. The area should appear blue. Lastly diselect the Mesh Renderer from the plane so it seems invisible, as well as its collider.

Enemy States
Our enemy will have 3 states:
1. Patrol - roam through the city when a player is not near.
   - Implementation: For the roaming we will create various empty GameObjects,which will act as wayPoints, and place the along the plane. The wayPoints will be added to a list and          with a script we'll make the player navigate through the wayPoints until it detects a player.
   - Creating WayPoints and Adding them to a list: Create multiple empty objects and scatter them across the city. To add them in a list you can do it manually in the Unity Editor or        optimize the process and do it via code. In this case since there aren't many waypoints, we opted to do it manually.
  
     <img width="1083" alt="Screenshot 2023-12-12 at 8 03 54 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/a31cd335-3297-4b00-a6e9-72e0567d6656">

     
3. ChasePlayer - chase the player when the player is within a given range.
   - Implementation: When the Enemy detects the player within a predetermined range it will chase the player until it is close enough to attack or until the player is out of range and
     the Enemy will go back to the Patrol state.
    
5. AttackPlayer - attack the player when the player is within the attacking range.
   - Implementation: When an Enemy is chasing a player and comes close enough to the player it will beging to shoot at it until the player's life is zero or out of range.
     
For this part make reference to the EnemyFSM and Sight scripts for better understanding.

EnemyState Demo: https://drive.google.com/file/d/107JOr5QnSGGcdk9Jpr8te2GqrauwSG-F/view?usp=drive_link

------------------------------------------------------------------------------Step 7---------------------------------------------------------------------------------------------------
Instantiating a Final Boss when all Enemies have been defeated
To instantiate a FinalBoss, we created a BossManager that manages a List Bosses. The FinalBoss is added to the list when it is instiated. Even though it is only one boos, later on you will see why we created a list for one element. Of course you'll need a Boss Prefab and attach a Life script. And add a FinalBoss script so that the BossManager can add and destroy it from the list.

Boss Prefab:

<img width="1098" alt="Screenshot 2023-12-12 at 8 38 26 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/02b9df79-47f0-4130-a1ae-651288ee5af2">

BossManager:

<img width="207" alt="Screenshot 2023-12-12 at 8 40 27 PM" src="https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/696f0ff4-a5a8-41d7-bca2-7cb72c43412f">



