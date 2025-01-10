# Proje Adımları ve Detaylı Açıklamalar
## 1. Entity Oluşturma ve Yapılandırma
Projenin başlangıcında, temel veri yapılarını oluşturmak için BaseEntity ve RequestData sınıfları tasarlanmıştır. Bu sınıflar, veri modelinin temellerini oluşturmaktadır.

BaseEntity
BaseEntity sınıfı, veritabanındaki tüm tablolar için ortak bir temel sınıf olarak kullanılmıştır.
Her varlık için benzersiz bir Id alanı sağlanmış ve bu alanın Guid türünde olması, her kaydın benzersiz bir şekilde tanımlanmasını mümkün kılmaktadır.
BaseEntity sınıfı, her nesne oluşturulduğunda otomatik olarak bir Id değeri oluşturur.
RequestData
RequestData, API aracılığıyla alınacak veya gönderilecek olan JSON verisini temsil etmektedir.
Bu entity, verilen bir key ve ona karşılık gelen data bilgilerini tutmaktadır.
Key alanı, veri sorgulama işlemleri için kullanılacak anahtar olup, her kayda özgüdür.
Data alanı, JSON formatında saklanan veriyi temsil eder.


## 2. Marten ile PostgreSQL Bağlantısı
Marten, PostgreSQL veritabanında doküman tabanlı veri depolama yönetimi için kullanılan güçlü bir kütüphanedir. Marten ile veritabanına bağlantı kurulmuş ve verilerin saklanması sağlanmıştır.

Program.cs Yapılandırması
Marten için gerekli bağlantı stringi ve veritabanı ayarları Program.cs üzerinde yapılmıştır. PostgreSQL veritabanına düzgün bağlantı sağlanabilmesi için bağlantı noktası ve veritabanı ayarları dikkatle yapılandırılmıştır.
Marten ile bağlantı kurulduktan sonra, veritabanındaki işlemler için gerekli konfigürasyonlar yapılmıştır.

## 3. Endpoints (API İşlemleri)
API’nin temel işlevlerini yerine getirecek endpoint’ler Endpoints klasörü altında tanımlanmıştır. Her bir HTTP metodu için (GET, POST, DELETE) ayrı fonksiyonlar oluşturulmuş ve işlevler burada çağrılmıştır.

GET Endpoint
Bu endpoint, verilen key için ilgili data değerini döndüren bir yapı sunmaktadır. Marten kullanılarak, veritabanındaki kayıt sorgulanır ve istenilen JSON verisi döndürülür.
POST Endpoint
Bu endpoint, belirtilen key için veriyi ekler veya mevcut veriyi günceller. Marten, veritabanında yeni bir doküman ekler ya da mevcut dokümanı günceller. Eğer veritabanında belirtilen key için bir veri bulunmazsa, yeni bir kayıt eklenir; var olan bir kayıt varsa, mevcut veri güncellenir.
DELETE Endpoint
Bu endpoint, verilen key ile ilişkili veriyi veritabanından siler. Marten, belirli bir key ile ilişkilendirilmiş kaydı veritabanından kaldırır.

## 4. Swagger ile API Testi ve Dokümantasyon
API’nin doğruluğunu test etmek ve kolayca belgelenmesini sağlamak amacıyla Swagger entegrasyonu yapılmıştır. Swagger, API'nin uç noktalarına dair belgeleri sağlar ve bu sayede her endpoint kolayca test edilebilir.

Swagger, kullanıcıların API’yi daha hızlı şekilde test edebilmesi için son derece kullanışlıdır. Uygulama çalıştırıldığında Swagger UI üzerinden API'ye yapılan istekler rahatlıkla gözlemlenebilir.

## 5. Docker Compose ile Konteyner Yönetimi
API ve PostgreSQL veritabanını ayrı konteynerlerde çalıştırmak için Docker Compose kullanılmıştır. Bu sayede her iki servis kolayca başlatılabilir, konfigürasyonlar tek bir dosyada yönetilebilir ve konteynerler arasında gerekli bağlantılar kurulabilir.

Docker Compose Yapılandırması
Docker Compose dosyasına, API ve PostgreSQL servisleri tanımlanmıştır.
Her iki servis için de gerekli Dockerfile'lar oluşturulmuş, API için .NET SDK görüntüsü, PostgreSQL için ise resmi PostgreSQL Docker görüntüsü kullanılmıştır.
API ve veritabanı konteynerlerinin aynı ağda çalışabilmesi için Docker Compose’da ortak bir network yapılandırılmıştır.
HealthCheck özelliği ile her iki servisin sağlığı sürekli olarak izlenmiş ve düzgün çalışıp çalışmadıkları kontrol edilmiştir.

## 6. Veritabanı Sağlığı ve Sağlamlık Kontrolleri
Docker Compose içinde kullanılan HealthCheck özelliği, her iki servisin düzgün bir şekilde çalışıp çalışmadığını test eder. Bu özellik, konteynerlerin doğru şekilde başlatıldığını ve her iki servisin de birbirine sağlıklı bir şekilde bağlanabildiğini doğrular.
