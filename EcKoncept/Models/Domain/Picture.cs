using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Models.Domain
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
