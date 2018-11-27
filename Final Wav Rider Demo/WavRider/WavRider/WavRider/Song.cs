using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WavRider {
    public class Song {
        private float length = new float();
        private string title; //will come from function in artist class
        private string album; //will come from function in artist class
        private string artist; //will come from function in artist class

        public Song() {

        }

        public string GetTitle() {
            return title;
        }

        public string GetAlbum() {
            return album;
        }

        public string GetArtist() {
            return album;
        }



    }
}
