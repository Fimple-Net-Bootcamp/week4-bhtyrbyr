### C1 - Etki alan� katman� olu�turuldu.
* Etki alan� katman� olu�turuldu. 
* Varl�klarda ortak olan �zellikler i�in BaseEntity s�n�f� tan�mland�.
* Projede kullan�lacak entityler belirlendi ve tan�mland�.

### C2 - Uygulama katman� olu�turuldu.
* DTO'lar olu�turuldu.
* Aray�zler tan�mland�.
* Gerekli klas�rler olu�turuldu.
* Etki alan� katman�nda isim g�ncellemeleri yap�ld�.

### C3 - �sim g�ncellemeleri yap�ld�.
* Aray�zler async olacak �ekilde d�zenlendi. 
* Aray�zler bir IGenericRepository aray�z�ne ba�land�.
* Etki alan� katman�nda isim g�ncellemeleri yap�ld�.

### C4 - Persistence katman� olu�turuldu.
* Depo aray�zlerinin tan�m� bu katmanda yap�ld�.
* Application katman�ndaki IActivityRepository aray�z�ndeki namespace katman� d�zeltildi.
* DbContext s�n�f� olu�turuldu. Domain katman�nda tan�mlanan entityler �zerinden DbSet'ler tan�mland�.
* T�m projedeki gereksiz namespace kullan�m� kald�r�ld�.

### C5 - WebApi katman� olu�turuldu.
* Migration ile Db olu�turuldu.
* Pet controller eklendi. 
* DB'ye �rnek veri eklendi.

### C6 - DB g�ncellendi.
* Db migration ile g�ncellendi.
* MediatR projeye dahil edildi. 
* Kontrolc�lerden varl�klara do�rudan eri�im mediatr ile kald�r�ld�.

### C7 - Application katman�nda d�zenleme yap�ld�.
* Features kals�r d�zeni de�i�tirildi.
* Mapping profile kals�r� kald�r�ld�. Yerine t�m entity'lerin kendisine ait mapping profilleri olu�turuldu.
* Mediatr s�r�mleri 11.x'den 9.0'a �ekildi.

### C8 - Evcil hayvan ekleme �zelli�i eklendi.
* Evcil hayvan ekleme �zelli�i eklendi. 
* Veriler endpoint'de DTO ile al�n�p CommandHandler taraf�nda eksik bilgiler tamamlanarak veri taban�na kaydedilmesi sa�land�.

### C9 - Evcil hayvan sorgulamar� d�zenlendi.

### C10 - Entity'lerde ve DB'de d�zenlemeler yap�ld�.
* Entity'ler d�zenlendi.
* DTO'lar d�zenlenmek �zere kald�r�ld�.
* ServiceRegistration'lar IServicesCollection d�nd�recek �ekilde d�zenlendi.
* Kontrolc�ler d�zenlenmek �zere kald�r�l�.

### C11 - ��lem kay�tlar� entity'leri olu�turuldu.
* Yap�lan i�lemlerin kay�tlar�n�n DB'de tutulmas� i�in gerekli entity'ler olu�turuldu ve DB'ye migration ile yans�t�ld�.
* Kay�t entity'ler i�in Repository aray�zleri olu�turuldu.
* Entity'ler i�in Repository aray�zleri olu�turuldu.
* Infrastructure katman� i�inde Presistence i�erisinde olu�turulan Repository'lerin i�erisi dolduruldu.
* Ge�erli katman�n ServiceRegistraction fonksiyonu d�zenlendi.
