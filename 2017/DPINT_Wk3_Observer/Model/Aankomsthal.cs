﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk3_Observer.Model
{
    public class Aankomsthal : IObserver<Baggageband>
    {
        // TODO: Hier een ObservableCollection van maken, dan weten we wanneer er vluchten bij de wachtrij bij komen of afgaan.
        public ObservableCollection<Vlucht> WachtendeVluchten { get; private set; }
        public List<Baggageband> Baggagebanden { get; private set; }

        public Aankomsthal()
        {
            WachtendeVluchten = new ObservableCollection<Vlucht>();
            Baggagebanden = new List<Baggageband>();

            // TODO: Als baggageband Observable is, gaan we subscriben op band 1 zodat we updates binnenkrijgen.
            Baggagebanden.Add(new Baggageband("Band 1", 30));
            Baggagebanden[0].Subscribe(this);
            // TODO: Als baggageband Observable is, gaan we subscriben op band 2 zodat we updates binnenkrijgen.
            Baggagebanden.Add(new Baggageband("Band 2", 60));
            Baggagebanden[1].Subscribe(this);
            // TODO: Als baggageband Observable is, gaan we subscriben op band 3 zodat we updates binnenkrijgen.
            Baggagebanden.Add(new Baggageband("Band 3", 90));
            Baggagebanden[2].Subscribe(this);
        }

        public void NieuweInkomendeVlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            // TODO: Het proces moet straks automatisch gaan, dus als er lege banden zijn moet de vlucht niet in de wachtrij.
            // Dan moet de vlucht meteen naar die band.

            // Denk bijvoorbeeld aan: Baggageband legeBand = Baggagebanden.FirstOrDefault(b => b.AantalKoffers == 0);
            Vlucht nieuweVlucht = new Vlucht(vertrokkenVanuit, aantalKoffers);
            WachtendeVluchten.Add(nieuweVlucht);

            Baggageband legeBand = Baggagebanden.FirstOrDefault(bb => bb.AantalKoffers == 0);
            Vlucht volgendeVlucht = WachtendeVluchten.FirstOrDefault();
            if (legeBand != null && volgendeVlucht != null)
            {
                volgendeVlucht.StopWaiting();
                WachtendeVluchten.RemoveAt(0);

                legeBand.HandelNieuweVluchtAf(volgendeVlucht);
            }
        }

        public void WachtendeVluchtenNaarBand()
        {
            // TODO: Straks krijgen we een update van een baggageband. Dan hoeven we alleen maar te kijken of hij leeg is.
            // Als dat zo is kunnen we vrijwel de hele onderstaande code hergebruiken en hebben we geen while meer nodig.
                Baggageband legeBand = Baggagebanden.FirstOrDefault(bb => bb.AantalKoffers == 0);
                Vlucht volgendeVlucht = WachtendeVluchten.FirstOrDefault();
            if (WachtendeVluchten.Count > 0) {
                WachtendeVluchten.RemoveAt(0);
                volgendeVlucht.StopWaiting();
                legeBand.HandelNieuweVluchtAf(volgendeVlucht);
            }
        }

        public void OnNext(Baggageband value)
        {
                if (value.AantalKoffers == 0)
                    WachtendeVluchtenNaarBand();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
