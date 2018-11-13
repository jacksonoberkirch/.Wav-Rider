using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playback {
    public class SongList {
        private List<string> songList = new List<string>();

        public SongList(string path) {
            GenerateSonglist(path);
        }

        private void GenerateSonglist(string path) {
            foreach(string file in Directory.GetFiles(path)) {
                songList.Add(file);
                //songList[songList.IndexOf(file)] = songList[songList.IndexOf(file)]
                  //                                  .Replace(".mp3", "")
                    //                                .Replace(path, "");
            }
        }

        public List<string> GetSongList() {
            return songList;
        }

    }
}
