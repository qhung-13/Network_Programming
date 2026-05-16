# UDM_08 - Lập trình ứng dụng Chat (GUI) via TCP

## Thông tin dự án
- **Project code:** UDM_08
- **Project name:** Lập trình ứng dụng Chat (GUI) via TCP
- **Môn học:** Lập trình mạng

## Thành viên nhóm
| Họ và tên             | MSSV         | Vai trò
| Trần Nguyễn Quốc Hùng | 068206007286 | TCP Core — TcpListener, TcpClient, async, room management, message routing
| Nguyễn Thị Ngọc Tuyến	| 089306015808 | Toàn bộ WinForms UI — Server form + Client form + Login form
| Lê Thành Đạt          | 056206008999 | Message Model + JSON Protocol — class Message, serialize/deserialize
| Hoàng Vĩnh Phúc       | 079206047689 | Báo cáo DOCX + code phần logging — ghi log ra file .txt
| Phan Quang Huy        | 051206013587 | Slide PPTX + code phần settings — lưu/đọc config (IP, port, username)

## Mô tả
Ứng dụng chat real-time sử dụng giao thức TCP, hỗ trợ nhiều người dùng cùng lúc, phân chia theo phòng chat. Gia diện desktop xây dựng bằng WinForms trên nền tảng .NET 8.

## Tính năng
- Kết nối TCP giữ Server và nhiều Client
- Chat theo phòng (room)
- Hiện thị danh sách người dùng online
- Gửi/nhận tin nhắn real-time
- Server log toàn bộ hoạt động

## Cấu trúc repo
- `Code/` - Source code C# (.NET 8, WinForms)
- `DOCX/` - Báo cáo word
- `Extra` - Ảnh demo, video, tài liệu tham khảo
- `PPTX` - Slide thuyết trình

## Công nghệ sử dụng
- C# / .NET 8
- WinForms
- TCP Socket (TcpListener, TcpClient)
- Async/Await
- System.Text.Json

## Hướng dẫn chạy
1. Mở solution trong Visual Studio 2022
2. Chạy project `ChatServer` trước
3. Chạy một hoặc nhiều `ChatClient`
4. Nhập tên và chọn phòng để bắt đầu chat