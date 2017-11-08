# Compass .Net Client #

## Description ##

Client for connecting to Compass

## API Reference ##

~~~~
Initialize a new client with options

var options = new ClientConfig { CompassURL = "http://test.com" };
var client = new Client(options);
~~~~

### Request Example ###

## Client Variables ##

CompassURL - the endpoint of compass
HeartbeatInterval - seconds of heartbeat interval to run ( defaults to 15 seconds )