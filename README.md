# PostWarApocalypse-Final-Project
Link to Download the full project from Google Drive: https://drive.google.com/drive/folders/1dK054Oq7JCrMy4VUd7Ql9B_CfjLUTG4A?usp=sharing

Step 1: Create a Sci Fi city using Unity's gameobject Terrain and packages from Unity's AssetStore. From the Asset Store, we imported these 3 packages:

Buildings: https://assetstore.unity.com/packages/3d/environments/sci-fi/lowpoly-sci-fi-buildings-set-66885

Streets: https://assetstore.unity.com/packages/3d/environments/urban/low-poly-street-pack-67475

SpaceShips: https://assetstore.unity.com/packages/3d/vehicles/space/low-poly-spaceships-set-209758

Cars: https://assetstore.unity.com/packages/3d/environments/sci-fi/warzone-vehicle-pack-57826

Final Product: //City Photo

Step 2: Create Input Map for flying movement
First we picked a prefab from the SpaceShips assets and named it Shooter. This spaceship is our player.
Inside the Shooter we will add a Player Input component and create a new Input Actions Map.
We will add 6 actions: Move, Rotate, Thrust, ReverseThrust, Fire, and Fire1.
We name the new Input Action Maps as SpaceShipMov. In this case we decided to use a DualSense Controller(Gamepad) since it requires more actions and therefore more button configurations and a controller typically feels more natural.

![Screenshot 2023-12-11 at 12 00 11 AM](https://github.com/MegretMendez/PostWarApocalypse-Final-Project/assets/142510070/ed4163fc-e2e9-4795-a17b-ef4d799a9e2d)
The Move and Rotate will by Action Type "Value" and Control Type "Stick" since we will use the controler's joystick to execute these actions. The Thrust and ReverseThrust actions will also be of Action Type "Value" but will be Control Type "Any". Lastly the Fire actions will be of Action Type "Button" since it's a trigger action.
