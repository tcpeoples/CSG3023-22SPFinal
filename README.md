# 22SP CSG 3023 Final Exam - Brick Basher
**Title:** Brick Basher

**Genre:** Action / Arcade

**Platform:** PC

**Game Concept**

Based on the classic arcade game “Breakout” this action game prototype will have the player launch a ball in to hit the bricks on screen. The player will gain points for each brick hit.  The ball will bounce when it hits any object on screen. The player must keep the ball on screen by moving the paddle around. If the ball goes off screen, then the player loses one ball (life). 

**Game Objects**

- Walls –prefabs that line the top and sides of the playing field 
- OutBounds – empty object with collider. The collider should be the size of the out bounds area of the bottom of the screen. We do not want the ball to stop if hits the Outbounds collider, just to trigger an event. 
- Paddle – prefab in scene, use Paddle class to move the paddle at a certain speed with the arrow keys left and right. Include a RigidBody with no gravity.
- Bricks (spawner) – empty object to hold the instantiate bricks. Use the BrickSpwaner class to Instantiate bricks, for 7 columns (y) for 7 rows (x). 
- Ball – prefab sphere. The ball should bounce using a Physics Material. 
  - The ball should have a RigidBody with no gravity, sues a small mass with no drag. 
  - Ball should have an audio source for the bounce clip.
- Brick – prefab object. Art team has already placed in prefab folder

**Visuals**

HUD should include in game score, and number of balls (lives) which the player has

**Sounds**

Every time the ball collides with an object the “bounce” sound clip should play. 
Audio source should be on the ball object. 

**Controls**

Play is controlled with the keyboard keys. Press spacebar to release ball, use arrow keys to move paddle.

**Game Flow and Mechanics**

The ball moves with the paddle until the player presses the “Space” key. Then it bounces all over the screen. The level is over when all of the bricks have been destroyed or if the player loses all allotted balls. 

**Sample Concept Art**

Prototype scene and objects have been created.

Only the 1X1X1 ball object (prefab) needs to be created.  

![Brick Basher Game sketch](doc-imgs/brickBasher-Sketch.png)
