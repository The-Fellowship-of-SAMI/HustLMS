using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
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
                    {
                        Name = "Phòng đào tạo",

                    },
                    new()
                    {
                        Name = "Viện toán ứng dụng và tin học"
                    }
                };
                var students = new List<Student>
                {
                    new()
                    {
                        Name = "Duc",
                        PhoneNumber = "0123456",
                        StudentId = 20195859,
                        Email = "duc.pa195859@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 9, 7),
                        School = "SAMI",
                        SchoolYear = "K64",

                    },
                    new()
                    {
                        Name = "Minh",
                        PhoneNumber = "123456",
                        StudentId = 20191234,
                        Email = "minh.nh191234@sis.hust.edu.vn",
                        DateOfBirth = new DateTime(2001, 1, 1),
                        School = "SAMI",
                        SchoolYear = "K64",

                    },
                    new()
                    {
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
                        Id = 1,
                        Department = departments[0],
                        Name = "Đơn xin đăng ký học chuyển tiếp từ cử nhân công nghệ lên kỹ sư",
                        Receiver = @"
                                  Kính gửi: - Ban giám hiệu ĐH Bách khoa Hà Nội
                                            - Phòng Đào tạo
                                    ",
                        AdditionalFields = new List<TemplateAdditionalField>
                        {
                            new()
                            {
                                FieldName =
                                    "Tôi viết đơn này xin đăng ký học chuyển tiếp lên chương trình đào tạo kỹ sư ngành:",
                                FieldType = "string"

                            },
                            new()
                            {
                                FieldName = "Thời gian xin bắt đầu học tập theo chương trình đào tạo kỹ sư từ kỳ:",
                                FieldType = "string"
                            }
                        },
                        Footer =
                            "Tôi xin cam kết hoàn toàn chịu trách nhiệm về việc đăng ký học tập khi được xét cho phép học chuyển tiếp."
                    }
                };


                await context.Students.AddRangeAsync(students);
                await context.Departments.AddRangeAsync(departments);
                await context.LetterTemplates.AddRangeAsync(letterTemplates);
                await context.SaveChangesAsync();
            }
        }
    }
}
