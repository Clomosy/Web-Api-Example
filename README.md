# Web-Api-Example

Bu proje, kullanıcıların kayıt olmasını, giriş yapmasını ve profil bilgilerini görüntülemesini sağlayan bir **C# Web API** projesi ile bu API’yi kullanarak kullanıcı dostu arayüzler sunan **ClomosyTrObject** projesinden oluşmaktadır. Projenin amacı, kullanıcı yönetimi işlemlerini güvenli bir şekilde gerçekleştiren, modern ve ölçeklenebilir bir çözüm sunmaktır.

## Proje Açıklaması

### 1. C# Web API

**C# Web API** projesi, kullanıcı verilerini güvenli bir şekilde yönetmek ve doğrulamak amacıyla çeşitli servisler sunmaktadır. Bu API, kullanıcı kaydını, oturum açma işlemlerini ve kullanıcı profil bilgilerini elde etmeyi sağlar. API, **ASP.NET Core** kullanılarak geliştirilmiş olup, kullanıcı oturum yönetiminde **JWT (JSON Web Token)** tabanlı kimlik doğrulama mekanizmasını kullanmaktadır.

#### Servisler

- **Kullanıcı Kaydı**: Yeni kullanıcıların sisteme kayıt olmasını sağlar. Bu işlem sırasında kullanıcı adı, şifre ve diğer profil bilgileri veritabanına kaydedilir. Şifreler, güvenlik açısından **hash** edilerek saklanır.
- **Kullanıcı Girişi**: Mevcut kullanıcıların sisteme giriş yapmasını sağlayan bir servistir. Kullanıcı adı ve şifrenin doğrulanmasının ardından, kullanıcıya özel bir **JWT Token** üretilir. Bu token, kullanıcının sonraki API isteklerinde kimliğini doğrulamak için kullanılır.
- **Kullanıcı Bilgilerini Getirme**: Giriş yapmış kullanıcıların, kendi profil bilgilerini görmesine olanak tanır. Bu işlem sırasında kullanıcının kimliği, JWT Token ile doğrulanır ve yalnızca giriş yapan kullanıcının bilgileri döndürülür.

#### Teknoloji ve Yapı

- **ASP.NET Core**: API'nin temel yapısını oluşturan framework.
- **Entity Framework Core**: Kullanıcı verilerinin saklanması ve yönetimi için kullanılan ORM aracı.
- **Microsoft SQL Server**: Kullanıcı veritabanının saklandığı sunucu.
- **JWT (JSON Web Token)**: Kimlik doğrulama mekanizması olarak kullanılır.

### 2. ClomosyTrObject Projesi

**ClomosyTrObject** projesi, C# Web API ile etkileşime giren ve kullanıcı arayüzü sağlayan bir projedir. Bu proje, Web API’ye gönderilen istekleri gerçekleştirerek kullanıcının oturum açmasını, kayıt olmasını ve profil bilgilerini görüntülemesini sağlayan sayfalar içerir. Proje, API ile tam entegre çalışır ve modern bir kullanıcı deneyimi sunar.

#### Sayfalar

- **Giriş Sayfası**: Kullanıcıların, kullanıcı adı ve şifre bilgilerini girerek sisteme giriş yapmasını sağlar. Giriş başarılı olduğunda, arka planda Web API'ye bir istek gönderilir ve doğrulama başarılı olursa, kullanıcının oturum bilgileri saklanır ve sisteme giriş yapılır.
- **Kayıt Sayfası**: Yeni kullanıcıların sisteme kayıt olabileceği bir sayfadır. Kullanıcı bilgileri bu sayfa üzerinden toplanır ve API'ye gönderilerek veritabanına kaydedilir.
- **Kullanıcı Bilgileri Sayfası**: Giriş yapmış olan kullanıcının profil bilgilerini görüntülediği bir sayfadır. Bu sayfa, kullanıcı bilgilerinin API'den alınarak kullanıcıya gösterilmesini sağlar.

#### Teknoloji ve Yapı

- **Clomosy**: TRObject yazılım dili ile RestApi kullanımı sağlanır
- **API Entegrasyonu**: API ile etkileşim sağlayarak kullanıcı bilgilerini doğrular ve gerekli sayfaları yükler.

### Projenin Amacı ve Katkıları

Bu projede, bir kullanıcı yönetim sisteminin nasıl oluşturulacağına ve API ile bir arayüzün nasıl entegre edileceğine dair kapsamlı bir çözüm sunulmaktadır. **C# Web API** projesi, güvenli bir kullanıcı yönetimi sağlar ve çeşitli oturum doğrulama işlemlerini desteklerken, **ClomosyTrObject** projesi de bu API'yi kullanarak kullanıcı dostu bir arayüz sunar. Bu yapı, modern web projelerinde kullanıcıların güvenli oturum açma, profil yönetimi gibi gereksinimlerine yönelik temel çözümler sunmaktadır.
