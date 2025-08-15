# CS2 Multi - Counter-Strike 2 Research Project

## Türkçe / Turkish

### Bu Proje Ne Amaçla Yapılmış?

Bu proje Counter-Strike 2 oyunu için geliştirilen bir **eğitim ve araştırma amaçlı** yazılımdır. Projenin ana amacı:

**🎓 Eğitim Amaçları:**
- Oyun bellek manipülasyonu tekniklerini öğrenme
- C# ile sistem düzeyinde programlama deneyimi kazanma
- ImGui kütüphanesi kullanarak overlay arayüzleri geliştirme
- Grafik rendering ve koordinat sistemleri üzerinde çalışma
- Memory offset'leri ve pointer manipülasyonu anlama

**🔬 Araştırma Amaçları:**
- Anti-cheat sistemlerinin nasıl çalıştığını anlama
- Oyun güvenlik açıklarını tespit etme metodları
- Siber güvenlik alanında farkındalık yaratma

**⚙️ Teknik Özellikler:**
- **ESP (Extra Sensory Perception)**: Rakip oyuncuları görselleştirme
- **Aimbot**: Otomatik nişan alma sistemi
- **Overlay Menu**: Ayarları değiştirmek için GUI arayüzü
- **Memory Reading/Writing**: Oyun belleği okuma ve yazma işlemleri

### ⚠️ ÖNEMLİ UYARILAR

- **Bu yazılım yalnızca eğitim ve araştırma amaçlıdır**
- **Oyunda kullanımı etik değildir ve oyun kurallarını ihlal eder**
- **Steam ve Valve'ın hizmet şartlarını ihlal eder**
- **VAC (Valve Anti-Cheat) yasağı ile sonuçlanabilir**
- **Bu yazılımı kullanmak sizin sorumluluğunuzdadır**

---

## English

### What Purpose Was This Project Made For?

This project is an **educational and research-oriented** software developed for Counter-Strike 2. The main purposes of this project are:

**🎓 Educational Purposes:**
- Learning game memory manipulation techniques
- Gaining system-level programming experience with C#
- Developing overlay interfaces using ImGui library
- Working with graphics rendering and coordinate systems
- Understanding memory offsets and pointer manipulation

**🔬 Research Purposes:**
- Understanding how anti-cheat systems work
- Methods for detecting game security vulnerabilities
- Creating awareness in cybersecurity field

**⚙️ Technical Features:**
- **ESP (Extra Sensory Perception)**: Visual highlighting of enemy players
- **Aimbot**: Automatic aiming system
- **Overlay Menu**: GUI interface for changing settings
- **Memory Reading/Writing**: Game memory access operations

### ⚠️ IMPORTANT WARNINGS

- **This software is for educational and research purposes only**
- **Using it in-game is unethical and violates game rules**
- **Violates Steam and Valve's terms of service**
- **May result in VAC (Valve Anti-Cheat) ban**
- **You are responsible for using this software**

## Technical Implementation

### Dependencies
- **ClickableTransparentOverlay**: For creating transparent overlay windows
- **ImGui.NET**: For user interface rendering
- **Swed64**: For external memory reading/writing
- **Vortice.Mathematics**: For mathematical operations

### Architecture
```
Program.cs          - Main application logic, ESP, Aimbot implementation
Entity.cs          - Player/enemy entity data structure
Offsets.cs         - Memory addresses for game data
ViewMatrix.cs      - 3D to 2D coordinate transformation
```

### Key Components
1. **Memory Access**: Uses external process memory reading to access CS2 game data
2. **ESP System**: Renders visual overlays showing enemy positions, health, distance
3. **Aimbot System**: Calculates angles and automatically aims at targets
4. **GUI Menu**: ImGui-based interface for configuration

## Educational Value

This project demonstrates:
- **Process Memory Management**: How external applications can access game memory
- **3D Graphics Programming**: World-to-screen coordinate transformations
- **UI Development**: Creating transparent overlays with ImGui
- **Game Hacking Techniques**: Understanding how cheats work to better defend against them

## Legal and Ethical Considerations

**For Educators and Researchers:**
- Use this code to understand security vulnerabilities
- Study anti-cheat detection methods
- Analyze memory protection techniques

**For Students:**
- Learn about system-level programming
- Understand game engine architecture
- Explore cybersecurity concepts

**⚖️ Disclaimer:**
This project is provided for educational purposes only. The authors do not encourage or support cheating in online games. Users are responsible for complying with all applicable laws and terms of service.

## Building the Project

1. Ensure .NET 8.0 SDK is installed
2. Restore NuGet packages: `dotnet restore`
3. Build the project: `dotnet build`
4. Run: `dotnet run` (Note: Requires CS2 to be running)

---

**Remember: Knowledge is power, but with great power comes great responsibility. Use this knowledge ethically and responsibly.**