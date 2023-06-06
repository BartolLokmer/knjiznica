Jednostavna aplikacija za knjige koja podržava: 
unos, 
uređivanje, 
brisanje, pretragu, 
popis knjiga u bazi. 

Aplikacija također treba omogućiti brisanje I prikaz detalja pojedine knjige. Svaki unos podataka kroz aplikaciju treba uključivati provjeru valjanostii za brisanje podataka je potrebna posebna potvrda korisnika.
Aplikaciji treba moći pristupiti svi korisnici koji imaju internet I internet preglednik te žele pristupiti svim bitnih informacijama o raznim knjigama na jednom centraliziranom mjestu.
Korisnici kada budu htjeli potražiti informacije o knjigama neće više morati pretraživati putem Googlea I koristiti više izvora za dobivanje informacija o nekoj knjgi, jer će kroz aplikaciju moći dobiti sve potrebne informacije na jednom mjestu. Aplikacija će biti dostupna putem interneta zahvaljujući tome korisnik ima mogućnost korištenja aplikacije u bilo koje vrijeme.
Aplikacija mora omogućiti: 
spremanje, 
uređivanje, 
pretraživanje, 
prikaz, 
traženje, 
brisanje knjiga u bazi podataka

Budući da će aplikacija biti razvijena u ASP.NET Core MVC-u, ona treba biti smještena na Microsoft Web poslužitelj (eng. Server). Preporučuju se sljedeće hardverske specifikacije:
Minimum četverojezgreni processor radnog takta 2.2GHz
Minimum 32GB RAM memorije
Minimum 1TB diskovnog prostora
Operativni sustav Windows server (2019)
Preporučuje se korištenje Windows Azurea za hostanje aplikacije. Windows azure može hostati bilo koju ASP.NET Core MVC aplikaciju, uključujući I našu predloženu aplikaciju u ovom dokumentu. Skaliranje je vrlo jednostavno jer je Microsoft odgovoran za dodavanje resursa na poslužitelju za vrijeme visokog prometa.
Troškovi su minimalni, oni ovise o količini podataka koji se prikazuju posjetiteljima te održavanje hardwarea nije uključeno u njih.

U kasnijem razvoju aplikacije razvit će se sigurna identifikacija I zaštićena autentifikacija gdje korisnička imena i lozinke ne smiju biti spremljena u obična tekstualna polja ili datoteke, a osobni podaci korisnika kao što su adresa, telefonski brojevi i brojevi kreditnih kartica neće biti dostupni anonimnim pristupom
