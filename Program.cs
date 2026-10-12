using System;
using EduHub.Ch01.Domain;

// Thiết lập mã hóa hiển thị tiếng Việt chuẩn trên Console
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Hằng số trang trí giao diện xuất ra màn hình
const string HeaderBorder = "**********************************************************";
const string SectionDivider = "----------------------------------------------------------";

Console.WriteLine(HeaderBorder);
Console.WriteLine("       HỆ THỐNG EDUHUB - CHƯƠNG TRÌNH CONSOLE DEMO V2    ");
Console.WriteLine(HeaderBorder);
Console.WriteLine();

try
{
    // BƯỚC 1: Tạo CLB "Tech Club" với mô tả phù hợp
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 1: KHỞI TẠO CÂU LẠC BỘ (TECH CLUB)");
    Console.WriteLine(SectionDivider);
    var techClub = Club.Create("Tech Club", "Nơi hội tụ các sinh viên đam mê công nghệ và lập trình");
    Console.WriteLine($"+ Tên CLB     : {techClub.Name}");
    Console.WriteLine($"+ Mô tả       : {techClub.Description}");
    Console.WriteLine($"+ Ngày tạo    : {techClub.CreatedAt:yyyy-MM-dd HH:mm:ss}");
    Console.WriteLine();

    // BƯỚC 2: Thêm 3 thành viên vào CLB (dữ liệu mẫu tự tạo)
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 2: THÊM 3 THÀNH VIÊN VÀO CLB");
    Console.WriteLine(SectionDivider);
    var member1 = Member.Create("Hoàng Quốc Bảo", "bao.hq@student.dthu.edu.vn", "B2300101");
    var member2 = Member.Create("Nguyễn Thị Ngọc Hân", "han.ntn@student.dthu.edu.vn", "B2300102");
    var member3 = Member.Create("Phạm Gia Huy", "huy.pg@student.dthu.edu.vn", "B2300103");

    techClub.AddMember(member1);
    techClub.AddMember(member2);
    techClub.AddMember(member3);

    Console.WriteLine($"+ Đã tiếp nhận thành công 3 thành viên vào '{techClub.Name}':");
    Console.WriteLine($"  1. {member1.Name} - MSSV: {member1.StudentCode} ({member1.Email})");
    Console.WriteLine($"  2. {member2.Name} - MSSV: {member2.StudentCode} ({member2.Email})");
    Console.WriteLine($"  3. {member3.Name} - MSSV: {member3.StudentCode} ({member3.Email})");
    Console.WriteLine($"+ Tổng số thành viên hiện tại: {techClub.MemberCount()}");
    Console.WriteLine();

    // BƯỚC 3: Tạo 1 sự kiện cho CLB (Workshop AI, capacity = 50)
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 3: TỔ CHỨC SỰ KIỆN CHO CLB");
    Console.WriteLine(SectionDivider);
    var eventDate = DateTime.Now.AddDays(7);
    var workshopEvent = Event.Create(techClub.Id, "Workshop AI: Từ cơ bản đến ứng dụng thực tế", eventDate, 50, true);

    Console.WriteLine($"+ Tên sự kiện : {workshopEvent.Title}");
    Console.WriteLine($"+ Thời gian   : {workshopEvent.Date:yyyy-MM-dd HH:mm}");
    Console.WriteLine($"+ Sức chứa    : {workshopEvent.Capacity} người");
    Console.WriteLine($"+ Hình thức   : {(workshopEvent.IsOnline ? "Trực tuyến (Online)" : "Trực tiếp")}");
    Console.WriteLine();

    // BƯỚC 4: 2 thành viên đăng ký tham gia sự kiện -> Status = "Pending" -> gọi Confirm()
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 4: ĐĂNG KÝ VÀ PHÊ DUYỆT THAM GIA SỰ KIỆN");
    Console.WriteLine(SectionDivider);
    var reg1 = Registration.Create(member1.Id, workshopEvent.Id);
    var reg2 = Registration.Create(member2.Id, workshopEvent.Id);

    Console.WriteLine($"- Thành viên {member1.Name} đăng ký. Trạng thái ban đầu: {reg1.Status}");
    Console.WriteLine($"- Thành viên {member2.Name} đăng ký. Trạng thái ban đầu: {reg2.Status}");

    // Gọi phương thức Confirm()
    reg1.Confirm();
    reg2.Confirm();
    Console.WriteLine($"> Sau khi gọi phương thức Confirm() để phê duyệt:");
    Console.WriteLine($"  + Phiếu của {member1.Name}: {reg1.Status}");
    Console.WriteLine($"  + Phiếu của {member2.Name}: {reg2.Status}");
    Console.WriteLine();

    // BƯỚC 5: 1 thành viên thực hiện check-in -> tạo CheckIn record
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 5: THỰC HIỆN CHECK-IN ĐIỂM DANH SỰ KIỆN");
    Console.WriteLine(SectionDivider);
    var checkInRecord = CheckIn.Create(reg1.Id, CheckInMethodType.QRCode);
    Console.WriteLine($"+ Thành viên {member1.Name} thực hiện quét mã check-in thành công.");
    Console.WriteLine($"  Chi tiết bản ghi: {checkInRecord.Summary()}");
    Console.WriteLine();

    // BƯỚC 6: In báo cáo tham dự: số đăng ký, số check-in, danh sách tên
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 6: XUẤT BÁO CÁO THAM DỰ SỰ KIỆN");
    Console.WriteLine(SectionDivider);
    Console.WriteLine($"[BÁO CÁO TỔNG HỢP] Sự kiện: {workshopEvent.Title}");
    Console.WriteLine($"----------------------------------------------------------");
    Console.WriteLine($"  - Tổng số lượng đăng ký  : 2");
    Console.WriteLine($"  - Tổng số lượng check-in : 1");
    Console.WriteLine($"  - Danh sách tên thành viên tham dự:");
    Console.WriteLine($"    1. {member1.Name} (MSSV: {member1.StudentCode}) - Đã check-in");
    Console.WriteLine($"    2. {member2.Name} (MSSV: {member2.StudentCode}) - Đã xác nhận");
    Console.WriteLine();

    // BƯỚC 7: Thử một thao tác vi phạm luật nghiệp vụ (Confirm() phiếu đã huỷ) và bắt InvalidOperationException
    Console.WriteLine(SectionDivider);
    Console.WriteLine("BƯỚC 7: KIỂM THỬ NGOẠI LỆ (VI PHẠM QUY TẮC NGHIỆP VỤ)");
    Console.WriteLine(SectionDivider);
    var reg3 = Registration.Create(member3.Id, workshopEvent.Id);
    reg3.Cancel();
    Console.WriteLine($"- Thành viên {member3.Name} đã hủy phiếu đăng ký. Trạng thái hiện tại: {reg3.Status}");
    Console.WriteLine($"- Cố tình gọi phương thức Confirm() trên phiếu đã bị hủy này...");

    reg3.Confirm(); // Dòng này sẽ kích hoạt ngoại lệ InvalidOperationException
}
catch (InvalidOperationException ex)
{
    Console.WriteLine();
    Console.WriteLine($"[BẮT NGOẠI LỆ NGHIỆP VỤ THÀNH CÔNG]: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine();
    Console.WriteLine($"[LỖI HỆ THỐNG]: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine(HeaderBorder);
Console.WriteLine("             CHƯƠNG TRÌNH DEMO HOÀN TẤT THÀNH CÔNG         ");
Console.WriteLine(HeaderBorder);