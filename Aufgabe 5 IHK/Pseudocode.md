Methode getFuellstand()
    Rückgabe fuellstand
Ende Methode
Methode setFuellstand(neuerWert)
    fuellstand = neuerWert
Ende Methode
Methode setFuellstand(neuerWert)
    WENN neuerWert >= 0 UND neuerWert <= fassungsvermoegen DANN
        fuellstand = neuerWert
    SONST
        // Fehlerbehandlung oder Ignorieren
    ENDE WENN
Ende Methode
