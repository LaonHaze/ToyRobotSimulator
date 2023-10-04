# Toy Robot Simulator

## Description

Toy robot simulator that moves on a square tabletop, of dimensions 5 units x 5 units.

## Prerequisites

Before the project can be built, you must first install the .NET 6.0 SDK on your system.

This project also requires a Visual Studio version that supports .NET 6.0

## Running the Project

Open the project with Visual Studio by opening the Solution (`.sln`) file. Then ensure `ToyRobot.ConsoleApp` is set as the startup project. Hit `F5` to run the app.

## Requirements

The application can read any one of the following commands:

```
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT
```

- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH,
EAST or WEST.
- The origin (0,0) can be considered to be the SOUTH WEST most corner.
- The first valid command to the robot is a PLACE command, after that, any sequence
of commands may be issued, in any order, including another PLACE command. The
application should discard all commands in the sequence until a valid PLACE
command has been executed.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without
changing the position of the robot.
- REPORT will announce the X,Y and F of the robot. This can be in any form, but
standard output is sufficient.
- A robot that is not on the table should ignore the MOVE, LEFT, RIGHT and REPORT
commands.

- The toy robot must not fall off the table during movement. This also includes the initial
placement of the toy robot.
- Any move that would cause the robot to fall must be ignored.
  
## Description

Application has been written in .NET6.0. 

## Example Input and Output

```
PLACE 0,0,NORTH
MOVE
REPORT
```
Output: 0,1,NORTH

```
PLACE 0,0,NORTH
LEFT
REPORT
```
Output: 0,0,WEST

```
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```
Output: 3,3,NORTH
