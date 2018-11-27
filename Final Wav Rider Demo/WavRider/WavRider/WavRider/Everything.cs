using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WavRider {
    public class Everything {

        private List<string> artists = new List<string>;
        private List<string> albums = new List<string>;
        private List<string> allSongList = new List<string>;
        
        public Everything() {

        }

        private void FillLists(string path) {
            try {
                foreach(string d in Directory.GetDirectories(path)) {
                    FillLists(d);

                }
            }
        }

    }
}
