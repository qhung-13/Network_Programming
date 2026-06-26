# UDM_08 — Lập trình ứng dụng Chat (GUI) via TCP

## Thông tin dự án
- **Project Code:** UDM_08
- **Project Name:** Lập trình ứng dụng Chat (GUI) via TCP
- **Môn học:** Lập trình Ứng dụng Mạng

## Thành viên nhóm
| Họ và tên             | MSSV         | GitHub             | Vai trò                      |
|-----------------------|--------------|--------------------|------------------------------|
| Trần Nguyễn Quốc Hùng | 068206007286 | @qhung-13          | TCP Core                     |
| Nguyễn Thị Ngọc Tuyến | 089306015808 | @ntuyen-26         | WinForms UI                  |
| Lê Thành Đạt          | 056206008999 | @thanhdathi        | Message Model + JSON         |
| Hoàng Vĩnh Phúc       | 079206047689 | @vinhphuc1607      | Logging + Báo cáo            |
| Phan Quang Huy        | 051206013587 | @Huycris206        | Settings + Slide             |
| Hà Vũ Như Ngọc        | 079306006753 | @ngochvn6753-stack | Emoji/Notification + Báo cáo |

## Proposal

### What we want to do
Xây dựng ứng dụng chat desktop real-time sử dụng giao thức TCP thuần,
không qua framework trung gian. Ứng dụng cho phép nhiều người dùng kết
nối đến một server chung, tham gia các phòng chat và nhắn tin theo thời
gian thực.

### What features we aim to complete
- Kết nối TCP giữa Server và nhiều Client đồng thời
- Đăng nhập bằng username (không cần password)
- Chat theo phòng (room) — tạo và tham gia phòng
- Hiển thị danh sách người dùng online
- Gửi/nhận tin nhắn real-time
- Hỗ trợ emoji trong tin nhắn
- Thông báo join/leave phòng
- Server log toàn bộ hoạt động ra file .txt
- Lưu cấu hình (IP, port, username) để tự động điền lần sau

### What stack we are using
- **Language:** C# / .NET 8
- **UI Framework:** WinForms
- **Networking:** TCP Socket (TcpListener, TcpClient, NetworkStream)
- **Concurrency:** Async/Await, Task
- **Data:** System.Text.Json
- **IDE:** Visual Studio 2022

### What will be achieved as final
Một ứng dụng desktop hoàn chỉnh gồm 2 program: ChatServer và ChatClient.
Server chạy độc lập, quản lý toàn bộ kết nối và phòng chat. Client cung
cấp giao diện WinForms để người dùng đăng nhập, chọn phòng và chat
real-time với nhiều người cùng lúc.

## Planning

### Phase 1 — Tuần 1 & 2 
- Thiết lập project structure, solution, git repo
- Hoàn thiện Message Model, User Model, Room Model
- TCP Server cơ bản: accept connection, nhận gửi message
- TCP Client cơ bản: kết nối server, gửi nhận message
- Thiết kế layout UI (Login form, Chat form, Server form)

### Phase 2 — Tuần 3 & 4
- Hoàn thiện room management (tạo phòng, join, leave)
- Hoàn thiện WinForms UI, kết nối với TCP logic
- Logging module: ghi log ra file .txt
- Settings module: lưu/đọc config JSON

### Phase 3 — Tuần 5 & 6
- Emoji + thông báo join/leave
- Test toàn bộ tính năng, fix bug
- Bắt đầu viết báo cáo DOCX
- Bắt đầu làm slide PPTX

### Phase 4 — Tuần 7 & 8
- Hoàn thiện báo cáo DOCX
- Hoàn thiện slide PPTX
- Quay video demo
- Polish UI, fix bug cuối
- Commit toàn bộ lên GitHub

### Tuần 9 — Buffer (dự phòng)
- Fix bug phát sinh
- Chuẩn bị thuyết trình
- Nộp bài

## Mô tả
Ứng dụng chat real-time sử dụng giao thức TCP, hỗ trợ nhiều người dùng
cùng lúc, phân chia theo phòng chat. Giao diện desktop xây dựng bằng
WinForms trên nền tảng .NET 8.

## Cấu trúc repo
- `Code/` — Source code C# (.NET 8, WinForms)
- `DOCX/` — Báo cáo Word
- `Extra/` — Ảnh demo, video, tài liệu tham khảo
- `PPTX/` — Slide thuyết trình

## Công nghệ sử dụng
- C# / .NET 8
- WinForms
- TCP Socket (TcpListener, TcpClient)
- Async/Await
- System.Text.Json

## Hướng dẫn chạy
1. Mở solution `ChatApp.sln` trong Visual Studio 2022
2. Chạy project `ChatServer` trước
3. Chạy một hoặc nhiều `ChatClient`
4. Nhập tên và chọn phòng để bắt đầu chat