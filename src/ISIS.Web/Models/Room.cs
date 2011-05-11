using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIS.Web.Models
{
    public class Room
    {

        public Room(string roomNumber, int capacity)
        {
            Id = Guid.NewGuid();
            RoomNumber = roomNumber;
            Capacity = capacity;
            Equipment = new Dictionary<string, int>();
        }

        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public IDictionary<string, int> Equipment { get; set; }

    }
}