using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day23 : Day {
        public Day23() : base(23) {
            addAufgabe("Prüfungsvorbereitung, G62 Aufgabe 3", Uebung1);
        }

        /*
         *      G62 Aufgabe 3 Eventhandler
         */
        public void Uebung1() {
            Video video1 = new Video("König der Löwen 720p cinerip");
            VideoEncoder videoEncoder = new VideoEncoder();
        }

        class Video {
            public string Name { get; set; }
            public Video(string name) {
                Name = name;
            }
        }

        class VideoEventArgs : EventArgs {
            public Video Video { get; private set; }
            public DateTime Zeit { get; private set; }
            public VideoEventArgs(Video video) {
                Video = video;
            }
        }

        class VideoEncoder {
            public event EventHandler<VideoEventArgs> videoEvent;
            public void Encode(Video video) {
                Console.WriteLine("Start Encoding...");
                Thread.Sleep(100);
                Console.WriteLine("Finished Encoding!");
                videoEvent?.Invoke(this, new VideoEventArgs(video));
            }
        }

        class MailService {
            public void OnVideoEncoded() {
                Console.WriteLine($"EMail: Video");
            }
        }
        class PrinterService {

        }
        class SMSService {

        }
    }
}
