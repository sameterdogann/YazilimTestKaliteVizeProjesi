# 🛫 E-Ticaret Yazılım Test ve Kalite Analizi Projesi

Bu proje, bir **e-ticaret sisteminin** temel işlevlerini (**Ürün Yönetimi**, **Sepet İşlemleri** ve **Sipariş Süreçleri**) içeren ve bu süreçlerin farklı test teknikleriyle (**White Box**, **Black Box**, **Gray Box**, **Integration**) kapsamlı bir şekilde analiz edildiği bir **yazılım test otomasyonu** çalışmasıdır.

---

## 👨‍💻 Proje Sahibi

- **Ad Soyad:** Samet ERDOĞAN  
- **Öğrenci Numarası:** 20230108039  
- **Bölüm:** Bilgisayar Programcılığı  
- **Ders Adı:** Yazılım Test ve Kalitesi  
- **Ders Kodu:** MTH2005  
- **Öğretim Görevlisi:** Emrah SARIÇİÇEK  
- **Teslim Tarihi:** 28/04/2026  

---

## 📌 Proje Amacı

Bu çalışma, **NUnit** test framework'ü kullanılarak geliştirilmiştir.  
Projenin ana hedefi, yazılım geliştirme sürecinde karşılaşılabilecek **mantıksal hataların (bug)** test senaryoları aracılığıyla nasıl tespit edildiğini ve raporlandığını göstermektir.

> **Önemli:** Sistemde **bilerek bırakılan kritik hatalar**, otomatize edilmiş testler ile başarıyla yakalanmıştır.

---

## 🧪 Test Senaryoları (12 Adet)

Sistem toplamda **12 adet senaryo** ile test edilmiştir.

### 1. White Box Testleri (Kod Yapısı Odaklı)

- **T1 - Stok Güncelleme:** `DecreaseStock` metodunun değeri doğru düşürüp düşürmediği.  
- **T2 - Ürün Kaldırma:** Ürünün sepet listesinden başarıyla silinip silinmediği.  
- **T3 - Kargo Mantığı (Kritik Hata):** Kargo ücreti hesaplanırken toplama yerine çıkarma yapılması. **→ ❌ FAIL**

### 2. Black Box Testleri (Fonksiyonel Odaklı)

- **T4 - Sepete Ekleme:** Ürün eklendiğinde listenin sayısının artması.  
- **T5 - Ödeme Sınır Değeri (Kritik Hata):** Ödeme tutarı sepet tutarına tam eşit olduğunda sistemin reddetmesi. **→ ❌ FAIL**  
- **T6 - Veri Doğrulama:** Ürün isimlerinin `null` veya boş gelme durumu.

### 3. Gray Box Testleri (Durum ve Mantık Odaklı)

- **T7 - Durum Değişimi:** Sipariş sonrası sepet durumunun `Completed` olması.  
- **T8 - Sınır Değer Analizi:** Stok = 1 iken yapılan son ürün alımı kontrolü.  
- **T9 - İndirim Mantığı:** 100 TL üzerindeki alışverişlerde %10 indirimin doğrulanması.

### 4. Integration Testleri (Bütünleşik Akış)

- **T10 - Tam Akış:** Ürün seçimi, sepete ekleme ve ödeme sürecinin başarısı.  
- **T11 - Birikimli Hata (Kritik Hata):** Çoklu ürünlerde kargo hatasının toplam maliyeti bozması. **→ ❌ FAIL**  
- **T12 - Boş Sepet Kontrolü:** Sepette ürün yokken işlemlerin durumu.

---

## 🛠 Tespit Edilen Yazılım Hataları (Bug Report)

Yapılan testler sonucunda sistemde şu **kritik hatalar** raporlanmıştır:

### 🔴 Lojistik/Kargo Hatası (`Cart.cs`)

> **Bulgu:** `CalculateTotal` metodunda kargo ücreti (+25 TL) eklenmek yerine yanlış bir operatör kullanımı ile **toplamdan çıkarılmaktadır**.

### 🔴 Ödeme Validasyon Hatası (`OrderService.cs`)

> **Bulgu:** Ödeme kontrolünde `>=` (Büyük Eşit) yerine `>` (Büyük) operatörü kullanıldığı için kullanıcı sepet tutarının **kuruşu kuruşuna aynısını ödediğinde** sistem "Eksik Ödeme" hatası fırlatmaktadır.

---

## ⚙️ Gereksinimler ve Çalıştırma

### Gereksinimler

- **Platform:** .NET 8.0 / 9.0  
- **Test Framework:** NUnit 3.x / 4.x  
- **IDE:** Visual Studio 2022 veya daha yeni versiyon

### 🚀 Çalıştırma Adımları

1. Projeyi IDE'niz ile açın.  
2. **Test Explorer** üzerinden tüm testleri çalıştırarak **9 başarılı, 3 başarısız** sonucu gözlemleyin.  
3. Konsol çıktısı için projenin `ECommerceApp.sln` dosyasını çalıştırarak görsel analiz raporuna ulaşın.
