﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDomain.Entities
{
    public class Song
    {
        public int SongID { get; set; }
        public DateTime DateCreation { get; set; }
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public decimal Bpm { get; set; }
        public string TimeSignature { get; set; }
        public bool Multitracks { get; set; }
        public bool CustomMix { get; set; }
        public bool Chart { get; set; }
        public bool RehearsalMix { get; set; }
        public bool Patches { get; set; }
        public bool SongSpecificPatches { get; set; }
        public bool ProPresenter { get; set; }
    }
}
