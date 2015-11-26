using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrLektor
{
    class MusicFile
    {
        public string CheminAcces { get; set; }
        public MusicProperties Proprietees { get; set; }

        public MusicFile(string cheminAcces)
        {
            CheminAcces = cheminAcces;
            /*TagLib.File fichier = TagLib.File.Create(cheminAcces);
            var info = fichier.Tag;
            Proprietees = new MusicProperties(info.FirstAlbumArtist, info.Album, info.Year);*/
        }
    }
}