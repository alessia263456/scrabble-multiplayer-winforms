# 🎲 Scrabble în rețea

Aplicație desktop pentru jocul **Scrabble în limba română**, realizată în **C#**, folosind **Windows Forms** și o arhitectură **client–server**.

Jocul permite desfășurarea unei partide între **doi jucători**, mutările și starea jocului fiind sincronizate prin rețea. Logica principală a jocului, validarea mutărilor și calculul scorului sunt gestionate de server.

![Gameplay](images/gameplay.png)

## ✨ Funcționalități

- 👥 Joc în rețea pentru doi jucători
- 👤 Introducerea numelui jucătorului
- 🎯 Tablă de joc 15 × 15
- 🧩 Distribuirea aleatorie a pieselor
- 🖱️ Plasarea pieselor prin **drag & drop**
- ↩️ Funcție **Undo** pentru mutarea curentă
- ✅ Validarea mutărilor conform regulilor Scrabble
- 📖 Verificarea cuvintelor folosind un dicționar în limba română
- 💯 Calcularea automată a scorului și aplicarea pătratelor bonus
- 🔄 Gestionarea rândului jucătorilor
- 🌐 Comunicare client–server prin TCP
- 🔄 Sincronizarea tablei, scorurilor și pieselor între jucători
- 🏆 Detectarea rezultatului final și tratarea deconectării adversarului

## 🛠️ Tehnologii

- **C#**
- **.NET Framework**
- **Windows Forms**
- **TCP / Sockets**
- **Microsoft Visual Studio**

## 🏗️ Structura proiectului

Proiectul este împărțit în două componente:

- **Client** – gestionează interfața grafică și comunicarea cu serverul.
- **Server** – gestionează logica jocului, validarea mutărilor, calculul scorului și sincronizarea stării jocului.

Printre clasele principale se numără `Joc`, `Tabla_joc`, `Jucator`, `Piesa`, `Mutare`, `Sac_piese`, `Suport_piese` și `Dicționar`.

## 🚀 Rulare

1. Deschide `Scrabble.sln` în **Visual Studio**.
2. Pornește aplicația **server**.
3. Pornește aplicația **client** și conectează-te la server folosind adresa IP.
4. Introdu numele jucătorului.
5. Începe partida.

> Pentru validarea cuvintelor, fișierul `Dictionar.txt` trebuie să fie prezent în directorul aplicației.

## 🔮 Dezvoltări viitoare

Versiunea actuală este funcțională pentru doi jucători. Printre posibilele dezvoltări se numără:

- 🃏 implementarea pieselor Joker;
- 👥 suport pentru mai mulți jucători;
- 🎨 îmbunătățirea interfeței grafice;
- ✨ adăugarea unor animații și efecte vizuale.

## 👩‍💻 Autor

**alessia263456**

Proiect realizat pentru disciplina **Programare Orientată pe Obiecte**.
