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
                    { Id = new Guid(),
                        Name = "Phòng đào tạo",

                    },
                    new()
                    {Id = new Guid(),
                        Name = "Viện toán ứng dụng và tin học"
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
                        School = "SAMI",
                        SchoolYear = "K64",

                    },
                    new()
                    {Id = new Guid(),
                        Name = "Minh",
                        PhoneNumber = "123456",
                        StudentId = 20191234,
                        Email = "minh.nh191234@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 1, 1),
                        School = "SAMI",
                        SchoolYear = "K64",

                    },
                    new()
                    {Id = new Guid(),
                        Name = "Hieu",
                        PhoneNumber = "0120102",
                        StudentId = 20190001,
                        Email = "hieu.nc190001@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 5, 6),
                        School = "SAMI",
                        SchoolYear = "K64",

                    },
                };

                var letterTemplates = new List<LetterTemplate>
                {
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
