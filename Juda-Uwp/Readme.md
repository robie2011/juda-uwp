#Juda (UWP)
06. März 2016

## Einleitung
In den Gottesdiensten der christlichen Freikirchen wird der Lobpreis oft mit Musik gestaltet. Der Songtext wird während der Lobpreiszeit auf den Leinwand projiziert. Für Sänger und Musiker sind die  Songtexte bzw. die Akkorde eine wichtige stütze.
Es entstehen dabei verschiedene Versionen von Songtexten. Weder das Layout noch die Schrift ist vereinheitlicht. Es werden Unmengen von Duplikate über die ganze Festplatte, Mobile Geräte und Online Speicher verteilt. Wird ein Songtexte kurzfristig erstellt, muss diese an alle beteiligten verteilt werden. Änderungen müssen auch an alle propagiert werden. 
Jeder hat eine eigene Sammlung von Songtexten. Das Finden der Texten bei einer grossen Menge ist auch zeitraubend.
Das Problem wird durch die Mehrsprachigkeit mancher Songtexte weiter erschwert. 

Das Webplattform Juda wurde ins Leben gerufen, um eine zentrale Verwaltung der Lieder zu ermöglichen. Das finden zu vereinfachen (es kann verschiene Kriterien gesucht werden). Es soll möglich sein denselben Text massgeschneidert an Mobile Geräte, Computer Bildschirm und Projektoren anzuzeigen. Die künftige Entwicklung soll auch ermöglichen die Akkorde im Text zu integrieren und je nach Darstellungszweck ein- und auszublenden.

Im Oktober 2015 wurde die Webapplikation http://juda.uf.to erstmal öffentlich zugänglich gemacht. Aktuell sind etwa 100 Lieder im Datenbank registriert. Viele der Songtexte sind auch in mehreren Spracheversionen erhältlich. In den letzten 30 Tagen sind etwa sind 75 Sessions von 25 verschiedenen Nutzer registriert worden. Eine hohe Entwicklung der Besucherzahlen ist nach aktive Werbung zu erwarten.

## API
    Alle Lieder auflisten    
    http://juda.uf.to/api/Songs

    Songtext anzeigen
    http://juda.uf.to/api/Songs/101/Mastersheet

## Datenstruktur
JSON übersetzt nach C#

    // Song-Objekt (http://juda.uf.to/api/Songs)
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int artistId { get; set; }
        public string artistName { get; set; }
        public int? albumId { get; set; }
        public string albumName { get; set; }
        public int mainLanguageId { get; set; }
        public int songTypeId { get; set; }
    }


    // Mastersheet JSON Objekt (http://juda.uf.to/api/Songs/101/Mastersheet)
    public class RootObject
    {
        public int songId { get; set; }
        public string text { get; set; }
    }

## Mastersheet Markups

### Sprache
Folgende Tags kennzeichen die Sprache des nachfolgenden Textabschnitts. Ist keine Kennzeichnung zu finden, wird English als Standard angenommen. 
Die Tamilische Schrift hat im Unicode den Range '0B80–0BFF' erhalten. 
Liegt das erste Zeichen des Textes in diesem Bereich, so wird der Text als Tamilisch gekennzeichnet


    #English
    #Tamil
    #TamilPronounced
    #German

### Liedabschnitte
Ist keine Kennzeichnung zu finden, so wird der erste Abschnitt als #Vers1, der zweite Abschnitt als #Vers2 etc angenommen.
Folgende Tags werden von dem System erkannt

    #Vers1
    #Vers2
    #Vers3
    #Vers4
    #Vers5
    #Vers6
    #Chorus
    #PreChorus
    #Bridge
    #Intro

## Screenshots

![BILD1](http://www.imgshark.org/images/2016-03-0314_26_17-Newnotification.png)


![BILD1](http://www.imgshark.org/images/Screenshot_20160303-142324.png)

![BILD1](http://www.imgshark.org/images/Screenshot_20160303-142342.png)

![BILD1](http://www.imgshark.org/images/Screenshot_20160303-142400.png)


## Devs
- Hamburger Menu, http://blogs.msdn.com/b/quick_thoughts/archive/2015/06/01/windows-10-build-your-first-hamburger-menu.aspx
- Embed Font, https://invokeit.wordpress.com/2012/10/18/embed-use-custom-font-in-windows-8-store-apps-win8dev-winrt/
- Styling with XML, http://www.wpftutorial.net/styles.html
- Margin Property order,http://stackoverflow.com/questions/8522018/properties-order-in-margin
