using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day18 : Day {
        public Day18() : base(18) {
            addAufgabe("Aufgabe 4, TryCatch", Uebung1);
        }

        /*
         *  Aufgabe 4, TryCatch
         */

        public void Uebung1() {
            Video video1 = new Video("Moby Dick");
            Video video2 = new Video("König der Löwen");
            Kunde kunde1 = new Kunde("Manny Manfred");
            Kunde kunde2 = new Kunde("Siggy Siegfried");

            // Simulation der Zeit...
            for (int i = 0; i < 30; i++) {
                // Leihvorgänge
                if (i == 7) Ausleihe.VideoAusleihen(video1, kunde2);
                if (i == 12) Ausleihe.VideoAusleihen(video2, kunde1);
                if (i == 17) Ausleihe.VideoZurueck(video1, kunde2);
                try { 
                    if (i == 20) Ausleihe.VideoZurueck(video1, kunde2); 
                } catch (Exception e) { 
                    Console.WriteLine(e.Message); 
                }
                if (i == 22) Ausleihe.VideoAusleihen(video1, kunde1);
                if (i == 25) Ausleihe.VideoZurueck(video2, kunde1);
                try {
                    if (i == 28) Ausleihe.VideoAusleihen(video1, kunde1);
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                
                Thread.Sleep(100);
                Time.NextDay();
            }
            Console.WriteLine(Ausleihe.ListeAusgeben());
        }

        class Time {
            public static DateTime Today { get; set; } = DateTime.Now;
            public static void NextDay() {
                Today = Today.AddDays(1);
            }
        }

        class Ausleihe {
            public static List<Ausleihe> leihListe = new List<Ausleihe>();
            public Video VideoAusgeliehen { get; private set; }
            public Kunde KundeAusleihend { get; private set; }
            public string Leihdatum { get; private set; }
            public string RueckDatum { get; private set; }

            public Ausleihe(Video video, Kunde kunde) {
                VideoAusgeliehen = video;
                VideoAusgeliehen.ToggleVideoVerfuegbar();
                KundeAusleihend = kunde;
                Leihdatum = Time.Today.ToShortDateString();
                RueckDatum = null;
                leihListe.Add(this);
                Console.WriteLine($"Video {VideoAusgeliehen.Titel} am {Leihdatum} verliehen an {KundeAusleihend.Name}");
            }
            public static void VideoAusleihen(Video video, Kunde kunde) {
                if (video.VideoVerfuegbar) new Ausleihe(video, kunde); // Wenn Video verfügbar -> neuer Verleihvorgang
                else throw new Exception("Video nicht verfügbar"); // Wenn Video nicht verfügbar -> Fehler
            }
            public static void VideoZurueck(Video video, Kunde kunde) {
                // Speichert den letzten Ausleiheintrag mit dem angegebenen Video in temp
                Ausleihe temp = leihListe.FindLast(x => x.VideoAusgeliehen == video);

                if (temp.KundeAusleihend == kunde && temp.RueckDatum == null) { // Prüft ob der Leihvorgang zum Kunden passt und das Video noch nicht zurückerhalten wurde
                    video.ToggleVideoVerfuegbar(); // Video als Verfügbar kennzeichnen
                    temp.RueckDatum = Time.Today.ToShortDateString();
                    Console.WriteLine($"Video {temp.VideoAusgeliehen.Titel} am {temp.RueckDatum} von {temp.KundeAusleihend.Name} zurückerhalten");
                } else {
                    throw new Exception("Ausleihvorgang nicht gefunden");
                }
            }
            public static string ListeAusgeben() {
                string ausgabe = "";
                leihListe.ForEach(eintrag => {
                    ausgabe += $"Kunde {eintrag.KundeAusleihend.Name} hat am {eintrag.Leihdatum}" +
                    $" das Video {eintrag.VideoAusgeliehen.Titel} ausgeliehen und " +
                    (eintrag.RueckDatum != null ? $"am {eintrag.RueckDatum} zurückgebracht\n" : "noch nicht zurückgegeben\n");
                });
                return ausgabe;
            }
        }

        class Video {
            public static List<Video> videos = new List<Video>();
            public string Titel { get; set; }
            public bool VideoVerfuegbar { get; private set; } = true;
            public Video(string titel) {
                Titel = titel;
                videos.Add(this);
            }
            public void ToggleVideoVerfuegbar() {
                if (VideoVerfuegbar) VideoVerfuegbar = false;
                else VideoVerfuegbar = true;
            }
        }

        class Kunde {
            public static List<Kunde> kunden = new List<Kunde>();
            public string Name { get; set; }
            public Kunde(string name) {
                Name = name;
                kunden.Add(this);
            }
        }
    }
}
