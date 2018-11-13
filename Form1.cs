using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Playback {
    public partial class Form1 : Form {
        WaveOutEvent waveOut;
        bool isPlaying = false;
        string currentSong;

        Mp3FileReader mp3Reader;
        WaveFileReader waveReader;
        SongList songList = new SongList("C:\\Users\\Owner\\Desktop\\MusicShite");

        public Form1() {
            Debug.WriteLine(songList.GetSongList()[0]);
            CheckSong(songList.GetSongList()[0]);
            currentSong = songList.GetSongList()[0];

            InitializeComponent();

        }

        
        //rewind
        private void button1_Click(object sender, EventArgs e) {
            if(currentSong.Equals(songList.GetSongList()[0]) && currentSong.Contains(".mp3") && mp3Reader.CurrentTime <= TimeSpan.FromSeconds(3.0))
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(0.0);
            else if (currentSong.Equals(songList.GetSongList()[0]) && currentSong.Contains(".wav") && waveReader.CurrentTime <= TimeSpan.FromSeconds(3.0))
                waveReader.CurrentTime = TimeSpan.FromSeconds(0.0);
            else if (currentSong.Equals(songList.GetSongList()[0]) && currentSong.Contains(".mp3") && mp3Reader.CurrentTime >= TimeSpan.FromSeconds(3.0))
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(0.0);
            else if (currentSong.Equals(songList.GetSongList()[0]) && currentSong.Contains(".wav") && waveReader.CurrentTime >= TimeSpan.FromSeconds(3.0))
                waveReader.CurrentTime = TimeSpan.FromSeconds(0.0);

            else if (currentSong.Contains(".mp3") && mp3Reader.CurrentTime >= TimeSpan.FromSeconds(3.0) && currentSong != songList.GetSongList()[0]) 
                mp3Reader.CurrentTime = TimeSpan.FromSeconds(0.0);
            else if(currentSong.Contains(".wav") && waveReader.CurrentTime >= TimeSpan.FromSeconds(3.0) && currentSong != songList.GetSongList()[0])
                waveReader.CurrentTime = TimeSpan.FromSeconds(0.0);
            else { 
                currentSong = songList.GetSongList()[songList.GetSongList().IndexOf(currentSong) - 1];
                waveOut.Stop();
                waveOut.Dispose();
                if (mp3Reader != null)
                    mp3Reader.Dispose();
                if (waveReader != null)
                    waveReader.Dispose();
                CheckSong(songList.GetSongList()[songList.GetSongList().IndexOf(currentSong)]);
                waveOut.Play();
                isPlaying = true;
            }
        }
        //play
        private void button2_Click(object sender, EventArgs e) {
            
            if(isPlaying == true) {
                waveOut.Pause();
                isPlaying = false;
            } else if(isPlaying == false) {
                waveOut.Play();
                isPlaying = true;
            }
        }
        //fastforward
        private void button3_Click(object sender, EventArgs e) {
            if(currentSong.Equals(songList.GetSongList()[songList.GetSongList().Count - 1])) { 
                waveOut.Stop();
                waveOut.Dispose();
                if (mp3Reader != null)
                    mp3Reader.Dispose();
                if (waveReader != null)
                    waveReader.Dispose();
            } else { 
                currentSong = songList.GetSongList()[songList.GetSongList().IndexOf(currentSong) + 1];
                waveOut.Stop();
                waveOut.Dispose();
                if(mp3Reader != null)
                    mp3Reader.Dispose();
                if(waveReader != null)
                    waveReader.Dispose();
                CheckSong(songList.GetSongList()[songList.GetSongList().IndexOf(currentSong)]);
                waveOut.Play();
                isPlaying = true;
            }
        }
        //checks if song is .wav or .mp3
        private void CheckSong(string song) {
            waveOut = new WaveOutEvent();

            if (song.Contains(".mp3")) {
                mp3Reader = new Mp3FileReader(song);
                waveOut.Init(mp3Reader);
            } else if(song.Contains(".wav")) {
                waveReader = new WaveFileReader(song);
                waveOut.Init(waveReader);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
