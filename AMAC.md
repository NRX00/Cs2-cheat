# CS2 Multi - Proje Amacı ve Detayları

## Bu Proje Ne Amaçla Yapılmış?

Bu proje **Counter-Strike 2** oyunu için geliştirilmiş bir **eğitim ve araştırma projesidir**. Projenin temel amacı oyun güvenliği, bellek manipülasyonu ve anti-cheat sistemleri konularında **eğitim sağlamaktır**.

## 🎯 Projenin Ana Amaçları

### 1. Eğitim Amaçlı
- **C# Programlama**: Sistem düzeyinde programlama tekniklerini öğretme
- **Bellek Yönetimi**: Oyun belleği okuma ve yazma işlemlerini anlama  
- **3D Grafik**: 3D koordinatları 2D ekran koordinatlarına dönüştürme
- **GUI Geliştirme**: ImGui kullanarak overlay arayüzleri oluşturma

### 2. Araştırma Amaçlı
- **Güvenlik Açıkları**: Oyun güvenlik zafiyetlerini tespit etme
- **Anti-Cheat Analizi**: Güvenlik sistemlerinin nasıl çalıştığını anlama
- **Siber Güvenlik**: Savunma mekanizmalarını geliştirme için saldırı yöntemlerini öğrenme

### 3. Teknik Eğitim
- **Process İletişimi**: Farklı süreçler arası veri alışverişi
- **Matematik**: Trigonometri ve 3D geometri uygulamaları
- **Rendering**: Gerçek zamanlı grafik çizimi teknikleri

## 🔧 Projenin Teknik Özellikleri

### ESP (Extra Sensory Perception) Sistemi
- **Rakip Görselleştirme**: Duvarların arkasındaki düşmanları gösterme
- **Sağlık Çubukları**: Rakiplerin can durumunu gösterme
- **Mesafe Gösterimi**: Rakiplere olan uzaklığı hesaplama
- **Takım Ayırımı**: Takım arkadaşları ve düşmanları farklı renklerle gösterme

### Aimbot Sistemi
- **Otomatik Nişan**: Hedeflere otomatik olarak yönlenme
- **Açı Hesaplama**: 3D uzayda hedef açılarını matematiksel olarak hesaplama
- **Hassasiyet Kontrolü**: Doğal görünüm için ayarlanabilir hassasiyet

### GUI Menü Sistemi  
- **Ayar Paneli**: Özellik değişkenlerini kontrol etme
- **Renk Seçici**: Görsel öğelerin renklerini özelleştirme
- **Açma/Kapama**: Her özellik için ayrı kontrol

## 📚 Eğitim Değeri

### Öğrenciler İçin
- **Sistem Programlama**: Alt seviye bellek erişimi
- **Grafik Programlama**: 3D matematik ve rendering
- **GUI Geliştirme**: Modern arayüz tasarımı
- **Güvenlik Bilinci**: Oyun güvenlik sistemlerini anlama

### Geliştiriciler İçin
- **Güvenlik Testleri**: Uygulamalarda güvenlik açıkları bulma
- **Anti-Cheat Geliştirme**: Koruma mekanizmalarını iyileştirme
- **Bellek Koruma**: Uygulamaları koruma teknikleri

### Siber Güvenlik Uzmanları İçin
- **Saldırı Vektörleri**: Farklı saldırı yöntemlerini anlama
- **Tespit Metodları**: Kötü amaçlı yazılım tespit teknikleri
- **Savunma Stratejileri**: Etkili koruma sistemleri geliştirme

## ⚠️ Önemli Uyarılar ve Sorumluluklar

### 🚫 Yapılmaması Gerekenler
- **Oyunda Kullanım**: Bu yazılımı gerçek oyunlarda kullanmak
- **Ticari Amaç**: Yazılımı satmak veya ticari amaçla dağıtmak
- **Haksız Rekabet**: Diğer oyuncular karşısında haksız avantaj sağlamak
- **Kural İhlali**: Steam, Valve veya oyun kurallarını ihlal etmek

### ✅ Kabul Edilebilir Kullanım
- **Akademik Araştırma**: Üniversite projeleri ve tezler
- **Eğitim Amaçlı**: Programlama ve güvenlik eğitimi
- **Güvenlik Testi**: Kendi uygulamalarınızda test
- **Anti-Cheat Geliştirme**: Koruma sistemleri için analiz

## 🛡️ Yasal ve Etik Konular

### Yasal Sorumluluk
- Bu yazılımın kullanımından doğan her türlü sorumluluk kullanıcıya aittir
- Oyun kurallarını ihlal etmek hesap yasaklanmasına neden olabilir
- Yerel yasaları ve kullanım şartlarını ihlal etmek yasal sonuçlar doğurabilir

### Etik Kurallar  
- **Adil Oyun**: Diğer oyuncuların deneyimini bozmamak
- **Eğitim Önceliği**: Bilgiyi eğitim amaçlı kullanmak
- **Zarar Vermeme**: Başkalarına zarar vermemek

## 🔬 Teknik Detaylar

### Kullanılan Teknolojiler
```
- C# (.NET 8.0)         - Ana programlama dili
- ClickableTransparentOverlay - Şeffaf pencere yönetimi
- ImGui.NET             - Kullanıcı arayüzü
- Swed64               - Bellek okuma/yazma
- Vortice.Mathematics   - 3D matematik işlemleri
```

### Kod Yapısı
```
Program.cs      - Ana uygulama mantığı
Entity.cs       - Oyuncu veri yapısı  
Offsets.cs      - Bellek adresleri
ViewMatrix.cs   - 3D-2D dönüşüm matrisi
```

## 🎓 Sonuç

Bu proje, oyun güvenliği ve bellek manipülasyonu konularında **kapsamlı bir eğitim kaynağı** olarak tasarlanmıştır. Amacı, gelecekteki güvenlik uzmanlarının ve yazılım geliştiricilerinin bu konularda bilgi sahibi olmalarını sağlamaktır.

**Unutmayın**: Bilgi güçtür, ancak bu güç sorumlu bir şekilde kullanılmalıdır. Bu projeyi yalnızca eğitim ve araştırma amaçlı kullanın.

---

**Eğitim ve araştırma için tasarlanmıştır. Kötüye kullanım kesinlikle tavsiye edilmez.**