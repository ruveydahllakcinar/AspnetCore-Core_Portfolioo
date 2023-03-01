# Core Portfloio Project

![cvtemplate](Core_Portfolio/wwwroot/CvTemplate/images/coreportfolio.gif)

Cv ile ilgili web sitesi geliştirdim. Bu web sitesinde katmanlı mimari kullandım. N katmanlı mimari kullandım.

## Projede Kullanılan Katmanlar

* Business Layer
* Presentation Layer 
* Entitiy Layer
* Data access Layer

Bu katmanların içerisinde klasörler oluşturup soyut ve somut classlarımı oluşturdum. Soyut classlar için Abstract somut classlar için Concrete adında klasörler oluşturdum.
Veri tabanı olaran MsSql kullandım.

## Projede Kullanılan Teknolojiler

* Asp.net Core 5.0
*Entity Freamwork Core
*Entity Freamwork Tools
*Entity Freamwork Design
*Entity Freamwork Sql Server
* API
* Ajax
* Fluent Validation
* JSON
* ASP.NET Core Identity
* Areas
* Rolleme

## Project Setup
* First you need to install.

* You must select the ASP.NET Web Application (.NET Framework) option and select the version. Ins. I developed the project with version 4.6.1.

* After choosing your project name and version, a screen comes up where you can choose how to develop the application in the next step. Since we will use MVC, we choose the MVC option.

* Check MySQL as datastore. I created my classes in Model. I submitted this to the database.

## What is included in the project?

* Projem 3 farklı sayfadan oluşmaktadır. Bu sayfalar cv sitemin göründüğü Home page, adminin siteyi yönetebilmesi, ekleme,silme ve güncelleme gibi işlemlerini geliştirebilmesi için Admin paneli ve son olarak kullanıcıların için bir sayfa oluşturdum. Bu sayfada ise gelen bildirimleri, onlara özel yolladığım mesajları yada üyelerin bana özelden mesaj yazabileceği alanlar bulunmaktadır.

* İlk olarak anasayfamda görülecek olan controllerları oluşturdum. Bu controllerlar içine temel CRUD işlemlerini yazdım ve buna ek oalrak kendimde filtrelemeye ihtiyaç duyduğum yerlerde özel interfaceler oluşturdum.

* Projem çok dağınık ve kirli durmaması için Login, Register, kullanıcıların sayfaları ve admin sayfalarını Areas alanlarında oluşturdum.

* ASP.NET Core 5.0 ile gelen yeni güncellemlerden birisi olan View Components yapısını bu projemde bol bol kullandım. Bu sayede partial view kullanımını azaltmış olup controllera yüklenen yükü ve maliyeti azaltmayı hedefledim.

* Bu projemde görsel ekleme alanlarını static değil dinamik bir şekilde oluşturdum böylelikle örneğin, profil fotoğrafınızı değiştirdikten sonra arayüzdeki değişikliği görebileceğiniz bir alan bulunmaktadır. Değişen görseller klasörde tutulmaktadır.

![Photo Controller](Core_Portfolio/wwwroot/CvTemplate/images/photocontroller.PNG)

---

![Photo View](Core_Portfolio/wwwroot/CvTemplate/images/photoview.PNG)

---

![Photo View](Core_Portfolio/wwwroot/CvTemplate/images/photochanges.gif)


* Kullanıcıların bana mesaj yollayabileceği benimde  onlara özelden mesajlar yollayabileceğim bir alan geliştirdim. 
    - User kayıtlarını Identity ile tuttuğum için isme göre verileri getirdim.
    - Alıcı ve gönderici arasında bağ kurarak üyelerle iletişim kurabileceğim bir alan geliştirdim.

![Photo View](Core_Portfolio/wwwroot/CvTemplate/images/messagecontroller.gif)


* Bir proje için olmazsa olmaz admin paneli bu panel benim birçok işlemi rahatlıkla yapabileceğim, yürütebileceğim bir alan olarak tasarladım. Projeleri ekleyip silmeden tutun birçok alanı buradan yürütebilmekteyim.

![Dashboard](Core_Portfolio/wwwroot/CvTemplate/images/dashboard.gif)


* Experience alanı için AJAX yapısı kullandım. Bu sayede sayfayı daha hızlı güncelleyebilen, yüklenmesini sağlayan bir alan oluşturmuş oldum.

![Dashboard](Core_Portfolio/wwwroot/CvTemplate/images/ajax.gif)

* Birden fazla modeller kullanmaya başladığım için karışıklığı önlemek adına Data Transfer Object (DTO) layer kullandım. Bu sayede modelleri daha temiz ve daha açıklayıcı olmuş oldu. 

* Bu bir Cv sitesi olduğu için aslında kullanıcılar için bir sayfanın bulunmasını sonradan profesyonel durmayacağını düşündüm ve bu yüzden kaldırdım. Bunu yaparken de rolleme kullandım. Yani şuan da ben tüm sayfalara uaşabiliyorken erişimi olmayan bir kullancıı o sayfaya erişemeeycektir. Erişmek sitediğinde ise 401 hatası alacaktır.

![Dashboard](Core_Portfolio/wwwroot/CvTemplate/images/401error.PNG)

* Hatalı bir sayfaya gidildiğinde ise 404 hatası ile karşılaşacakalrı bir sayfa tasarladım ve startup.cs dosyasında gerekli parametreleri yazdım. 

![Dashboard](Core_Portfolio/wwwroot/CvTemplate/images/404error.PNG.PNG)
