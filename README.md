# 🎙️ C# WinForms Speech Recognizer

A Windows Forms desktop application developed in C# (.NET) that implements the native `System.Speech.Recognition` API. The application enables users to automate system keyboard shortcuts and commands using custom voice inputs.

---

## 🚀 Features

* **Voice Command Automation:** Maps custom spoken words to automated system keystrokes.
* **Modifier Key Support:** Seamlessly handles modifier keys including **Shift (+)**, **Ctrl (^)**, and **Alt (%)**.
* **Dynamic Form Mapping:** Automatically binds custom actions dynamically through a 5-row inputs form layout.
* **Safe Closure Recognition:** Includes a global `"cerrar"` voice command to prompt secure application exit safely.

---

## 🛠️ Requirements & Setup

1. **Operating System:** Windows (Required for native `System.Speech` framework support).
2. **Language Pack:** Ensure the **Spanish (es-ES)** speech recognition language pack is installed in your Windows settings.
3. **IDE:** Visual Studio 2022 (with .NET Desktop Development workload).

### Installation

1. Clone the repository:

```bash
   git clone [https://github.com/TU_USUARIO/csharp-speech-recognition-winforms.git](https://github.com/TU_USUARIO/csharp-speech-recognition-winforms.git)
```

2. Open the .slnx solution file in Visual Studio.

3. Restore dependencies (Ensure System.Speech assembly reference is enabled in project references).

4. Press F5 or click Start to run the application.

