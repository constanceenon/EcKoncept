using EcKoncept.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Models.Domain
{
    public class Album
    {
        public int ID { get; set; }
        public string AlbumTitle { get; set; }

        public List<Picture> Pictures = new List<Picture>();
    }
}
