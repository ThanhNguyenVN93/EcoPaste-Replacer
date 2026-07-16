## EcoPaste Replacer v1.0.0

A small Windows utility that swaps the built-in Clipboard History panel
(Win+V) for [EcoPaste](https://github.com/EcoPasteHub/EcoPaste), a free and
open-source clipboard manager — in one click.

### ✨ Features

- Disables Windows' built-in Clipboard History and restarts Explorer so the
  change applies immediately.
- Detects an existing EcoPaste install automatically.
- Installs EcoPaste via `winget` when available (falls back to downloading
  the latest release directly from GitHub otherwise).
- Applies an opinionated, ready-to-use `settings.json` config.
- Launches EcoPaste and enables auto-start on login.
- System tray icon, dark UI, optional feedback form and support links built in.

### Requirements

- Windows 10 1809 or later (64-bit)
- Administrator rights (the app self-elevates via UAC)

### Download

Download `Eco Paste Replacer.exe` below and run it. Windows will prompt for
administrator elevation — that's expected.

### Known limitations

- The direct-GitHub-download fallback path (used only when `winget` isn't
  available on the machine) assumes the EcoPaste installer accepts a silent
  `/S` flag; this hasn't been verified on every Windows build.
- No checksum/signature verification on that fallback path (the `winget`
  path already verifies package integrity itself).

### Feedback

Found a bug or have a suggestion? [Fill out this short form](https://forms.gle/HJYPERBgk8Uyya1RA).

If this tool saved you some time, consider supporting the project on
[Ko-fi](https://ko-fi.com/thanhnguyen150993). ❤️
