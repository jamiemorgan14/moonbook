using System;
using moonbook.Models;

namespace moonbook
{
  class App
  {

    public IDestination CurrentLocation { get; set; }
    public bool Running { get; set; }

    private void Initialize()
    {
      //create all planets
      Planet mercury = new Planet("Mercury", "It's hot here");
      Planet venus = new Planet("Venus", "Everything is melting");
      Planet earth = new Planet("Earth", "What kind of name is Earth, might as well call it dirt");
      Planet mars = new Planet("Mars", "This planet is entirely inhabited by robots, and Matt Damon's potatoes");
      Planet jupiter = new Planet("Jupiter", "Gas Giant");
      Planet saturn = new Planet("Saturn", "Will you marry me? (It's a ring joke)");
      Planet uranus = new Planet("Uranus", "Nope, not even going there");
      Planet neptune = new Planet("Neptune", "Also Roman god of the sea, fun fact.");
      Planet pluto = new Planet("Pluto", "It's Totally a planet...... Ask Jerry");

      //create moons
      Moon luna = new Moon("Moon", "It's not cheese", earth);
      Moon phobos = new Moon("Phobos", "The better of the two", mars);
      Moon europa = new Moon("Europa", "Yo dawg we heard you like moons", jupiter);
      Moon titan = new Moon("Titan", "AE", saturn);

      //establish relationships
      mercury.AddNearbyDestination(Direction.next, venus);
      venus.AddNearbyDestination(Direction.previous, mercury);
      venus.AddNearbyDestination(Direction.next, earth);
      earth.AddNearbyDestination(Direction.moon, luna);
      earth.AddNearbyDestination(Direction.previous, venus);
      earth.AddNearbyDestination(Direction.next, mars);
      //ETC.........

      //declare starting point to init data chain and run app
      CurrentLocation = earth;
      Running = true;
    }
    public void Run()
    {
      Initialize();
      while (Running)
      {
        System.Console.WriteLine($"{CurrentLocation.Name}: {CurrentLocation.Description}");
        if (CurrentLocation is Planet)
        {
          System.Console.WriteLine("Next, Previous, or Moon");
          string choise = Console.ReadLine();
          Planet curPlanet = (Planet)CurrentLocation;
          CurrentLocation = curPlanet.TravelToDestination(Direction.previous);
          //switch to determine next prev or moon/sign guestbook
        }
        else
        {
          Moon curMoon = (Moon)CurrentLocation;
          System.Console.WriteLine("Returning to planet");
          CurrentLocation = curMoon.Return();
        }
      }
    }




  }
}