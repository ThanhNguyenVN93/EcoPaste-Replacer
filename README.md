# EcoPaste Replacer

A small Windows utility that replaces the built-in Clipboard History panel (<kbd>Win</kbd>+<kbd>V</kbd>) with [EcoPaste](https://github.com/EcoPasteHub/EcoPaste), a free and open-source clipboard manager.

Requires Windows 10 1809+ and administrator rights.

## What it does

Running the app performs 6 steps:

1. Disables the built-in Windows Clipboard History via the registry.
2. Restarts `explorer.exe` so the change takes effect immediately.
3. Checks whether EcoPaste is already installed.
4. If not, installs it — via `winget` when available, otherwise downloads the
   latest release directly from GitHub.
5. Closes EcoPaste (if running) before touching its config, so it doesn't
   overwrite our changes on exit.
6. Applies an opinionated `settings.json` config, launches EcoPaste, and
   enables auto-start on login.

## Download

Grab the latest build from the [Releases](../../releases) page and run
`Eco Paste Replacer.exe`. Windows will prompt for administrator elevation —
that's expected, the app needs it to change system-wide registry policy.

Requires .NET Framework 4.7.2 or later, which ships in-box with Windows 10
1809+. On an older or stripped-down Windows install where it's missing, the
app offers to silently download and install it (via Microsoft's official
installer) before restarting itself, instead of crashing.

## Building from source

Requires the .NET Framework 4.7.2 targeting pack (Visual Studio 2019+ or the
Build Tools) and MSBuild:

```
msbuild frm_ecopaste.csproj /t:Restore
msbuild frm_ecopaste.csproj /t:Build
```

## Known limitations

- The `winget` install path is well-tested; the direct-GitHub-download
  fallback (used when `winget` isn't available on the machine) assumes the
  installer accepts a silent `/S` flag and hasn't been verified on every
  Windows build.
- No checksum/signature verification is performed on the fallback download
  path (the `winget` path already verifies package integrity on its own).

## License

[MIT](LICENSE)

---

# EcoPaste Replacer (Tiếng Việt)

Công cụ nhỏ cho Windows, thay thế bảng Clipboard History mặc định
(<kbd>Win</kbd>+<kbd>V</kbd>) bằng [EcoPaste](https://github.com/EcoPasteHub/EcoPaste) —
một trình quản lý clipboard mã nguồn mở, miễn phí.

Yêu cầu Windows 10 1809 trở lên và quyền quản trị (admin).

## Công cụ làm gì

Khi chạy, app thực hiện 6 bước:

1. Tắt Clipboard History mặc định của Windows qua registry.
2. Restart `explorer.exe` để áp dụng thay đổi ngay lập tức.
3. Kiểm tra EcoPaste đã được cài đặt chưa.
4. Nếu chưa, cài đặt — ưu tiên qua `winget` nếu máy có sẵn, nếu không sẽ tải
   bản mới nhất trực tiếp từ GitHub.
5. Đóng EcoPaste (nếu đang chạy) trước khi đụng vào file config, để tránh bị
   app tự ghi đè lại lúc thoát.
6. Áp dụng cấu hình `settings.json` đã tối ưu sẵn, khởi chạy EcoPaste, và bật
   tự khởi động cùng Windows.

## Tải về

Lấy bản mới nhất ở trang [Releases](../../releases) và chạy
`Eco Paste Replacer.exe`. Windows sẽ hỏi quyền admin — đây là điều bình thường,
app cần quyền này để thay đổi registry policy toàn hệ thống.

Yêu cầu .NET Framework 4.7.2 trở lên, vốn có sẵn trên Windows 10 1809+. Nếu
máy cũ hoặc bản Windows tối giản chưa có, app sẽ hỏi và tự tải + cài đặt âm
thầm (dùng installer chính thức của Microsoft) rồi tự khởi động lại, thay vì
bị crash.

## Đóng góp / ủng hộ

Nếu công cụ này hữu ích, bạn có thể ủng hộ tác giả qua
[ko-fi.com/thanhnguyen150993](https://ko-fi.com/thanhnguyen150993).

## Giấy phép

[MIT](LICENSE)
