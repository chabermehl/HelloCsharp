using HelloCsharp;

var player1 = new Player(false);
var player2 = new Player(true);

var game = new Game(player1, player2);

game.GameLoop();