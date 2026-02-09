

*Musteris tablosunu veritabanında oluşturduktan sonra migrationHistory adında bir tablo oluşmuştur.Bu tablo yapılacak ve yapılmış olan işlemleri tutan ,gösteren tablodur.
*Automatic Migration için configurations dosyasından AutomaticMigrationsEnabled=true; AutomaticMigrationDataLossAllowed=true;   yapılır.
*Float olarak tanımlanan tablo verileri real olarak saklanıyor.


*Entity Framework (EF) Migration, C# kodlarınızda yaptığınız model değişikliklerini (yeni bir sınıf ekleme, bir özelliğin adını değiştirme veya silme gibi) veritabanına güvenli ve sistemli bir şekilde yansıtmanızı sağlayan bir "versiyon kontrol" mekanizmasıdır.

Basitçe ifade etmek gerekirse; kodunuz geliştikçe veritabanınızın da ona ayak uydurmasını sağlayan bir köprüdür.

Migration Neden Önemlidir?
Eskiden veritabanında bir değişiklik yapmak için SQL Management Studio'yu açıp manuel tablo oluşturur veya ALTER TABLE komutları yazardık. Migration ile:

SQL bilme zorunluluğu azalır: C# sınıflarınızı (Entity) güncellediğinizde EF, gerekli SQL komutlarını kendisi hazırlar.

Versiyonlama: Veritabanının hangi aşamalardan geçtiğini takip edebilirsiniz (Git mantığı gibi).

Geri Alabilme: Yapılan bir değişikliği kolayca geri alabilirsiniz.

Takım Çalışması: Projeyi başka bir bilgisayarda çalıştıran ekip arkadaşınız, tek bir komutla veritabanını sizinle aynı hale getirebilir.

Temel Çalışma Mantığı: Up ve Down
Her Migration dosyası iki ana metot içerir:

Up(): Bu Migration uygulandığında veritabanında yapılacak değişiklikleri içerir (Örn: Tablo oluştur).

Down(): Yapılan değişikliği geri almak istediğinizde ne yapılacağını söyler (Örn: Tabloyu sil).

En Çok Kullanılan Komutlar
Migration işlemlerini genellikle Package Manager Console (Visual Studio) veya .NET CLI (Terminal) üzerinden yönetiriz.

İşlem                           Package Manager Console             .NET CLI (Terminal)
Migration Oluşturma          Add-Migration MigrationAdi         dotnet ef migrations add MigrationAdi
Veritabanını Güncelleme          Update-Database                 dotnet ef database update
Son Migration'ı Silme           Remove-Migration                  dotnet ef migrations remove



**Enable-Migrations====================================================>Migration Etkin Hale Getirme
**Add-Migration MigrationAdi===========================================>Migration Ekleme
**Update-Database======================================================>Veritabanına Güncelleme
**Update-database -TargetMigration:Veritabanındaki Migration Adı=======>İstenilen Migrationa geçiş


**modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention> ();satırı Cascade Delete (Kademeli Silme) Nedir? (Kodlarken hata  almıştım)
Varsayılan olarak Entity Framework'te, aralarında bire-çok (One-to-Many) ilişki bulunan iki tablodan "ana" (parent) olanı silerseniz, ona bağlı olan tüm "çocuk" (child) kayıtlar da otomatik olarak silinir.

Örnek: Bir Kategoriyi sildiğinizde, o kategoriye bağlı olan 500 tane Ürünün de veritabanından bir anda yok olmasıdır.
Bu Satır Ne Yapar?
ModelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); satırını OnModelCreating metoduna eklediğinizde şu gerçekleşir:
Otomatik Silmeyi Durdurur: Ana tabloyu sildiğinizde çocuk tabloların silinmesini engeller.
Hata Fırlatır: Eğer bir kategoriyi silmeye çalışırsanız ve ona bağlı ürünler varsa, SQL size izin vermez: "Bu kategoriye bağlı ürünler var, önce onları hallet!" şeklinde bir hata alırsınız.





