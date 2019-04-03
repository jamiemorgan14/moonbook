using System.Collections.Generic;

namespace moonbook.Models
{
  class Planet : IDestination
  {
    public string Name { get; set; }
    public string Description { get; set; }
    List<string> GuestBook { get; set; }
    Dictionary<Direction, IDestination> NearbyDestinations { get; set; }

    public void SignBook(string name)
    {
      GuestBook.Add(name);
    }

    public void PrintGuestBook()
    {
      System.Console.WriteLine("Visitors to our planet: ");
      GuestBook.ForEach(name =>
      {
        System.Console.WriteLine(name);
      });
    }

    public void AddNearbyDestination(Direction direction, IDestination destination)
    {
      NearbyDestinations.Add(direction, destination);
    }

    public IDestination TravelToDestination(Direction dir)
    {
      if (NearbyDestinations.ContainsKey(dir))
      {
        return NearbyDestinations[dir];
      }
      System.Console.WriteLine("Your ship can't go that way, stupid!");
      return (IDestination)this;
    }
    public Planet(string name, string desc, Moon moon = null)
    {
      NearbyDestinations = new Dictionary<Direction, IDestination>();
      GuestBook = new List<string>();
      Name = name;
      Description = desc;
    }

  }
  public enum Direction
  {
    next,
    previous,
    moon
  }
}