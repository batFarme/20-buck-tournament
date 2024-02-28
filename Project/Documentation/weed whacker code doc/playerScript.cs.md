manages player's health, current state, and other things. 
holds references to other scripts, those of which are different states (i.e. standing, dead, etc)
calls those scripts as functions every frame; state management is far cleaner this way 

references: 
- playerStanding.cs
variables:
- playerSpeed: float
functions: 