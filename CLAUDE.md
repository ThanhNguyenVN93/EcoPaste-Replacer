# EcoPaste Replacer

## Mục đích
Tool Windows thay thế Windows Clipboard History (Win+V) mặc định bằng EcoPaste.
Chạy trên Win10 1809+, yêu cầu quyền admin.

## Stack
- .NET Framework 4.7.2 (WinForms) — target vì Win10 1809+ có sẵn runtime này,
  không cần cài thêm gì cho người dùng cuối
- UI: Guna.UI2.WinForms (đã dùng ở project HIS Uninstaller Tool)
- app.manifest: requireAdministrator, elevate 1 lần khi mở app

## Luồng xử lý (6 bước, xem MainForm.RunPipelineAsync)
1. Khóa Windows V: set registry HKCU\Software\Microsoft\Clipboard (EnableClipboardHistory=0)
   + HKLM\SOFTWARE\Policies\Microsoft\Windows\System (AllowClipboardHistory=0)
2. Restart explorer.exe để áp dụng ngay (Win+V panel host trong explorer.exe từ 1809)
3. Check EcoPaste đã cài chưa — dò %LOCALAPPDATA%\com.ayangweb.eco-paste\*\config\settings.json
4. Nếu chưa cài: ưu tiên `winget install --id EcoPasteHub.EcoPaste -e --silent` (tự verify hash,
   tự silent, đăng ký đàng hoàng vào registry Uninstall). Nếu máy không có winget, fallback tải
   bản mới nhất qua GitHub Releases API (không hardcode URL/version) rồi tự chạy installer /S
5. Kill process eco-paste.exe TRƯỚC KHI ghi đè settings.json (app tự flush config lúc thoát,
   nếu không kill trước sẽ mất config tối ưu)
6. Ghi đè settings.json (embedded resource), fallback takeown/icacls nếu bị khóa quyền,
   rồi launch + set Run key để auto-start

## Quy ước code
- Mỗi bước là 1 helper riêng trong Helpers/ (RegistryHelper, ExplorerHelper,
  ProcessHelper, EcoPasteInstaller) — không gộp logic vào MainForm
- Không shell ra powershell.exe cho registry — dùng thẳng Microsoft.Win32.Registry
- Path cài đặt EcoPaste không hardcode — dò registry Uninstall key trước
  (FindEcoPasteExePath), fallback đoán vài path phổ biến nếu không có trong registry

## Việc còn TODO
- Máy Win10 1809 base (chưa update) có thể không có sẵn winget — cần test path fallback
  GitHub Releases API thực tế trên máy như vậy
- Verify checksum/signature installer khi rơi vào nhánh fallback GitHub (nhánh winget đã tự
  verify hash nên không cần)
- Xác nhận cờ silent-install /S thật của installer EcoPaste ở nhánh fallback (đang giả định
  kiểu NSIS dựa theo tên asset *_x64-setup.exe, chưa test thực tế)
