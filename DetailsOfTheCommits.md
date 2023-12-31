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

### C12 - Hayvanlar i�in t�m hayvanlar� sorgulama �zelli�i DTO uygulanarak eklendi.
* Evcil hayvanlar i�in sorgulama �zelli�i mediatr pattern kullan�larak eklendi. 
* Evcil hayvanlar� liste olarak g�r�nt�lerken PetSimplifiedViewDTO nesnesi kullan�ld�.
* Verilerin map'lenmesi i�in AutoMapper kullan�ld�.

### C13 - Evcil hayvan kaydetme �zelli�i eklendi.
* Evcil hayvan kaydetmek i�in HttpPost metodu olu�turuldu.
* ��lemlerin sonucu d�nd�rmek i�in Reponse s�n�flar� olu�turuldu. 
* �zel hata s�n�f� olu�turuldu.
* Evcil hayvan olu�turma PetCreateDTO ile sa�land� ve veri haritalamas�nda AutoMapper kullan�ld�.

### C14 - Kay�t silme �zelli�i eklendi.
* Evcil hayvan kay�tlar�n�n silinmesi i�in HttpDelete metodu olu�turuldu.
* �stek sonucu d�nen ServiceResponse s�n�f� d�zenlendi.
* Silinecek kay�t bulunamamas� durumunda f�rlat�lacak hata s�n�f� olu�turuldu.

### C15 - Sorgular i�in d�zenlemeler yap�ld�.
* T�m isteklerde geri d�n�� de�erleri tan�ml� Response s�n�flar�nda tan�mland�.
* Sorgu metotlar� d�zenlendi.

### C16 - Evcil hayvan kayd� g�ncelleme �zelli�i eklendi.
* PetController'da PUT ve PATCH isteklerini kar��layacak fonksiyonlar olu�turuldu.
* �ki iste�in i�lemi tek bir Command �zerinden i�leyebilecek hale getirildi.
* PetUpdateDTO model yap�s� olu�turuldu.
* �sim d�zenlemeleri yap�ld� ve baz� bug'lar ��z�mlendi.

### C17 - GenericRepository d�zenlendi.
* GenericRepository i�erisinde kullan�lmayan HasEntity fonksiyonu kald�r�ld�.

### C18 - Kullan�c� kay�tlar� i�in sorgu �zellikleri eklendi.
* Kullan�c� s�n�f�n�n g�sterilmesi i�in iki �e�it DTO olu�turuldu. (Detayl� ve Basitle�tirilmi�)
* Veri haritalama i�in Automapper kullan�ld�.

### C19 - Kullan�c� kay�t ekleme/silme/g�ncelleme �zellikleri eklendi.
* Silme �zelliklerinde tablolar�n birbirini etkilemesi durumunda �zel "ViolatesForeignKeyException" s�n�f� olu�turuldu.
* Kay�t ekleme �zelli�i olu�turuldu.
* G�ncelleme �zellikleri eklendi.
* �sim d�zenlemeleri yap�ld�. 
* D�n�� tipleri ve hata metinlerinde d�zenleme yap�ld�.

### C20 - Evcil hayvan yemekleri i�in kontrolc� olu�turuldu.
* Evcil hayvan kayd� tamam�n� g�r�nt�leme/Id'ye g�re g�r�nt�leme/ekleme/silme/g�ncelleme �zelli�i eklendi.
* Application katman�nda entity feature'lar�nda de�i�ken isimlendirmeleri d�zenlendi. 
* Gereksiz namespace tan�mlamalar� kald�r�ld�.

### C21 - E�itim komtrolc�s� eklendi.
* E�itimler i�in kontrolc� olu�turuldu.
* E�itim i�in Repo s�n�f� olu�turuldu.
* Namespace ve de�i�ken isimleri d�zenlendi.

### C22 - Aktiviteler kontrolc�s� eklendi.
* E�itimler i�in kontrolc� olu�turuldu.
* E�itim i�in Repo s�n�f� olu�turuldu.
* Namespace ve de�i�ken isimleri d�zenlendi.

### C23 - Yap�lacak i�lemler i�in operayson kontrolc�s�n� �zelli�i eklendi.
* Sisteme giri� �zelli�i eklendi.
* Evcil hayvan sahiplenme �zelli�i eklendi.
* Evcil hayvan ile aktivite yapma �zelli�i eklendi.
* Evcil hayvan besleme �zelli�i eklendi.
* Evcil hayvan e�itme �zelli�i eklendi.

### C24 - Yap�lan i�lemlerin takibi i�in kay�t kontrolc�s�n� �zelli�i eklendi.
* Evcil hayvan sahiplenme kayd� g�r�nt�leme �zelli�i eklendi.
* Evcil hayvan ile aktivite yapma kayd� g�r�nt�leme �zelli�i eklendi.
* Evcil hayvan besleme kayd� g�r�nt�leme �zelli�i eklendi.
* Evcil hayvan e�itme kayd� g�r�nt�leme �zelli�i eklendi.
* 
### C25 - Kontrolc�lere gelen verilerin do�rulanmas� i�in FluentValidation �zelli�i eklendi.