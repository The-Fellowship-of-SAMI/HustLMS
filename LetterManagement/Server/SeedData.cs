using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server
{
    public class SeedData
    {
        public static async Task Seed(DataContext context)
        {
            if (!context.Students.Any())
            {
                var departments = new List<Department>
                {
                    new()
                    {   Id = new Guid(),
                        Name = "Phòng đào tạo",
                        ShortName="PDT"

                    },
                    new()
                    {   Id = new Guid(),
                        Name = "Viện toán ứng dụng và tin học",
                        ShortName="SAMI"
                    }
                };
                var managers = new List<Manager>()
                {
                    new()
                    {
                        Id = default,
                        Name = "Trần Thị A",
                        Description = "Phụ trách về vấn đề bảng điểm",
                        DateOfBirth = new DateTime(1976, 2, 3),
                        Email = "a.tranthi@hust.edu.vn",
                        PhoneNumber = "012345678",
                        Department = departments[1] // Sami
                    },
                    new()
                    {
                        Id = default,
                        Name = "Nguyễn Thị C",
                        Description = "Phụ trách về vấn chuyển sinh kĩ sư - thạc sĩ, cử nhân - thạc sĩ.",
                        DateOfBirth = new DateTime(1980, 8, 3),
                        Email = "c.nguyenthi@hust.edu.vn",
                        PhoneNumber = "00101010101",
                        Department = departments[0] // PDT
                    }
                };
                var students = new List<Student>
                {
                    new()
                    {Id = new Guid(),
                        Name = "Duc",
                        PhoneNumber = "0123456",
                        StudentId = 20195859,
                        Email = "duc.pa195859@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 9, 7),
                        School = departments.Single(x=>x.ShortName=="SAMI"),
                        SchoolYear = "K64",

                    },
                    new()
                    {Id = new Guid(),
                        Name = "Minh",
                        PhoneNumber = "123456",
                        StudentId = 20191234,
                        Email = "minh.nh191234@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 1, 1),
                        School = departments.Single(x=>x.ShortName=="SAMI"),
                        SchoolYear = "K64",

                    },
                    new()
                    {Id = new Guid(),
                        Name = "Hieu",
                        PhoneNumber = "0120102",
                        StudentId = 20190001,
                        Email = "hieu.nc190001@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 5, 6),
                        School = departments.Single(x=>x.ShortName=="SAMI"),
                        SchoolYear = "K64",

                    },
                };

                var LongTimeOffLetterGroupId = new Guid();
                var letterTemplates = new List<LetterTemplate>
                {
                    new()
                    {
                        Id = new Guid(),
                        Department = departments.Single(x=>x.ShortName == "PDT"),
                        Name = "Đơn xin nghỉ học dài hạn",
                        Receiver = @"BAN GIÁM HIỆU ĐẠI HỌC BÁCH KHOA HÀ NỘI, PHÒNG ĐÀO TẠO ĐẠI HỌC",
                        Description = "Sinh viên sẽ nhận Quyết định nghỉ học dài hạn tại Phòng Công tác chính trị & Công tác SV. Thời gian nhập học trở lại là trong vòng 4 tuần trước khi bắt đầu mỗi học kỳ để SV đủ thời gian đăng ký học tập.",
                        AdditionalFields = new List<TemplateAdditionalField>
                        {
                            new()
                            {
                                Id = new Guid(),
                                FieldName =
                                    "Tôi nộp đơn xin nghỉ học dài hạn từ (ghi ngày tháng năm bắt đầu nghỉ):",
                                FieldType = FieldTypes.Datetime

                            },
                            
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Lý do xin nghỉ học dài hạn (đánh dấu X vào một hoặc nhiều ô tương ứng và ghi chi tiết nếu cần):",
                                FieldType = FieldTypes.Checkbox
                            },
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Xin đi du học tự túc ngắn hạn (ghi rõ du học ở đâu, kèm theo bản copy Giấy mời du học/Giấy báo nhập trường):",
                                FieldType = FieldTypes.Text,
                                GroupFieldId = LongTimeOffLetterGroupId
                            },
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Dành thời gian ôn thi lại đại học (sẽ thi lại trường nào):",
                                FieldType = FieldTypes.Text,
                                GroupFieldId = LongTimeOffLetterGroupId

                            },
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Do điều kiện kinh tế có khó khăn (nêu cụ thể):",
                                FieldType = FieldTypes.Text,
                                GroupFieldId = LongTimeOffLetterGroupId
                            },
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Do sức khỏe không tốt (kèm hồ sơ bệnh án):",
                                FieldType = FieldTypes.Text,
                                GroupFieldId = LongTimeOffLetterGroupId
                            },
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Lý do khác:",
                                FieldType = FieldTypes.Text,
                                GroupFieldId = LongTimeOffLetterGroupId
                            },
                        },
                        Footer =
                            @"Tôi đã được nhà trường tư vấn kỹ trước khi nộp đơn xin nghỉ học dài hạn. 
                              Tôi hiểu rõ Qui chế đào tạo đại học hệ chính qui và tự chịu trách nhiệm 
                              về việc đảm bảo thời gian nghỉ học cho phép cũng như tổng thời gian
                              học tập tại trường theo quy định.",
                        ConfirmationsTemplate = new List<ConfirmationTemplate>
                        {
                            new ConfirmationTemplate()
                            {
                                Id = new Guid(),
                                Name="Ý kiến của Viện quản lý"
                                
                            }
                        }
                    },
                    new()
                    {
                        Id = new Guid(),
                        Department = departments[0],
                        Name = "Đơn xin đăng ký học chuyển tiếp từ cử nhân công nghệ lên kỹ sư",
                        Receiver = @"Ban giám hiệu ĐH Bách khoa Hà Nội, Phòng Đào tạo",
                        AdditionalFields = new List<TemplateAdditionalField>
                        {
                            new()
                            {
                                Id = new Guid(),
                                FieldName =
                                    "Tôi viết đơn này xin đăng ký học chuyển tiếp lên chương trình đào tạo kỹ sư ngành:",
                                FieldType = "string"

                            },
                            new()
                            {
                                Id = new Guid(),
                                FieldName = "Thời gian xin bắt đầu học tập theo chương trình đào tạo kỹ sư từ kỳ:",
                                FieldType = "string"
                            }
                        },
                        Footer =
                            "Tôi xin cam kết hoàn toàn chịu trách nhiệm về việc đăng ký học tập khi được xét cho phép học chuyển tiếp."
                    }
                };

                var letters = new List<Letter>()
                {
                    new()
                    {
                        CreatedAt = default,
                        ModifiedAt = default,
                        Id = default,
                        Template = letterTemplates[0],
                        Student = students.SingleOrDefault((x=>x.StudentId==20195902)),
                        Manager = null,
                        NoteToStudent = null,
                        ReceivedDate = null,
                        FinishedDate = null,
                        LetterAdditionalFields = null
                    },
                    new()
                    {
                        CreatedAt = DateTime.Today.AddDays(-5),
                        ModifiedAt = default,
                        Id = default,
                        Template = letterTemplates[0],
                        Student = students.SingleOrDefault(x=>x.StudentId==20195859),
                        Manager = managers[1],
                        NoteToStudent = null,
                        ReceivedDate = DateTime.Today.AddDays(1),
                        FinishedDate = null,
                        LetterAdditionalFields = null
                    },
                    new()
                    {
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now,
                        Id = default,
                        Template = letterTemplates[0],
                        Student = students.SingleOrDefault(x=>x.StudentId==20195859),
                        Manager = managers[1],
                        NoteToStudent = null,
                        ReceivedDate = DateTime.Today.AddDays(1),
                        FinishedDate = DateTime.Today.AddDays(3),
                        LetterAdditionalFields = null
                    }
                };


                await context.Students.AddRangeAsync(students);
                await context.Departments.AddRangeAsync(departments);
                await context.Manager.AddRangeAsync(managers);
                await context.LetterTemplates.AddRangeAsync(letterTemplates);
                await context.Letters.AddRangeAsync(letters);
                await context.SaveChangesAsync();
            }
        }
    }
}
